using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Json;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Http
{
    public class ApiClient
    {

        private const string DEVICE_SERVER_URL = "device-server";
        private const string INSTALLATION_URL = "installation";
        private const string SESSION_SERVER_URL = "session-server";

        private static readonly string[] URIS_NOT_REQUIRING_ACTIVE_SESSION = new string[]
        {
            DEVICE_SERVER_URL,
            INSTALLATION_URL,
            SESSION_SERVER_URL
        };

        /// <summary>
        /// Header constants.
        /// </summary>
        public const string HEADER_ATTACHMENT_DESCRIPTION = "X-Bunq-Attachment-Description";
        public const string HEADER_CONTENT_TYPE = "Content-Type";
        public const string HEADER_CACHE_CONTROL = "Cache-Control";
        public const string HEADER_USER_AGENT = "User-Agent";
        private const string HEADER_LANGUAGE = "X-Bunq-Language";
        private const string HEADER_REGION = "X-Bunq-Region";
        private const string HEADER_REQUEST_ID = "X-Bunq-Client-Request-Id";
        private const string HEADER_GEOLOCATION = "X-Bunq-Geolocation";
        private const string HEADER_SIGNATURE = "X-Bunq-Client-Signature";
        private const string HEADER_AUTHENTICATION = "X-Bunq-Client-Authentication";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_ERROR = "Error";
        private const string FIELD_ERROR_DESCRIPTION = "error_description";

        /// <summary>
        /// Values for the default headers
        /// </summary>
        private const string CACHE_CONTROL_NONE = "no-cache";
        private const string USER_AGENT_BUNQ = "bunq-sdk-csharp/0.11.0.0-beta";
        private const string LANGUAGE_EN_US = "en_US";
        private const string REGION_NL_NL = "nl_NL";
        private const string GEOLOCATION_ZERO = "0 0 0 0 NL";

        /// <summary>
        /// Delimiter between multiple header values.
        /// </summary>
        private const string DELIMITER_HEADER_VALUE = ",";

        /// <summary>
        /// Delimiter between path and params in URI.
        /// </summary>
        public const char DELIMITER_URI_QUERY = '?';

        /// <summary>
        /// Delimiter between key and value of a URI param.
        /// </summary>
        public const char DELIMITER_URI_PARAM_KEY_VALUE = '=';

        /// <summary>
        /// Delimiter between URI params.
        /// </summary>
        public const char DELIMITER_URI_PARAMS = '&';

        private readonly HttpClient client;

        private readonly ApiContext apiContext;

        public ApiClient(ApiContext apiContext)
        {
            this.apiContext = apiContext;
            client = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(CreateHttpClientHandler())
            {
                BaseAddress = new Uri(apiContext.GetBaseUri())
            };
        }

        private HttpClientHandler CreateHttpClientHandler()
        {
            // TODO: Add HTTP Public Key Pinning. It is needed to prevent possible man-in-the-middle attacks using
            // the fake (or mis-issued) certificates.
            // More info: https://timtaubert.de/blog/2014/10/http-public-key-pinning-explained/
            // Simply put, we reduce the amount of certificates which are accepted in bunq API responses.
            var handler = new HttpClientHandler();

            if (apiContext.Proxy != null)
            {
                handler.Proxy = new BunqProxy(apiContext.Proxy);
                handler.UseProxy = true;
            }

            return handler;
        }

        /// <summary>
        /// Executes a POST request and returns the resulting HTTP response message.
        /// </summary>
        public BunqResponseRaw Post(string uriRelative, byte[] requestBytes,
            IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Post, uriRelative, requestBytes, new Dictionary<string, string>(),
                customHeaders);
        }

        private BunqResponseRaw SendRequest(HttpMethod method, string uriRelative, byte[] requestBodyBytes,
            IDictionary<string, string> uriParams, IDictionary<string, string> customHeaders)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative, uriParams, requestBodyBytes);

            return SendRequest(requestMessage, customHeaders, uriRelative);
        }

        private BunqResponseRaw SendRequest(HttpMethod method, string uriRelative,
            IDictionary<string, string> uriParams, IDictionary<string, string> customHeaders)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative, uriParams);

            return SendRequest(requestMessage, customHeaders, uriRelative);
        }

        private BunqResponseRaw SendRequest(HttpRequestMessage requestMessage,
            IDictionary<string, string> customHeaders, string uriRelative)
        {
            if (!URIS_NOT_REQUIRING_ACTIVE_SESSION.Contains(uriRelative))
            {
                apiContext.EnsureSessionActive();
            }
            
            SetDefaultHeaders(requestMessage);
            SetHeaders(requestMessage, customHeaders);
            SetSessionHeaders(requestMessage);
            var responseMessage = client.SendAsync(requestMessage).Result;
            AssertResponseSuccess(responseMessage);
            ValidateResponse(responseMessage);

            return CreateBunqResponseRaw(responseMessage);
        }

        private static BunqResponseRaw CreateBunqResponseRaw(HttpResponseMessage responseMessage)
        {
            var bodyBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
            var headers = GetHeaders(responseMessage);

            return new BunqResponseRaw(bodyBytes, headers);
        }

        private static IDictionary<string, string> GetHeaders(HttpResponseMessage responseMessage)
        {
            return responseMessage.Headers
                .Select(x => new KeyValuePair<string, string>(x.Key, string.Join(DELIMITER_HEADER_VALUE, x.Value)))
                .ToImmutableDictionary();
        }

        private void ValidateResponse(HttpResponseMessage responseMessage)
        {
            var installationContext = apiContext.InstallationContext;

            if (installationContext != null)
            {
                SecurityUtils.ValidateResponse(responseMessage, installationContext.PublicKeyServer);
            }
        }

        private static HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, string uriRelative,
            IDictionary<string, string> uriParams, byte[] requestBodyBytes)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative, uriParams);
            requestMessage.Content = new ByteArrayContent(requestBodyBytes);

            return requestMessage;
        }

        private static HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, string uriRelative,
            IDictionary<string, string> uriParams)
        {
            var uriWithParams = GetUriWithParams(uriRelative, uriParams);

            return new HttpRequestMessage(method, uriWithParams);
        }

        private static string GetUriWithParams(string uri, IDictionary<string, string> uriParams)
        {
            if (uriParams.Count <= 0) return uri;

            var uriWithParamsBuilder = new StringBuilder(uri);
            uriWithParamsBuilder.Append(DELIMITER_URI_QUERY);
            uriWithParamsBuilder.Append(GenerateUriParamsString(uriParams));

            return uriWithParamsBuilder.ToString();
        }

        private static string GenerateUriParamsString(IDictionary<string, string> uriParams)
        {
            return uriParams
                .Select(entry => entry.Key + DELIMITER_URI_PARAM_KEY_VALUE + entry.Value)
                .Aggregate((current, next) => current + DELIMITER_URI_PARAMS + next);
        }

        private static void SetDefaultHeaders(HttpRequestMessage requestMessage)
        {
            SetHeaders(requestMessage, GetDefaultHeaders());
        }

        private static void SetHeaders(HttpRequestMessage requestMessage, IDictionary<string, string> headersToAdd)
        {
            foreach (var header in headersToAdd)
            {
                if (IsHeaderSet(requestMessage.Headers, header.Key)) continue;
                if (requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value)) continue;
                if (IsHeaderSet(requestMessage.Content.Headers, header.Key)) continue;

                requestMessage.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        private static bool IsHeaderSet(HttpHeaders headers, string headerName)
        {
            IEnumerable<string> dummyOut;

            return headers.TryGetValues(headerName, out dummyOut);
        }

        private static IDictionary<string, string> GetDefaultHeaders()
        {
            return new SortedDictionary<string, string>
            {
                {HEADER_USER_AGENT, USER_AGENT_BUNQ},
                {HEADER_REQUEST_ID, GenerateRandomRequestId()},
                {HEADER_GEOLOCATION, GEOLOCATION_ZERO},
                {HEADER_LANGUAGE, LANGUAGE_EN_US},
                {HEADER_REGION, REGION_NL_NL},
                {HEADER_CACHE_CONTROL, CACHE_CONTROL_NONE}
            };
        }

        private static string GenerateRandomRequestId()
        {
            return Guid.NewGuid().ToString();
        }

        private void SetSessionHeaders(HttpRequestMessage requestMessage)
        {
            var sessionToken = apiContext.GetSessionToken();

            if (sessionToken == null) return;

            requestMessage.Headers.Add(HEADER_AUTHENTICATION, sessionToken);
            requestMessage.Headers.Add(HEADER_SIGNATURE, GenerateSignature(requestMessage));
        }

        private string GenerateSignature(HttpRequestMessage requestMessage)
        {
            return SecurityUtils.GenerateSignature(requestMessage, apiContext.InstallationContext.KeyPairClient);
        }

        private static void AssertResponseSuccess(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode) return;

            var responseCode = (int) responseMessage.StatusCode;
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;

            throw CreateApiExceptionRequestUnsuccessful(responseCode, responseBody);
        }

        private static ApiException CreateApiExceptionRequestUnsuccessful(int responseCode, string responseBody)
        {
            try
            {
                return new ApiException(responseCode, FetchErrorDescriptions(responseBody));
            }
            catch (JsonException)
            {
                return new ApiException(responseCode, new List<string> {responseBody});
            }
        }

        private static IList<string> FetchErrorDescriptions(string responseBody)
        {
            var responseBodyObject = BunqJsonConvert.DeserializeObject<JObject>(responseBody);

            return responseBodyObject[FIELD_ERROR] == null
                ? new List<string> {responseBody}
                : FetchErrorDescriptions(responseBodyObject);
        }

        private static IList<string> FetchErrorDescriptions(JObject responseBodyObject)
        {
            return responseBodyObject
                .GetValue(FIELD_ERROR).ToObject<JArray>()
                .Select(exceptionBody => exceptionBody.ToObject<JObject>())
                .Select(exceptionBodyJson => exceptionBodyJson.GetValue(FIELD_ERROR_DESCRIPTION).ToString())
                .ToList();
        }

        /// <summary>
        /// Executes a PUT request and returns the resulting HTTP response message.
        /// </summary>
        public BunqResponseRaw Put(string uriRelative, byte[] requestBytes,
            IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Put, uriRelative, requestBytes, new Dictionary<string, string>(),
                customHeaders);
        }

        /// <summary>
        /// Executes a GET request and returns the resulting HTTP response message.
        /// </summary>
        public BunqResponseRaw Get(string uriRelative, IDictionary<string, string> uriParams,
            IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Get, uriRelative, uriParams, customHeaders);
        }

        /// <summary>
        /// Executes a DELETE request and returns the resulting HTTP response message.
        /// </summary>
        public BunqResponseRaw Delete(string uriRelative, IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Delete, uriRelative, new Dictionary<string, string>(), customHeaders);
        }
    }
}
