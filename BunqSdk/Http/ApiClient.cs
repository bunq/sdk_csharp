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

        /// <summary>
        /// Endpoints not requiring active session for the request to succeed.
        /// </summary>
        private const string DeviceServerUrl = "device-server";
        private const string InstallationUrl = "installation";
        private const string SessionServerUrl = "session-server";
        private static readonly string[] AllUriNotRequiringActiveSession = 
        {
            DeviceServerUrl,
            InstallationUrl,
            SessionServerUrl
        };

        /// <summary>
        /// Header constants.
        /// </summary>
        public const string HeaderAttachmentDescription = "X-Bunq-Attachment-Description";
        public const string HeaderContentType = "Content-Type";
        public const string HeaderCacheControl = "Cache-Control";
        public const string HeaderUserAgent = "User-Agent";
        private const string HeaderLanguage = "X-Bunq-Language";
        private const string HeaderRegion = "X-Bunq-Region";
        private const string HeaderRequestId = "X-Bunq-Client-Request-Id";
        private const string HeaderGeolocation = "X-Bunq-Geolocation";
        private const string HeaderSignature = "X-Bunq-Client-Signature";
        private const string HeaderAuthentication = "X-Bunq-Client-Authentication";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FieldError = "Error";
        private const string FieldErrorDescription = "error_description";

        /// <summary>
        /// Values for the default headers
        /// </summary>
        private const string HeaderValueCacheControlNone = "no-cache";
        private const string HeaderValueUserAgentBunq = "bunq-sdk-csharp/0.12.4.0-beta";
        private const string HeaderValueLanguageEnUs = "en_US";
        private const string HeaderValueRegionNlNl = "nl_NL";
        private const string HeaderValueGeolocationZero = "0 0 0 0 NL";

        /// <summary>
        /// Delimiter between multiple header values.
        /// </summary>
        private const string DelimiterHeaderValue = ",";

        /// <summary>
        /// Delimiter between path and params in URI.
        /// </summary>
        public const char DelimiterUriQuery = '?';

        /// <summary>
        /// Delimiter between key and value of a URI param.
        /// </summary>
        public const char DelimiterUriParamKeyValue = '=';

        /// <summary>
        /// Delimiter between URI params.
        /// </summary>
        public const char DelimiterAllUriParameter = '&';

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
            if (!AllUriNotRequiringActiveSession.Contains(uriRelative))
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
                .Select(x => new KeyValuePair<string, string>(x.Key, string.Join(DelimiterHeaderValue, x.Value)))
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
            uriWithParamsBuilder.Append(DelimiterUriQuery);
            uriWithParamsBuilder.Append(GenerateUriParamsString(uriParams));

            return uriWithParamsBuilder.ToString();
        }

        private static string GenerateUriParamsString(IDictionary<string, string> uriParams)
        {
            return uriParams
                .Select(entry => entry.Key + DelimiterUriParamKeyValue + entry.Value)
                .Aggregate((current, next) => current + DelimiterAllUriParameter + next);
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
                {HeaderUserAgent, HeaderValueUserAgentBunq},
                {HeaderRequestId, GenerateRandomRequestId()},
                {HeaderGeolocation, HeaderValueGeolocationZero},
                {HeaderLanguage, HeaderValueLanguageEnUs},
                {HeaderRegion, HeaderValueRegionNlNl},
                {HeaderCacheControl, HeaderValueCacheControlNone}
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

            requestMessage.Headers.Add(HeaderAuthentication, sessionToken);
            requestMessage.Headers.Add(HeaderSignature, GenerateSignature(requestMessage));
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
                return ExceptionFactory.CreateExceptionForResponse(responseCode, FetchErrorDescriptions(responseBody));
            }
            catch (JsonException)
            {
                return ExceptionFactory.CreateExceptionForResponse(responseCode, new List<string> {responseBody});
            }
        }

        private static IList<string> FetchErrorDescriptions(string responseBody)
        {
            var responseBodyObject = BunqJsonConvert.DeserializeObject<JObject>(responseBody);

            return responseBodyObject[FieldError] == null
                ? new List<string> {responseBody}
                : FetchErrorDescriptions(responseBodyObject);
        }

        private static IList<string> FetchErrorDescriptions(JObject responseBodyObject)
        {
            return responseBodyObject
                .GetValue(FieldError).ToObject<JArray>()
                .Select(exceptionBody => exceptionBody.ToObject<JObject>())
                .Select(exceptionBodyJson => exceptionBodyJson.GetValue(FieldErrorDescription).ToString())
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
