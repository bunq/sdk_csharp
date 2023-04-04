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
    /// Endpoint for managing monetary accounts which are connected to external services.
    /// </summary>
    public class MonetaryAccountExternal : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account-external";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account-external/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account-external/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account-external";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_SERVICE = "service";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_DISPLAY_NAME = "display_name";
        public const string FIELD_SETTING = "setting";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MonetaryAccountExternal";
    
        /// <summary>
        /// The currency of the MonetaryAccountExternal as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    
        /// <summary>
        /// The service the MonetaryAccountExternal is connected with.
        /// </summary>
        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }
    
        /// <summary>
        /// The description of the MonetaryAccountExternal. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountExternal. Defaults to 1000 EUR. Currency must match
        /// the MonetaryAccountExternal's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public Amount DailyLimit { get; set; }
    
        /// <summary>
        /// The UUID of the Avatar of the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }
    
        /// <summary>
        /// The status of the MonetaryAccountExternal. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The sub-status of the MonetaryAccountExternal providing extra information regarding the status. Will be NONE
        /// for ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }
    
        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccountExternal, can only be OTHER.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountExternal. Can be any
        /// user provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }
    
        /// <summary>
        /// The legal name of the user / company using this monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
    
        /// <summary>
        /// The settings of the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; set; }
    
        /// <summary>
        /// The id of the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the MonetaryAccountExternal's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the MonetaryAccountExternal's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The Avatar of the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }
    
        /// <summary>
        /// The maximum Amount the MonetaryAccountExternal can be 'in the red'.
        /// </summary>
        [JsonProperty(PropertyName = "overdraft_limit")]
        public Amount OverdraftLimit { get; set; }
    
        /// <summary>
        /// The current available balance Amount of the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }
    
        /// <summary>
        /// The Aliases for the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }
    
        /// <summary>
        /// The MonetaryAccountExternal's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }
    
        /// <summary>
        /// The id of the User who owns the MonetaryAccountExternal.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }
    
        /// <summary>
        /// The profile of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public MonetaryAccountProfile MonetaryAccountProfile { get; set; }
    
        /// <summary>
        /// The ids of the AutoSave.
        /// </summary>
        [JsonProperty(PropertyName = "all_auto_save_id")]
        public List<BunqId> AllAutoSaveId { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="currency">The currency of the MonetaryAccountExternal as an ISO 4217 formatted currency code.</param>
        /// <param name="service">The service the MonetaryAccountExternal is connected with.</param>
        /// <param name="description">The description of the MonetaryAccountExternal. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountExternal. Defaults to 1000 EUR. Currency must match the MonetaryAccountExternal's currency. Limited to 10000 EUR.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountExternal.</param>
        /// <param name="status">The status of the MonetaryAccountExternal. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountExternal. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountExternal providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountExternal, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountExternal. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="displayName">The legal name of the user / company using this monetary account.</param>
        /// <param name="setting">The settings of the MonetaryAccountExternal.</param>
        public static BunqResponse<int> Create(string currency, string service, string description = null, Amount dailyLimit = null, string avatarUuid = null, string status = null, string subStatus = null, string reason = null, string reasonDescription = null, string displayName = null, MonetaryAccountSetting setting = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_CURRENCY, currency},
    {FIELD_SERVICE, service},
    {FIELD_DESCRIPTION, description},
    {FIELD_DAILY_LIMIT, dailyLimit},
    {FIELD_AVATAR_UUID, avatarUuid},
    {FIELD_STATUS, status},
    {FIELD_SUB_STATUS, subStatus},
    {FIELD_REASON, reason},
    {FIELD_REASON_DESCRIPTION, reasonDescription},
    {FIELD_DISPLAY_NAME, displayName},
    {FIELD_SETTING, setting},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<MonetaryAccountExternal> Get(int monetaryAccountExternalId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), monetaryAccountExternalId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MonetaryAccountExternal>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="description">The description of the MonetaryAccountExternal. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountExternal. Defaults to 1000 EUR. Currency must match the MonetaryAccountExternal's currency. Limited to 10000 EUR.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountExternal.</param>
        /// <param name="status">The status of the MonetaryAccountExternal. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountExternal. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountExternal providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountExternal, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountExternal. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="displayName">The legal name of the user / company using this monetary account.</param>
        /// <param name="setting">The settings of the MonetaryAccountExternal.</param>
        public static BunqResponse<int> Update(int monetaryAccountExternalId, string description = null, Amount dailyLimit = null, string avatarUuid = null, string status = null, string subStatus = null, string reason = null, string reasonDescription = null, string displayName = null, MonetaryAccountSetting setting = null, IDictionary<string, string> customHeaders = null)
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
    {FIELD_DISPLAY_NAME, displayName},
    {FIELD_SETTING, setting},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), monetaryAccountExternalId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<MonetaryAccountExternal>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<MonetaryAccountExternal>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.DisplayName != null)
            {
                return false;
            }
    
            if (this.Setting != null)
            {
                return false;
            }
    
            if (this.AllAutoSaveId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccountExternal CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountExternal>(json);
        }
    }
}
