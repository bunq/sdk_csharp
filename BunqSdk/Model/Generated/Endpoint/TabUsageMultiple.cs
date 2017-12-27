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
    /// TabUsageMultiple is a Tab that can be paid by multiple users. Just like the TabUsageSingle it is created with
    /// the status OPEN, the visibility can be defined in the visibility object and TabItems can be added as long as the
    /// status is OPEN. When you change the status to PAYABLE any bunq user can use the tab to make a payment to your
    /// account. After an user has paid your TabUsageMultiple the status will not change, it will stay PAYABLE. For
    /// example: you can create a TabUsageMultiple with require_address set to true. Now show the QR code of this Tab on
    /// your webshop, and any bunq user can instantly pay and order something from your webshop.
    /// </summary>
    public class TabUsageMultiple : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple";
        private const string EndpointUrlUpdate = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";
        private const string EndpointUrlDelete = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";
        private const string EndpointUrlRead = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldDescription = "description";
        public const string FieldStatus = "status";
        public const string FieldAmountTotal = "amount_total";
        public const string FieldAllowAmountHigher = "allow_amount_higher";
        public const string FieldAllowAmountLower = "allow_amount_lower";
        public const string FieldWantTip = "want_tip";
        public const string FieldMinimumAge = "minimum_age";
        public const string FieldRequireAddress = "require_address";
        public const string FieldRedirectUrl = "redirect_url";
        public const string FieldVisibility = "visibility";
        public const string FieldExpiration = "expiration";
        public const string FieldTabAttachment = "tab_attachment";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "TabUsageMultiple";
    
        /// <summary>
        /// The uuid of the created TabUsageMultiple.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; private set; }
    
        /// <summary>
        /// The timestamp of the Tab's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the Tab's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The description of the TabUsageMultiple. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The status of the Tab. Can be OPEN, PAYABLE or CLOSED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The total amount of the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public Amount AmountTotal { get; private set; }
    
        /// <summary>
        /// The token used to redirect mobile devices directly to the bunq app. Because they can't scan a QR code.
        /// </summary>
        [JsonProperty(PropertyName = "qr_code_token")]
        public string QrCodeToken { get; private set; }
    
        /// <summary>
        /// The URL redirecting user to the tab payment in the bunq app. Only works on mobile devices.
        /// </summary>
        [JsonProperty(PropertyName = "tab_url")]
        public string TabUrl { get; private set; }
    
        /// <summary>
        /// The visibility of a Tab. A Tab can be visible trough NearPay, the QR code of the CashRegister and its own QR
        /// code.
        /// </summary>
        [JsonProperty(PropertyName = "visibility")]
        public TabVisibility Visibility { get; private set; }
    
        /// <summary>
        /// The minimum age of the user paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public bool? MinimumAge { get; private set; }
    
        /// <summary>
        /// Whether or not an billing and shipping address must be provided when paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; private set; }
    
        /// <summary>
        /// The URL which the user is sent to after paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }
    
        /// <summary>
        /// The moment when this Tab expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; private set; }
    
        /// <summary>
        /// The alias of the party that owns this tab.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The location of the cash register that created this tab.
        /// </summary>
        [JsonProperty(PropertyName = "cash_register_location")]
        public Geolocation CashRegisterLocation { get; private set; }
    
        /// <summary>
        /// The tab items of this tab.
        /// </summary>
        [JsonProperty(PropertyName = "tab_item")]
        public List<TabItem> TabItem { get; private set; }
    
        /// <summary>
        /// An array of attachments that describe the tab. Viewable through the GET
        /// /tab/{tabid}/attachment/{attachmentid}/content endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<BunqId> TabAttachment { get; private set; }
    
        /// <summary>
        /// Create a TabUsageMultiple. On creation the status must be set to OPEN
        /// </summary>
        public static BunqResponse<string> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, monetaryAccountId, cashRegisterId), requestBytes, customHeaders);
    
            return ProcessForUuid(responseRaw);
        }
    
        /// <summary>
        /// Modify a specific TabUsageMultiple. You can change the amount_total, status and visibility. Once you change
        /// the status to PAYABLE the TabUsageMultiple will expire after a year (default). If you've created any
        /// TabItems for a Tab the sum of the amounts of these items must be equal to the total_amount of the Tab when
        /// you change its status to PAYABLE.
        /// </summary>
        public static BunqResponse<string> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, string tabUsageMultipleUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, monetaryAccountId, cashRegisterId, tabUsageMultipleUuid), requestBytes, customHeaders);
    
            return ProcessForUuid(responseRaw);
        }
    
        /// <summary>
        /// Close a specific TabUsageMultiple. This request returns an empty response.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUsageMultipleUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(EndpointUrlDelete, userId, monetaryAccountId, cashRegisterId, tabUsageMultipleUuid), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// Get a specific TabUsageMultiple.
        /// </summary>
        public static BunqResponse<TabUsageMultiple> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, string tabUsageMultipleUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, monetaryAccountId, cashRegisterId, tabUsageMultipleUuid), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabUsageMultiple>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get a collection of TabUsageMultiple.
        /// </summary>
        public static BunqResponse<List<TabUsageMultiple>> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId, cashRegisterId), urlParams, customHeaders);
    
            return FromJsonList<TabUsageMultiple>(responseRaw, ObjectType);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.AmountTotal != null)
            {
                return false;
            }
    
            if (this.QrCodeToken != null)
            {
                return false;
            }
    
            if (this.TabUrl != null)
            {
                return false;
            }
    
            if (this.Visibility != null)
            {
                return false;
            }
    
            if (this.MinimumAge != null)
            {
                return false;
            }
    
            if (this.RequireAddress != null)
            {
                return false;
            }
    
            if (this.RedirectUrl != null)
            {
                return false;
            }
    
            if (this.Expiration != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CashRegisterLocation != null)
            {
                return false;
            }
    
            if (this.TabItem != null)
            {
                return false;
            }
    
            if (this.TabAttachment != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TabUsageMultiple CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabUsageMultiple>(json);
        }
    }
}
