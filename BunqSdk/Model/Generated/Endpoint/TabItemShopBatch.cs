using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Create a batch of tab items.
    /// </summary>
    public class TabItemShopBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldTabItems = "tab_items";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "TabItemShopBatch";
    
        /// <summary>
        /// The list of tab items in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "tab_items")]
        public List<TabItemShop> TabItems { get; private set; }
    
        /// <summary>
        /// Create tab items as a batch.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, monetaryAccountId, cashRegisterId, tabUuid), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.TabItems != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TabItemShopBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabItemShopBatch>(json);
        }
    }
}
