using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view TabResultInquiry objects belonging to a tab. A TabResultInquiry is an object that holds details on
    /// both the tab and a single payment made for that tab.
    /// </summary>
    public class TabResultInquiry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-result-inquiry/{4}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-result-inquiry";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "TabResultInquiry";
    
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
        /// Used to view a single TabResultInquiry belonging to a tab.
        /// </summary>
        public static BunqResponse<TabResultInquiry> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabResultInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, monetaryAccountId, cashRegisterId, tabUuid, tabResultInquiryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabResultInquiry>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Used to view a list of TabResultInquiry objects belonging to a tab.
        /// </summary>
        public static BunqResponse<List<TabResultInquiry>> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId, cashRegisterId, tabUuid), urlParams, customHeaders);
    
            return FromJsonList<TabResultInquiry>(responseRaw, ObjectType);
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
        public static TabResultInquiry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabResultInquiry>(json);
        }
    }
}
