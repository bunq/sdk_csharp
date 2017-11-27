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
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account-bank";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account-bank/{1}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account-bank/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account-bank";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_OVERDRAFT_LIMIT = "overdraft_limit";
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_SHARE = "share";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
        public const string FIELD_SETTING = "setting";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "MonetaryAccountBank";
    
        /// <summary>
        /// The id of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the MonetaryAccountBank's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the MonetaryAccountBank's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The Avatar of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; private set; }
    
        /// <summary>
        /// The currency of the MonetaryAccountBank as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; private set; }
    
        /// <summary>
        /// The description of the MonetaryAccountBank. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountBank. Defaults to 1000 EUR. Currency must match the
        /// MonetaryAccountBank's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public Amount DailyLimit { get; private set; }
    
        /// <summary>
        /// Total Amount of money spent today. Timezone aware.
        /// </summary>
        [JsonProperty(PropertyName = "daily_spent")]
        public Amount DailySpent { get; private set; }
    
        /// <summary>
        /// The maximum Amount the MonetaryAccountBank can be 'in the red'.
        /// </summary>
        [JsonProperty(PropertyName = "overdraft_limit")]
        public Amount OverdraftLimit { get; private set; }
    
        /// <summary>
        /// The current balance Amount of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; private set; }
    
        /// <summary>
        /// The Aliases for the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; private set; }
    
        /// <summary>
        /// The MonetaryAccountBank's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; private set; }
    
        /// <summary>
        /// The status of the MonetaryAccountBank. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The sub-status of the MonetaryAccountBank providing extra information regarding the status. Will be NONE for
        /// ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; private set; }
    
        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccountBank, can only be OTHER.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; private set; }
    
        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountBank. Can be any user
        /// provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; private set; }
    
        /// <summary>
        /// The id of the User who owns the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; private set; }
    
        /// <summary>
        /// The profile of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public MonetaryAccountProfile MonetaryAccountProfile { get; private set; }
    
        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this
        /// MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; private set; }
    
        /// <summary>
        /// The settings of the MonetaryAccountBank.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; private set; }
    
        /// <summary>
        /// Create new MonetaryAccountBank.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get a specific MonetaryAccountBank.
        /// </summary>
        public static BunqResponse<MonetaryAccountBank> Get(ApiContext apiContext, int userId, int monetaryAccountBankId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountBankId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MonetaryAccountBank>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Update a specific existing MonetaryAccountBank.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountBankId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountBankId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Gets a listing of all MonetaryAccountBanks of a given user.
        /// </summary>
        public static BunqResponse<List<MonetaryAccountBank>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), urlParams, customHeaders);
    
            return FromJsonList<MonetaryAccountBank>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
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
    }
}
