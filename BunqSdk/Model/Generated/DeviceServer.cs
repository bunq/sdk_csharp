using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// After having created an Installation you can now create a DeviceServer. A DeviceServer is needed to do a login
    /// call with session-server.
    /// </summary>
    public class DeviceServer : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_SECRET = "secret";
        public const string FIELD_PERMITTED_IPS = "permitted_ips";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "device-server";
        private const string ENDPOINT_URL_READ = "device-server/{0}";
        private const string ENDPOINT_URL_LISTING = "device-server";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "DeviceServer";

        /// <summary>
        /// The id of the DeviceServer as created on the server.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the DeviceServer's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the DeviceServer's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The description of the DeviceServer.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The ip address which was used to create the DeviceServer.
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; private set; }

        /// <summary>
        /// The status of the DeviceServer. Can be ACTIVE, BLOCKED, NEEDS_CONFIRMATION or OBSOLETE.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap)
        {
            return Create(apiContext, requestMap, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new DeviceServer. Provide the Installation token in the "X-Bunq-Client-Authentication" header. And
        /// sign this request with the key of which you used the public part to create the Installation. Your API key
        /// will be bound to the ip address of this DeviceServer.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<DeviceServer> Get(ApiContext apiContext, int deviceServerId)
        {
            return Get(apiContext, deviceServerId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get one of your DeviceServers.
        /// </summary>
        public static BunqResponse<DeviceServer> Get(ApiContext apiContext, int deviceServerId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, deviceServerId), customHeaders);

            return FromJson<DeviceServer>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<DeviceServer>> List(ApiContext apiContext)
        {
            return List(apiContext, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of all the DeviceServers you have created.
        /// </summary>
        public static BunqResponse<List<DeviceServer>> List(ApiContext apiContext,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(ENDPOINT_URL_LISTING, customHeaders);

            return FromJsonList<DeviceServer>(responseRaw, OBJECT_TYPE);
        }
    }
}
