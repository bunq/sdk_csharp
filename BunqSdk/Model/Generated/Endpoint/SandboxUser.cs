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
    /// Used to create a sandbox user.
    /// </summary>
    public class SandboxUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "sandbox-user";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "ApiKey";

        /// <summary>
        /// The API key of the newly created sandbox user.
        /// </summary>
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<SandboxUser> Create(IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return FromJson<SandboxUser>(responseRaw, OBJECT_TYPE_POST);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ApiKey != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static SandboxUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SandboxUser>(json);
        }
    }
}