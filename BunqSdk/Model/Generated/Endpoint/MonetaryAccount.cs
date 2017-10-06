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
    /// Used to show the MonetaryAccounts that you can access. Currently the only MonetaryAccount type is
    /// MonetaryAccountBank. See also: monetary-account-bank.<br/><br/>Notification filters can be set on a monetary
    /// account level to receive callbacks. For more information check the <a href="/api/2/page/callbacks">dedicated
    /// callbacks page</a>.
    /// </summary>
    public class MonetaryAccount : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "MonetaryAccount";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountBank")]
        public MonetaryAccountBank MonetaryAccountBank { get; private set; }
    
        /// <summary>
        /// Get a specific MonetaryAccount.
        /// </summary>
        public static BunqResponse<MonetaryAccount> Get(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MonetaryAccount>(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of all your MonetaryAccounts.
        /// </summary>
        public static BunqResponse<List<MonetaryAccount>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), urlParams, customHeaders);
    
            return FromJsonList<MonetaryAccount>(responseRaw);
        }
    }
}
