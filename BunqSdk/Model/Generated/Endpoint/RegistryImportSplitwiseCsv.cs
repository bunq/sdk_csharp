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
    /// Used to upload a CSV export from Splitwise, and create a new Registry from it.
    /// </summary>
    public class RegistryImportSplitwiseCsv : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "registry-import-splitwise-csv";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "RegistryImport";
    
        /// <summary>
        /// The registry details.
        /// </summary>
        [JsonProperty(PropertyName = "registry")]
        public Registry Registry { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<RegistryImportSplitwiseCsv> Create( IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);
    
            return FromJson<RegistryImportSplitwiseCsv>(responseRaw, OBJECT_TYPE_POST);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Registry != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistryImportSplitwiseCsv CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistryImportSplitwiseCsv>(json);
        }
    }
}
