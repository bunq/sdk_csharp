using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;

namespace Bunq.Sdk.Model
{
    public class DeviceServer : BunqModel
    {
        /// <summary>
        /// Endpoint name.
        /// </summary>
        private const string ENDPOINT_URL_POST = "device-server";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_DESCRIPTION = "description";
        private const string FIELD_SECRET = "secret";
        private const string FIELD_PERMITTED_IPS = "permitted_ips";

        /// <summary>
        /// Create a new DeviceServer. Provide the Installation token in the
        /// "X-Bunq-Client-Authentication" header. And sign this request with the key
        /// of which you used the public part to create the Installation. Your API key
        /// will be bound to the ip address of this DeviceServer.
        /// </summary>
        public static int Create(ApiContext apiContext, string description, IList<string> permittedIps)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = GenerateRequestBodyBytes(description, apiContext.ApiKey, permittedIps);
            var response = apiClient.Post(ENDPOINT_URL_POST, requestBytes, new Dictionary<string, string>());

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        private static byte[] GenerateRequestBodyBytes(string description,
            string apiKey, IList<string> permittedIps)
        {
            var deviceServerRequestBody = new Dictionary<string, object>
            {
                {FIELD_DESCRIPTION, description},
                {FIELD_SECRET, apiKey},
                {FIELD_PERMITTED_IPS, permittedIps}
            };

            return Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(deviceServerRequestBody));
        }
    }
}
