using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
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
        private const string ENDPOINT_URL_READ = "user/{0}/credential-password-ip/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/credential-password-ip";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CredentialPasswordIp";

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

        public static BunqResponse<UserCredentialPasswordIp> Get(ApiContext apiContext, int userId,
            int userCredentialPasswordIpId)
        {
            return Get(apiContext, userId, userCredentialPasswordIpId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<UserCredentialPasswordIp> Get(ApiContext apiContext, int userId,
            int userCredentialPasswordIpId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, userCredentialPasswordIpId),
                customHeaders);

            return FromJson<UserCredentialPasswordIp>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<UserCredentialPasswordIp>> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<UserCredentialPasswordIp>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<UserCredentialPasswordIp>(responseRaw, OBJECT_TYPE);
        }
    }
}
