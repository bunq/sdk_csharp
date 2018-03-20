using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Model.Core
{
    public class DeviceServerInternal : DeviceServer
    {
        /// <summary>
        /// Create a new DeviceServer providing the installation token in the header and signing the request with the
        /// private part of the key you used to create the installation. The API Key that you are using will be bound to
        /// the IP address of the DeviceServer which you have created.<br/><br/>Using a Wildcard API Key gives you the
        /// freedom to make API calls even if the IP address has changed after the POST device-server.<br/><br/>Find out
        /// more at this link <a href="https://bunq.com/en/apikey-dynamic-ip"
        /// target="_blank">https://bunq.com/en/apikey-dynamic-ip</a>.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, string description, string secret, List<string> permittedIps = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);

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
    }
}
