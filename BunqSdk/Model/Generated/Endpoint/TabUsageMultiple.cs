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
        protected const string ENDPOINT_URL_CREATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple";

        protected const string ENDPOINT_URL_UPDATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";

        protected const string ENDPOINT_URL_DELETE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";

        protected const string ENDPOINT_URL_READ =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple/{3}";

        protected const string ENDPOINT_URL_LISTING =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab-usage-multiple";

        /// <summary>
        /// Field constants.
        /// </summary>
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
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "Uuid";

        private const string OBJECT_TYPE_PUT = "Uuid";
        private const string OBJECT_TYPE_GET = "TabUsageMultiple";

        /// <summary>
        /// The uuid of the created TabUsageMultiple.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The timestamp of the Tab's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the Tab's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The description of the TabUsageMultiple. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The status of the Tab. Can be OPEN, PAYABLE or CLOSED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The total amount of the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public Amount AmountTotal { get; set; }

        /// <summary>
        /// The token used to redirect mobile devices directly to the bunq app. Because they can't scan a QR code.
        /// </summary>
        [JsonProperty(PropertyName = "qr_code_token")]
        public string QrCodeToken { get; set; }

        /// <summary>
        /// The URL redirecting user to the tab payment in the bunq app. Only works on mobile devices.
        /// </summary>
        [JsonProperty(PropertyName = "tab_url")]
        public string TabUrl { get; set; }

        /// <summary>
        /// The visibility of a Tab. A Tab can be visible trough NearPay, the QR code of the CashRegister and its own QR
        /// code.
        /// </summary>
        [JsonProperty(PropertyName = "visibility")]
        public TabVisibility Visibility { get; set; }

        /// <summary>
        /// The minimum age of the user paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public bool? MinimumAge { get; set; }

        /// <summary>
        /// Whether or not an billing and shipping address must be provided when paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; set; }

        /// <summary>
        /// The URL which the user is sent to after paying the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The moment when this Tab expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// The alias of the party that owns this tab.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// The location of the cash register that created this tab.
        /// </summary>
        [JsonProperty(PropertyName = "cash_register_location")]
        public Geolocation CashRegisterLocation { get; set; }

        /// <summary>
        /// The tab items of this tab.
        /// </summary>
        [JsonProperty(PropertyName = "tab_item")]
        public List<TabItem> TabItem { get; set; }

        /// <summary>
        /// An array of attachments that describe the tab. Viewable through the GET
        /// /tab/{tabid}/attachment/{attachmentid}/content endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<BunqId> TabAttachment { get; set; }

        /// <summary>
        /// Create a TabUsageMultiple. On creation the status must be set to OPEN
        /// </summary>
        /// <param name="description">The description of the TabUsageMultiple. Maximum 9000 characters. Field is required but can be an empty string.</param>
        /// <param name="status">The status of the TabUsageMultiple. On creation the status must be set to OPEN. You can change the status from OPEN to PAYABLE. If the TabUsageMultiple gets paid the status will remain PAYABLE.</param>
        /// <param name="amountTotal">The total amount of the Tab. Must be a positive amount. As long as the tab has the status OPEN you can change the total amount. This amount is not affected by the amounts of the TabItems. However, if you've created any TabItems for a Tab the sum of the amounts of these items must be equal to the total_amount of the Tab when you change its status to PAYABLE</param>
        /// <param name="allowAmountHigher">[DEPRECATED] Whether or not a higher amount can be paid.</param>
        /// <param name="allowAmountLower">[DEPRECATED] Whether or not a lower amount can be paid.</param>
        /// <param name="wantTip">[DEPRECATED] Whether or not the user paying the Tab should be asked if he wants to give a tip. When want_tip is set to true, allow_amount_higher must also be set to true and allow_amount_lower must be false.</param>
        /// <param name="minimumAge">The minimum age of the user paying the Tab.</param>
        /// <param name="requireAddress">Whether a billing and shipping address must be provided when paying the Tab. Possible values are: BILLING, SHIPPING, BILLING_SHIPPING, NONE, OPTIONAL. Default is NONE.</param>
        /// <param name="redirectUrl">The URL which the user is sent to after paying the Tab.</param>
        /// <param name="visibility">The visibility of a Tab. A Tab can be visible trough NearPay, the QR code of the CashRegister and its own QR code.</param>
        /// <param name="expiration">The moment when this Tab expires. Can be at most 365 days into the future.</param>
        /// <param name="tabAttachment">An array of attachments that describe the tab. Uploaded through the POST /user/{userid}/attachment-tab endpoint.</param>
        public static BunqResponse<string> Create(int cashRegisterId, string description, string status,
            Amount amountTotal, int? monetaryAccountId = null, bool? allowAmountHigher = null,
            bool? allowAmountLower = null, bool? wantTip = null, int? minimumAge = null, string requireAddress = null,
            string redirectUrl = null, TabVisibility visibility = null, string expiration = null,
            List<BunqId> tabAttachment = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_DESCRIPTION, description},
                {FIELD_STATUS, status},
                {FIELD_AMOUNT_TOTAL, amountTotal},
                {FIELD_ALLOW_AMOUNT_HIGHER, allowAmountHigher},
                {FIELD_ALLOW_AMOUNT_LOWER, allowAmountLower},
                {FIELD_WANT_TIP, wantTip},
                {FIELD_MINIMUM_AGE, minimumAge},
                {FIELD_REQUIRE_ADDRESS, requireAddress},
                {FIELD_REDIRECT_URL, redirectUrl},
                {FIELD_VISIBILITY, visibility},
                {FIELD_EXPIRATION, expiration},
                {FIELD_TAB_ATTACHMENT, tabAttachment},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId), requestBytes, customHeaders);

            return ProcessForUuid(responseRaw);
        }

        /// <summary>
        /// Modify a specific TabUsageMultiple. You can change the amount_total, status and visibility. Once you change
        /// the status to PAYABLE the TabUsageMultiple will expire after a year (default). If you've created any
        /// TabItems for a Tab the sum of the amounts of these items must be equal to the total_amount of the Tab when
        /// you change its status to PAYABLE.
        /// </summary>
        /// <param name="status">The status of the TabUsageMultiple. On creation the status must be set to OPEN. You can change the status from OPEN to PAYABLE. If the TabUsageMultiple gets paid the status will remain PAYABLE.</param>
        /// <param name="amountTotal">The total amount of the Tab. Must be a positive amount. As long as the tab has the status OPEN you can change the total amount. This amount is not affected by the amounts of the TabItems. However, if you've created any TabItems for a Tab the sum of the amounts of these items must be equal to the total_amount of the Tab when you change its status to PAYABLE</param>
        /// <param name="visibility">The visibility of a Tab. A Tab can be visible trough NearPay, the QR code of the CashRegister and its own QR code.</param>
        /// <param name="expiration">The moment when this Tab expires. Can be at most 365 days into the future.</param>
        /// <param name="tabAttachment">An array of attachments that describe the tab. Uploaded through the POST /user/{userid}/attachment-tab endpoint.</param>
        public static BunqResponse<string> Update(int cashRegisterId, string tabUsageMultipleUuid,
            int? monetaryAccountId = null, string status = null, Amount amountTotal = null,
            TabVisibility visibility = null, string expiration = null, List<BunqId> tabAttachment = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_AMOUNT_TOTAL, amountTotal},
                {FIELD_VISIBILITY, visibility},
                {FIELD_EXPIRATION, expiration},
                {FIELD_TAB_ATTACHMENT, tabAttachment},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, tabUsageMultipleUuid), requestBytes, customHeaders);

            return ProcessForUuid(responseRaw);
        }

        /// <summary>
        /// Close a specific TabUsageMultiple.
        /// </summary>
        public static BunqResponse<object> Delete(int cashRegisterId, string tabUsageMultipleUuid,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, tabUsageMultipleUuid), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// Get a specific TabUsageMultiple.
        /// </summary>
        public static BunqResponse<TabUsageMultiple> Get(int cashRegisterId, string tabUsageMultipleUuid,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, tabUsageMultipleUuid), new Dictionary<string, string>(), customHeaders);

            return FromJson<TabUsageMultiple>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a collection of TabUsageMultiple.
        /// </summary>
        public static BunqResponse<List<TabUsageMultiple>> List(int cashRegisterId, int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId), urlParams, customHeaders);

            return FromJsonList<TabUsageMultiple>(responseRaw, OBJECT_TYPE_GET);
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