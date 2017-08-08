using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// TabUsageSingle is a Tab that can be paid once. The TabUsageSingle is created with the status OPEN. Optionally
    /// you can add TabItems to the tab using /tab/_/tab-item, TabItems don't affect the total amount of the Tab.
    /// However, if you've created any TabItems for a Tab the sum of the amounts of these items must be equal to the
    /// total_amount of the Tab when you change its status to WAITING_FOR_PAYMENT. By setting the visibility object a
    /// TabUsageSingle with the status OPEN or WAITING_FOR_PAYMENT can be made visible to customers. As soon as a
    /// customer pays the TabUsageSingle its status changes to PAID, and it can't be paid again.
    /// </summary>
    public class TabUsageSingle : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_MERCHANT_REFERENCE = "merchant_reference";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_STATUS = "status";
        public const string FIELD_AMOUNT_TOTAL = "amount_total";
        public const string FIELD_ALLOW_AMOUNT_HIGHER = "allow_amount_higher";
        public const string FIELD_ALLOW_AMOUNT_LOWER = "allow_amount_lower";
        public const string FIELD_WANT_TIP = "want_tip";
        public const string FIELD_MINIMUM_AGE = "minimum_age";
        public const string FIELD_REQUIRE_ADDRESS = "require_address";
        public const string FIELD_REDIRECT_URL = "redirect_url";
        public const string FIELD_VISIBILITY = "visibility";
        public const string FIELD_EXPIRATION = "expiration";
        public const string FIELD_TAB_ATTACHMENT = "tab_attachment";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-single";
        private const string ENDPOINT_URL_UPDATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-single/{3}";
        private const string ENDPOINT_URL_DELETE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-single/{3}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-single/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-single";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabUsageSingle";

        /// <summary>
        /// The uuid of the created TabUsageSingle.
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
        /// The merchant reference of the Tab, as defined by the owner.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; private set; }

        /// <summary>
        /// The description of the TabUsageMultiple. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The status of the Tab. Can be OPEN, WAITING_FOR_PAYMENT, PAID or CANCELED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The total amount of the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public Amount AmountTotal { get; private set; }

        /// <summary>
        /// The amount that has been paid for this Tab.
        /// </summary>
        [JsonProperty(PropertyName = "amount_paid")]
        public Amount AmountPaid { get; private set; }

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
        /// An array of attachments that describe the tab. Uploaded through the POST /user/{userid}/attachment-tab
        /// endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<BunqId> TabAttachment { get; private set; }

        public static BunqResponse<string> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, cashRegisterId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a TabUsageSingle. The initial status must be OPEN
        /// </summary>
        public static BunqResponse<string> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, cashRegisterId),
                    requestBytes, customHeaders);

            return ProcessForUuid(responseRaw);
        }

        public static BunqResponse<string> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUsageSingleUuid)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Modify a specific TabUsageSingle. You can change the amount_total, status and visibility. Once you change
        /// the status to WAITING_FOR_PAYMENT the TabUsageSingle will expire after 5 minutes (default) or up to 1 hour
        /// if a different expiration is provided.
        /// </summary>
        public static BunqResponse<string> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUsageSingleUuid,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid),
                    requestBytes, customHeaders);

            return ProcessForUuid(responseRaw);
        }

        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUsageSingleUuid)
        {
            return Delete(apiContext, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Cancel a specific TabUsageSingle. This request returns an empty response.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUsageSingleUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        public static BunqResponse<TabUsageSingle> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUsageSingleUuid)
        {
            return Get(apiContext, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific TabUsageSingle.
        /// </summary>
        public static BunqResponse<TabUsageSingle> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUsageSingleUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId, tabUsageSingleUuid),
                    customHeaders);

            return FromJson<TabUsageSingle>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<TabUsageSingle>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of TabUsageSingle.
        /// </summary>
        public static BunqResponse<List<TabUsageSingle>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId),
                    customHeaders);

            return FromJsonList<TabUsageSingle>(responseRaw, OBJECT_TYPE);
        }
    }
}
