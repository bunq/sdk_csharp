using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Create a credential of a user for server authentication, or delete the credential of a user for server
    /// authentication.
    /// </summary>
    public class UserCredentialPasswordIp : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}/credential-password-ip/{1}";
        private const string EndpointUrlListing = "user/{0}/credential-password-ip";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "CredentialPasswordIp";
    
        /// <summary>
        /// The id of the credential.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the credential object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the credential object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The status of the credential.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// When the status is PENDING_FIRST_USE: when the credential expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; private set; }
    
        /// <summary>
        /// When the status is PENDING_FIRST_USE: the value of the token.
        /// </summary>
        [JsonProperty(PropertyName = "token_value")]
        public string TokenValue { get; private set; }
    
        /// <summary>
        /// When the status is ACTIVE: the details of the device that may use the credential.
        /// </summary>
        [JsonProperty(PropertyName = "permitted_device")]
        public PermittedDevice PermittedDevice { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<UserCredentialPasswordIp> Get(ApiContext apiContext, int userId, int userCredentialPasswordIpId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, userCredentialPasswordIpId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<UserCredentialPasswordIp>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<UserCredentialPasswordIp>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<UserCredentialPasswordIp>(responseRaw, ObjectType);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.ExpiryTime != null)
            {
                return false;
            }
    
            if (this.TokenValue != null)
            {
                return false;
            }
    
            if (this.PermittedDevice != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static UserCredentialPasswordIp CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserCredentialPasswordIp>(json);
        }
    }
}
