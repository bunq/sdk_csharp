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
    /// With MonetaryAccountBank you can create a new bank account, retrieve information regarding your existing
    /// MonetaryAccountBanks and update specific fields of an existing MonetaryAccountBank. Examples of fields that can
    /// be updated are the description, the daily limit and the avatar of the account.<br/><br/>Notification filters can
    /// be set on a monetary account level to receive callbacks. For more information check the <a
    /// href="/api/1/page/callbacks">dedicated callbacks page</a>.
    /// </summary>
    public class MonetaryAccountBank : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account-bank";

        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account-bank/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account-bank/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account-bank";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";

        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
        public const string FIELD_SETTING = "setting";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MonetaryAccountBank";

        /// <summary>
        /// The currency of the MonetaryAccountBank as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The description of the MonetaryAccountBank. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountBank. Defaults to 1000 EUR. Currency must match the
        /// MonetaryAccountBank's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public Amount DailyLimit { get; set; }

        /// <summary>
        /// The UUID of the Avatar of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }

        /// <summary>
        /// The status of the MonetaryAccountBank. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sub-status of the MonetaryAccountBank providing extra information regarding the status. Will be NONE for
        /// ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccountBank, can only be OTHER.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountBank. Can be any user
        /// provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }

        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this
        /// MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; set; }

        /// <summary>
        /// The settings of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; set; }

        /// <summary>
        /// The id of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountBank's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountBank's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The Avatar of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        /// Total Amount of money spent today. Timezone aware.
        /// </summary>
        [JsonProperty(PropertyName = "daily_spent")]
        public Amount DailySpent { get; set; }

        /// <summary>
        /// The maximum Amount the MonetaryAccountBank can be 'in the red'.
        /// </summary>
        [JsonProperty(PropertyName = "overdraft_limit")]
        public Amount OverdraftLimit { get; set; }

        /// <summary>
        /// The current balance Amount of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }

        /// <summary>
        /// The Aliases for the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }

        /// <summary>
        /// The MonetaryAccountBank's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The id of the User who owns the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// The profile of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public MonetaryAccountProfile MonetaryAccountProfile { get; set; }

        /// <summary>
        /// Create new MonetaryAccountBank.
        /// </summary>
        /// <param name="currency">The currency of the MonetaryAccountBank as an ISO 4217 formatted currency code.</param>
        /// <param name="description">The description of the MonetaryAccountBank. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountBank. Defaults to 1000 EUR. Currency must match the MonetaryAccountBank's currency. Limited to 10000 EUR.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountBank.</param>
        /// <param name="status">The status of the MonetaryAccountBank. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountBank. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountBank providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountBank, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountBank. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="notificationFilters">The types of notifications that will result in a push notification or URL callback for this MonetaryAccountBank.</param>
        /// <param name="setting">The settings of the MonetaryAccountBank.</param>
        public static BunqResponse<int> Create(string currency, string description = null, Amount dailyLimit = null,
            string avatarUuid = null, string status = null, string subStatus = null, string reason = null,
            string reasonDescription = null, List<NotificationFilter> notificationFilters = null,
            MonetaryAccountSetting setting = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_CURRENCY, currency},
                {FIELD_DESCRIPTION, description},
                {FIELD_DAILY_LIMIT, dailyLimit},
                {FIELD_AVATAR_UUID, avatarUuid},
                {FIELD_STATUS, status},
                {FIELD_SUB_STATUS, subStatus},
                {FIELD_REASON, reason},
                {FIELD_REASON_DESCRIPTION, reasonDescription},
                {FIELD_NOTIFICATION_FILTERS, notificationFilters},
                {FIELD_SETTING, setting},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get a specific MonetaryAccountBank.
        /// </summary>
        public static BunqResponse<MonetaryAccountBank> Get(int monetaryAccountBankId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), monetaryAccountBankId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<MonetaryAccountBank>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Update a specific existing MonetaryAccountBank.
        /// </summary>
        /// <param name="description">The description of the MonetaryAccountBank. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountBank. Defaults to 1000 EUR. Currency must match the MonetaryAccountBank's currency. Limited to 10000 EUR.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountBank.</param>
        /// <param name="status">The status of the MonetaryAccountBank. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountBank. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountBank providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountBank, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountBank. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="notificationFilters">The types of notifications that will result in a push notification or URL callback for this MonetaryAccountBank.</param>
        /// <param name="setting">The settings of the MonetaryAccountBank.</param>
        public static BunqResponse<int> Update(int monetaryAccountBankId, string description = null,
            Amount dailyLimit = null, string avatarUuid = null, string status = null, string subStatus = null,
            string reason = null, string reasonDescription = null, List<NotificationFilter> notificationFilters = null,
            MonetaryAccountSetting setting = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_DESCRIPTION, description},
                {FIELD_DAILY_LIMIT, dailyLimit},
                {FIELD_AVATAR_UUID, avatarUuid},
                {FIELD_STATUS, status},
                {FIELD_SUB_STATUS, subStatus},
                {FIELD_REASON, reason},
                {FIELD_REASON_DESCRIPTION, reasonDescription},
                {FIELD_NOTIFICATION_FILTERS, notificationFilters},
                {FIELD_SETTING, setting},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), monetaryAccountBankId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Gets a listing of all MonetaryAccountBanks of a given user.
        /// </summary>
        public static BunqResponse<List<MonetaryAccountBank>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<MonetaryAccountBank>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
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

            if (this.Avatar != null)
            {
                return false;
            }

            if (this.Currency != null)
            {
                return false;
            }

            if (this.Description != null)
            {
                return false;
            }

            if (this.DailyLimit != null)
            {
                return false;
            }

            if (this.DailySpent != null)
            {
                return false;
            }

            if (this.OverdraftLimit != null)
            {
                return false;
            }

            if (this.Balance != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.PublicUuid != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.Reason != null)
            {
                return false;
            }

            if (this.ReasonDescription != null)
            {
                return false;
            }

            if (this.UserId != null)
            {
                return false;
            }

            if (this.MonetaryAccountProfile != null)
            {
                return false;
            }

            if (this.NotificationFilters != null)
            {
                return false;
            }

            if (this.Setting != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static MonetaryAccountBank CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountBank>(json);
        }
    }
}