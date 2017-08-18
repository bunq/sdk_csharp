using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private const string USER_AGENT_BUNQ = "bunq-sdk-csharp/0.9.2.0-beta";
        private const string LANGUAGE_EN_US = "en_US";
        private const string REGION_NL_NL = "nl_NL";
        private const string GEOLOCATION_ZERO = "0 0 0 0 NL";

        private static HttpClient client;

        private readonly ApiContext apiContext;

        public ApiClient(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        /// <summary>
        /// Executes a POST request and returns the resulting HTTP response message.
        /// </summary>
        public HttpResponseMessage Post(string uriRelative, byte[] requestBytes,
            IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Post, uriRelative, requestBytes, customHeaders);
        }

        private HttpResponseMessage SendRequest(HttpMethod method, string uriRelative, byte[] requestBodyBytes,
            IDictionary<string, string> customHeaders)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative, requestBodyBytes);

            return SendRequest(requestMessage, customHeaders);
        }

        private HttpResponseMessage SendRequest(HttpMethod method, string uriRelative,
            IDictionary<string, string> customHeaders)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative);

            return SendRequest(requestMessage, customHeaders);
        }

        private HttpResponseMessage SendRequest(HttpRequestMessage requestMessage,
            IDictionary<string, string> customHeaders)
        {
            apiContext.EnsureSessionActive();
            SetDefaultHeaders(requestMessage);
            SetHeaders(requestMessage, customHeaders);
            SetSessionHeaders(requestMessage);
            InitializeHttpClientIfNeeded(apiContext);
            var responseMessage = client.SendAsync(requestMessage).Result;
            AssertResponseSuccess(responseMessage);
            ValidateResponse(responseMessage);

            return responseMessage;
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
            byte[] requestBodyBytes)
        {
            var requestMessage = CreateHttpRequestMessage(method, uriRelative);
            requestMessage.Content = new ByteArrayContent(requestBodyBytes);

            return requestMessage;
        }

        private static HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, string uriRelative)
        {
            return new HttpRequestMessage(method, uriRelative);
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

        private static void InitializeHttpClientIfNeeded(ApiContext apiContext)
        {
            if (client == null)
            {
                // TODO: Add HTTP Public Key Pinning. It is needed to prevent possible man-in-the-middle attacks using
                // the fake (or mis-issued) certificates.
                // More info: https://timtaubert.de/blog/2014/10/http-public-key-pinning-explained/
                // Simply put, we reduce the amount of certificates which are accepted in bunq API responses.
                client = new HttpClient
                {
                    BaseAddress = new Uri(apiContext.GetBaseUri())
                };
            }
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
        public HttpResponseMessage Put(string uriRelative, byte[] requestBytes,
            IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Put, uriRelative, requestBytes, customHeaders);
        }

        /// <summary>
        /// Executes a GET request and returns the resulting HTTP response message.
        /// </summary>
        public HttpResponseMessage Get(string uriRelative, IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Get, uriRelative, customHeaders);
        }

        /// <summary>
        /// Executes a DELETE request and returns the resulting HTTP response message.
        /// </summary>
        public HttpResponseMessage Delete(string uriRelative, IDictionary<string, string> customHeaders)
        {
            return SendRequest(HttpMethod.Delete, uriRelative, customHeaders);
        }
    }
}
