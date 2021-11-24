using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

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
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_EAN_CODE = "ean_code";
        public const string FIELD_AVATAR_ATTACHMENT_UUID = "avatar_attachment_uuid";
        public const string FIELD_TAB_ATTACHMENT = "tab_attachment";
        public const string FIELD_QUANTITY = "quantity";
        public const string FIELD_AMOUNT = "amount";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TabItem";
    
        /// <summary>
        /// The TabItem's brief description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The TabItem's EAN code.
        /// </summary>
        [JsonProperty(PropertyName = "ean_code")]
        public string EanCode { get; set; }
    
        /// <summary>
        /// An AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment_uuid")]
        public string AvatarAttachmentUuid { get; set; }
    
        /// <summary>
        /// A list of AttachmentTab attached to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<AttachmentTab> TabAttachment { get; set; }
    
        /// <summary>
        /// The quantity of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; set; }
    
        /// <summary>
        /// The money amount of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The id of the created TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// A struct with an AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment")]
        public AttachmentPublic AvatarAttachment { get; set; }
    
    
        /// <summary>
        /// Create a new TabItem for a given Tab.
        /// </summary>
        /// <param name="description">The TabItem's brief description. Can't be empty and must be no longer than 100 characters</param>
        /// <param name="eanCode">The TabItem's EAN code.</param>
        /// <param name="avatarAttachmentUuid">An AttachmentPublic UUID that used as an avatar for the TabItem.</param>
        /// <param name="tabAttachment">A list of AttachmentTab attached to the TabItem.</param>
        /// <param name="quantity">The quantity of the TabItem. Formatted as a number containing up to 15 digits, up to 15 decimals and using a dot.</param>
        /// <param name="amount">The money amount of the TabItem. Will not change the value of the corresponding Tab.</param>
        public static BunqResponse<int> Create(int cashRegisterId, string tabUuid, string description, int? monetaryAccountId= null, string eanCode = null, string avatarAttachmentUuid = null, List<TabAttachment> tabAttachment = null, string quantity = null, Amount amount = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_DESCRIPTION, description},
    {FIELD_EAN_CODE, eanCode},
    {FIELD_AVATAR_ATTACHMENT_UUID, avatarAttachmentUuid},
    {FIELD_TAB_ATTACHMENT, tabAttachment},
    {FIELD_QUANTITY, quantity},
    {FIELD_AMOUNT, amount},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Modify a TabItem from a given Tab.
        /// </summary>
        /// <param name="description">The TabItem's brief description. Can't be empty and must be no longer than 100 characters</param>
        /// <param name="eanCode">The TabItem's EAN code.</param>
        /// <param name="avatarAttachmentUuid">An AttachmentPublic UUID that used as an avatar for the TabItem.</param>
        /// <param name="tabAttachment">A list of AttachmentTab attached to the TabItem.</param>
        /// <param name="quantity">The quantity of the TabItem. Formatted as a number containing up to 15 digits, up to 15 decimals and using a dot.</param>
        /// <param name="amount">The money amount of the TabItem. Will not change the value of the corresponding Tab.</param>
        public static BunqResponse<int> Update(int cashRegisterId, string tabUuid, int tabItemShopId, int? monetaryAccountId= null, string description = null, string eanCode = null, string avatarAttachmentUuid = null, List<TabAttachment> tabAttachment = null, string quantity = null, Amount amount = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_DESCRIPTION, description},
    {FIELD_EAN_CODE, eanCode},
    {FIELD_AVATAR_ATTACHMENT_UUID, avatarAttachmentUuid},
    {FIELD_TAB_ATTACHMENT, tabAttachment},
    {FIELD_QUANTITY, quantity},
    {FIELD_AMOUNT, amount},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid, tabItemShopId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Delete a specific TabItem from a Tab.
        /// </summary>
        public static BunqResponse<object> Delete(int cashRegisterId, string tabUuid, int tabItemShopId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid, tabItemShopId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// Get a collection of TabItems from a given Tab.
        /// </summary>
        public static BunqResponse<List<TabItemShop>> List(int cashRegisterId, string tabUuid, int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid), urlParams, customHeaders);
    
            return FromJsonList<TabItemShop>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Get a specific TabItem from a given Tab.
        /// </summary>
        public static BunqResponse<TabItemShop> Get(int cashRegisterId, string tabUuid, int tabItemShopId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid, tabItemShopId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabItemShop>(responseRaw, OBJECT_TYPE_GET);
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
