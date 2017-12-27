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
    /// Using /installation/_/server-public-key you can request the ServerPublicKey again. This is done by referring to
    /// the id of the Installation.
    /// </summary>
    public class InstallationServerPublicKey : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "installation/{0}/server-public-key";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ServerPublicKey";
    
        /// <summary>
        /// The server's public key for this Installation.
        /// </summary>
        [JsonProperty(PropertyName = "server_public_key")]
        public string ServerPublicKey { get; private set; }
    
        /// <summary>
        /// Show the ServerPublicKey for this Installation.
        /// </summary>
        public static BunqResponse<List<InstallationServerPublicKey>> List(ApiContext apiContext, int installationId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, installationId), urlParams, customHeaders);
    
            return FromJsonList<InstallationServerPublicKey>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ServerPublicKey != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static InstallationServerPublicKey CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<InstallationServerPublicKey>(json);
        }
    }
}
