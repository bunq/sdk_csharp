using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to get a Device or a listing of Devices. Creating a DeviceServer should happen via /device-server
    /// </summary>
    public class Device : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "device/{0}";
        private const string ENDPOINT_URL_LISTING = "device";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Device";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DevicePhone")]
        public DevicePhone DevicePhone { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DeviceServer")]
        public DeviceServer DeviceServer { get; private set; }

        public static Device Get(ApiContext apiContext, int deviceId)
        {
            return Get(apiContext, deviceId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a single Device. A Device is either a DevicePhone or a DeviceServer.
        /// </summary>
        public static Device Get(ApiContext apiContext, int deviceId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, deviceId), customHeaders);

            return FromJson<Device>(response.Content.ReadAsStringAsync().Result);
        }

        public static List<Device> List(ApiContext apiContext)
        {
            return List(apiContext, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of Devices. A Device is either a DevicePhone or a DeviceServer.
        /// </summary>
        public static List<Device> List(ApiContext apiContext, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(ENDPOINT_URL_LISTING, customHeaders);

            return FromJsonList<Device>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
