using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Once your CashRegister has been activated you can use it to create Tabs. A Tab is a template for a payment. In
    /// contrast to requests a Tab is not pointed towards a specific user. Any user can pay the Tab as long as it is
    /// made visible by you. The creation of a Tab happens with /tab-usage-single or /tab-usage-multiple. A
    /// TabUsageSingle is a Tab that can be paid once. A TabUsageMultiple is a Tab that can be paid multiple times by
    /// different users.
    /// </summary>
    public class Tab : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ErrorNullFields = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/cash-register/{2}/tab";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "Tab";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabUsageSingle")]
        public TabUsageSingle TabUsageSingle { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabUsageMultiple")]
        public TabUsageMultiple TabUsageMultiple { get; private set; }
    
        /// <summary>
        /// Get a specific tab. This returns a TabUsageSingle or TabUsageMultiple.
        /// </summary>
        public static BunqResponse<Tab> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, monetaryAccountId, cashRegisterId, tabUuid), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<Tab>(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of tabs.
        /// </summary>
        public static BunqResponse<List<Tab>> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId, cashRegisterId), urlParams, customHeaders);
    
            return FromJsonList<Tab>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.TabUsageSingle != null)
            {
                return this.TabUsageSingle;
            }
    
            if (this.TabUsageMultiple != null)
            {
                return this.TabUsageMultiple;
            }
    
            throw new BunqException(ErrorNullFields);
        }
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.TabUsageSingle != null)
            {
                return false;
            }
    
            if (this.TabUsageMultiple != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Tab CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Tab>(json);
        }
    }
}
