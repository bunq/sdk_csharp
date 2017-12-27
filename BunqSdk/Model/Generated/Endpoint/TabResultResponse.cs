using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view TabResultResponse objects belonging to a tab. A TabResultResponse is an object that holds details
    /// on a tab which has been paid from the provided monetary account.
    /// </summary>
    public class TabResultResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}/monetary-account/{1}/tab-result-response/{2}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/tab-result-response";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "TabResultResponse";
    
        /// <summary>
        /// The Tab details.
        /// </summary>
        [JsonProperty(PropertyName = "tab")]
        public Tab Tab { get; private set; }
    
        /// <summary>
        /// The payment made for the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; private set; }
    
        /// <summary>
        /// Used to view a single TabResultResponse belonging to a tab.
        /// </summary>
        public static BunqResponse<TabResultResponse> Get(ApiContext apiContext, int userId, int monetaryAccountId, int tabResultResponseId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, monetaryAccountId, tabResultResponseId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabResultResponse>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Used to view a list of TabResultResponse objects belonging to a tab.
        /// </summary>
        public static BunqResponse<List<TabResultResponse>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<TabResultResponse>(responseRaw, ObjectType);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Tab != null)
            {
                return false;
            }
    
            if (this.Payment != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TabResultResponse CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabResultResponse>(json);
        }
    }
}
