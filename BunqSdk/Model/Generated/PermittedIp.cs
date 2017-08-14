using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Manage the IPs which may be used for a credential of a user for server authentication.
    /// </summary>
    public class PermittedIp : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_IP = "ip";
        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/credential-password-ip/{1}/ip/{2}";
        private const string ENDPOINT_URL_CREATE = "user/{0}/credential-password-ip/{1}/ip";
        private const string ENDPOINT_URL_LISTING = "user/{0}/credential-password-ip/{1}/ip";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/credential-password-ip/{1}/ip/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "PermittedIp";

        /// <summary>
        /// The IP address.
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; private set; }

        /// <summary>
        /// The status of the IP. May be "ACTIVE" or "INACTIVE". It is only possible to make requests from "ACTIVE" IP
        /// addresses. Only "ACTIVE" IPs will be billed.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        public static BunqResponse<PermittedIp> Get(ApiContext apiContext, int userId, int credentialPasswordIpId,
            int permittedIpId)
        {
            return Get(apiContext, userId, credentialPasswordIpId, permittedIpId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<PermittedIp> Get(ApiContext apiContext, int userId, int credentialPasswordIpId,
            int permittedIpId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, credentialPasswordIpId, permittedIpId),
                    customHeaders);

            return FromJson<PermittedIp>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int credentialPasswordIpId)
        {
            return Create(apiContext, requestMap, userId, credentialPasswordIpId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int credentialPasswordIpId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, credentialPasswordIpId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<List<PermittedIp>> List(ApiContext apiContext, int userId,
            int credentialPasswordIpId)
        {
            return List(apiContext, userId, credentialPasswordIpId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<PermittedIp>> List(ApiContext apiContext, int userId,
            int credentialPasswordIpId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, credentialPasswordIpId),
                customHeaders);

            return FromJsonList<PermittedIp>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int credentialPasswordIpId, int permittedIpId)
        {
            return Update(apiContext, requestMap, userId, credentialPasswordIpId, permittedIpId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int credentialPasswordIpId, int permittedIpId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, credentialPasswordIpId, permittedIpId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }
    }
}
