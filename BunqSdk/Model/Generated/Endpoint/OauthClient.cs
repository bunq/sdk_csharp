using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used for managing OAuth Clients.
    /// </summary>
    public class OauthClient : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/oauth-client/{1}";
        protected const string ENDPOINT_URL_CREATE = "user/{0}/oauth-client";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/oauth-client/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/oauth-client";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "OauthClient";
    
        /// <summary>
        /// The status of the pack group, can be ACTIVE, CANCELLED or CANCELLED_PENDING.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// Id of the client.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The display name of this Oauth Client
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
    
        /// <summary>
        /// The Client ID associated with this Oauth Client
        /// </summary>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }
    
        /// <summary>
        /// Secret associated with this Oauth Client
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }
    
        /// <summary>
        /// The callback URLs which are bound to this Oauth Client
        /// </summary>
        [JsonProperty(PropertyName = "callback_url")]
        public List<OauthCallbackUrl> CallbackUrl { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<OauthClient> Get(int oauthClientId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), oauthClientId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<OauthClient>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the Oauth Client, can be ACTIVE or CANCELLED.</param>
        public static BunqResponse<int> Create(string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the Oauth Client, can be ACTIVE or CANCELLED.</param>
        public static BunqResponse<int> Update(int oauthClientId, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), oauthClientId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<OauthClient>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<OauthClient>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.DisplayName != null)
            {
                return false;
            }
    
            if (this.ClientId != null)
            {
                return false;
            }
    
            if (this.Secret != null)
            {
                return false;
            }
    
            if (this.CallbackUrl != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static OauthClient CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<OauthClient>(json);
        }
    }
}
