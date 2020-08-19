using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// After having created an Installation you can now create a DeviceServer. A DeviceServer is needed to do a login
    /// call with session-server.
    /// </summary>
    public class DeviceServer : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "device-server";
        protected const string ENDPOINT_URL_READ = "device-server/{0}";
        protected const string ENDPOINT_URL_LISTING = "device-server";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_SECRET = "secret";
        public const string FIELD_PERMITTED_IPS = "permitted_ips";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "DeviceServer";

        /// <summary>
        /// The description of the DeviceServer.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The API key. You can request an API key in the bunq app.
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <summary>
        /// An array of IPs (v4 or v6) this DeviceServer will be able to do calls from. These will be linked to the API
        /// key.
        /// </summary>
        [JsonProperty(PropertyName = "permitted_ips")]
        public List<string> PermittedIps { get; set; }

        /// <summary>
        /// The id of the DeviceServer as created on the server.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the DeviceServer's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the DeviceServer's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The ip address which was used to create the DeviceServer.
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        /// <summary>
        /// The status of the DeviceServer. Can be ACTIVE, BLOCKED, NEEDS_CONFIRMATION or OBSOLETE.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Create a new DeviceServer providing the installation token in the header and signing the request with the
        /// private part of the key you used to create the installation. The API Key that you are using will be bound to
        /// the IP address of the DeviceServer which you have created.<br/><br/>Using a Wildcard API Key gives you the
        /// freedom to make API calls even if the IP address has changed after the POST device-server.<br/><br/>Find out
        /// more at this link <a href="https://bunq.com/en/apikey-dynamic-ip"
        /// target="_blank">https://bunq.com/en/apikey-dynamic-ip</a>.
        /// </summary>
        /// <param name="description">The description of the DeviceServer. This is only for your own reference when reading the DeviceServer again.</param>
        /// <param name="secret">The API key. You can request an API key in the bunq app.</param>
        /// <param name="permittedIps">An array of IPs (v4 or v6) this DeviceServer will be able to do calls from. These will be linked to the API key.</param>
        public static BunqResponse<int> Create(string description, string secret, List<string> permittedIps = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_DESCRIPTION, description},
                {FIELD_SECRET, secret},
                {FIELD_PERMITTED_IPS, permittedIps},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get one of your DeviceServers.
        /// </summary>
        public static BunqResponse<DeviceServer> Get(int deviceServerId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, deviceServerId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<DeviceServer>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a collection of all the DeviceServers you have created.
        /// </summary>
        public static BunqResponse<List<DeviceServer>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(ENDPOINT_URL_LISTING, urlParams, customHeaders);

            return FromJsonList<DeviceServer>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.Description != null)
            {
                return false;
            }

            if (this.Ip != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static DeviceServer CreateFromJsonString(string json)
        {
            return CreateFromJsonString<DeviceServer>(json);
        }
    }
}