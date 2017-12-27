using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// After you’ve created a Tab using /tab-usage-single or /tab-usage-multiple you can add items and attachments
    /// using tab-item. You can only add or modify TabItems of a Tab which status is OPEN. The amount of the TabItems
    /// will not influence the total_amount of the corresponding Tab. However, if you've created any TabItems for a Tab
    /// the sum of the amounts of these items must be equal to the total_amount of the Tab when you change its status to
    /// PAYABLE/WAITING_FOR_PAYMENT.
    /// </summary>
    public class TabItemShop : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        private const string EndpointUrlUpdate = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        private const string EndpointUrlDelete = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        private const string EndpointUrlRead = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldDescription = "description";
        public const string FieldEanCode = "ean_code";
        public const string FieldAvatarAttachmentUuid = "avatar_attachment_uuid";
        public const string FieldTabAttachment = "tab_attachment";
        public const string FieldQuantity = "quantity";
        public const string FieldAmount = "amount";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "TabItem";
    
        /// <summary>
        /// The id of the created TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The TabItem's brief description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The TabItem's EAN code.
        /// </summary>
        [JsonProperty(PropertyName = "ean_code")]
        public string EanCode { get; private set; }
    
        /// <summary>
        /// A struct with an AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment")]
        public AttachmentPublic AvatarAttachment { get; private set; }
    
        /// <summary>
        /// A list of AttachmentTab attached to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<AttachmentTab> TabAttachment { get; private set; }
    
        /// <summary>
        /// The quantity of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; private set; }
    
        /// <summary>
        /// The money amount of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; private set; }
    
        /// <summary>
        /// Create a new TabItem for a given Tab.
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
        /// Modify a TabItem from a given Tab.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabItemShopId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Delete a specific TabItem from a Tab. This request returns an empty response.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabItemShopId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(EndpointUrlDelete, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// Get a collection of TabItems from a given Tab.
        /// </summary>
        public static BunqResponse<List<TabItemShop>> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId, cashRegisterId, tabUuid), urlParams, customHeaders);
    
            return FromJsonList<TabItemShop>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get a specific TabItem from a given Tab.
        /// </summary>
        public static BunqResponse<TabItemShop> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabItemShopId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabItemShop>(responseRaw, ObjectType);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.EanCode != null)
            {
                return false;
            }
    
            if (this.AvatarAttachment != null)
            {
                return false;
            }
    
            if (this.TabAttachment != null)
            {
                return false;
            }
    
            if (this.Quantity != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TabItemShop CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabItemShop>(json);
        }
    }
}
