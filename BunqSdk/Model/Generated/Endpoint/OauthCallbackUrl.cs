using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used for managing OAuth Client Callback URLs.
    /// </summary>
    public class OauthCallbackUrl : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/oauth-client/{1}/callback-url/{2}";

        protected const string ENDPOINT_URL_CREATE = "user/{0}/oauth-client/{1}/callback-url";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/oauth-client/{1}/callback-url/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/oauth-client/{1}/callback-url";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/oauth-client/{1}/callback-url/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_URL = "url";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "OauthCallbackUrl";

        /// <summary>
        /// The URL for this callback.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<OauthCallbackUrl> Get(int oauthClientId, int oauthCallbackUrlId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), oauthClientId, oauthCallbackUrlId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<OauthCallbackUrl>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="url">The URL for this callback.</param>
        public static BunqResponse<int> Create(int oauthClientId, string url,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_URL, url},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), oauthClientId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        /// <param name="url">The URL for this callback.</param>
        public static BunqResponse<int> Update(int oauthClientId, int oauthCallbackUrlId, string url = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_URL, url},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), oauthClientId, oauthCallbackUrlId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<OauthCallbackUrl>> List(int oauthClientId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), oauthClientId),
                urlParams, customHeaders);

            return FromJsonList<OauthCallbackUrl>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int oauthClientId, int oauthCallbackUrlId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), oauthClientId, oauthCallbackUrlId),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Url != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static OauthCallbackUrl CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<OauthCallbackUrl>(json);
        }
    }
}