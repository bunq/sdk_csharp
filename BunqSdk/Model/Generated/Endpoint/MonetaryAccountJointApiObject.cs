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
    /// The endpoint for joint monetary accounts.
    /// </summary>
    public class MonetaryAccountJointApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account-joint";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account-joint/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account-joint/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account-joint";
    
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
        public const string FIELD_ALL_CO_OWNER = "all_co_owner";
        public const string FIELD_SETTING = "setting";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MonetaryAccountJoint";
    
        /// <summary>
        /// The currency of the MonetaryAccountJoint as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The description of the MonetaryAccountJoint. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountJoint. Defaults to 1000 EUR. Currency must match the
        /// MonetaryAccountJoint's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public AmountObject DailyLimit { get; set; }
        /// <summary>
        /// The maximum Amount the MonetaryAccountJoint can be 'in the red'.
        /// </summary>
        [JsonProperty(PropertyName = "overdraft_limit")]
        public AmountObject OverdraftLimit { get; set; }
        /// <summary>
        /// The aliases for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<PointerObject> Alias { get; set; }
        /// <summary>
        /// The UUID of the Avatar of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }
        /// <summary>
        /// The status of the MonetaryAccountJoint. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The sub-status of the MonetaryAccountJoint providing extra information regarding the status. Will be NONE
        /// for ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }
        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccount. Can be any user
        /// provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }
        /// <summary>
        /// The users the account will be joint with.
        /// </summary>
        [JsonProperty(PropertyName = "all_co_owner")]
        public List<CoOwnerObject> AllCoOwner { get; set; }
        /// <summary>
        /// The settings of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSettingObject Setting { get; set; }
        /// <summary>
        /// The id of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp of the MonetaryAccountJoint's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the MonetaryAccountJoint's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The Avatar of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public AvatarObject Avatar { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public AmountObject Balance { get; set; }
        /// <summary>
        /// The MonetaryAccountJoint's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }
        /// <summary>
        /// The ShareInviteBankResponse when the MonetaryAccount is accessed by the User via a share/connect.
        /// </summary>
        [JsonProperty(PropertyName = "share")]
        public ShareInviteMonetaryAccountResponseApiObject Share { get; set; }
        /// <summary>
        /// The RelationUser when the MonetaryAccount is accessed by the User via a share/connect.
        /// </summary>
        [JsonProperty(PropertyName = "relation_user")]
        public RelationUserApiObject RelationUser { get; set; }
        /// <summary>
        /// The id of the User who owns the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// The profiles of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public List<MonetaryAccountProfileApiObject> MonetaryAccountProfile { get; set; }
        /// <summary>
        /// The ids of the AutoSave.
        /// </summary>
        [JsonProperty(PropertyName = "all_auto_save_id")]
        public List<BunqIdObject> AllAutoSaveId { get; set; }
        /// <summary>
        /// The fulfillments for this MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "fulfillments")]
        public List<FulfillmentApiObject> Fulfillments { get; set; }
        /// <summary>
        /// The CoOwnerInvite when the MonetaryAccount is accessed by the User via a CoOwnerInvite.
        /// </summary>
        [JsonProperty(PropertyName = "co_owner_invite")]
        public CoOwnerInviteResponseApiObject CoOwnerInvite { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount, converted to the user's default currency.
        /// </summary>
        [JsonProperty(PropertyName = "balance_converted")]
        public AmountObject BalanceConverted { get; set; }
        /// <summary>
        /// The budgets of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "budget")]
        public List<MonetaryAccountBudgetApiObject> Budget { get; set; }
        /// <summary>
        /// The open banking account for information about the external account.
        /// </summary>
        [JsonProperty(PropertyName = "open_banking_account")]
        public OpenBankingAccountApiObject OpenBankingAccount { get; set; }
        /// <summary>
        /// The Birdee investment portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "birdee_investment_portfolio")]
        public BirdeeInvestmentPortfolioApiObject BirdeeInvestmentPortfolio { get; set; }
        /// <summary>
        /// The access of this Monetary Account.
        /// </summary>
        [JsonProperty(PropertyName = "all_access")]
        public List<MonetaryAccountAccessApiObject> AllAccess { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="currency">The currency of the MonetaryAccountJoint as an ISO 4217 formatted currency code.</param>
        /// <param name="allCoOwner">The users the account will be joint with.</param>
        /// <param name="description">The description of the MonetaryAccountJoint. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountJoint. Defaults to 1000 EUR. Currency must match the MonetaryAccountJoint's currency. Limited to 10000 EUR.</param>
        /// <param name="overdraftLimit">The maximum Amount the MonetaryAccountJoint can be 'in the red'. Must be 0 EUR or omitted.</param>
        /// <param name="alias">The Aliases to add to MonetaryAccountJoint. Must all be confirmed first. Can mostly be ignored.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountJoint.</param>
        /// <param name="status">The status of the MonetaryAccountJoint. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountJoint. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountJoint providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountJoint, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountJoint. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="setting">The settings of the MonetaryAccountJoint.</param>
        public static BunqResponse<long> Create(string currency, List<CoOwnerObject> allCoOwner, string description = null, AmountObject dailyLimit = null, AmountObject overdraftLimit = null, List<PointerObject> alias = null, string avatarUuid = null, string status = null, string subStatus = null, string reason = null, string reasonDescription = null, MonetaryAccountSettingObject setting = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_CURRENCY, currency},
    {FIELD_DESCRIPTION, description},
    {FIELD_DAILY_LIMIT, dailyLimit},
    {FIELD_OVERDRAFT_LIMIT, overdraftLimit},
    {FIELD_ALIAS, alias},
    {FIELD_AVATAR_UUID, avatarUuid},
    {FIELD_STATUS, status},
    {FIELD_SUB_STATUS, subStatus},
    {FIELD_REASON, reason},
    {FIELD_REASON_DESCRIPTION, reasonDescription},
    {FIELD_ALL_CO_OWNER, allCoOwner},
    {FIELD_SETTING, setting},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<MonetaryAccountJointApiObject> Get(long monetaryAccountJointId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), monetaryAccountJointId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MonetaryAccountJointApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="description">The description of the MonetaryAccountJoint. Defaults to 'bunq account'.</param>
        /// <param name="dailyLimit">The daily spending limit Amount of the MonetaryAccountJoint. Defaults to 1000 EUR. Currency must match the MonetaryAccountJoint's currency. Limited to 10000 EUR.</param>
        /// <param name="avatarUuid">The UUID of the Avatar of the MonetaryAccountJoint.</param>
        /// <param name="status">The status of the MonetaryAccountJoint. Ignored in POST requests (always set to ACTIVE) can be CANCELLED or PENDING_REOPEN in PUT requests to cancel (close) or reopen the MonetaryAccountJoint. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="subStatus">The sub-status of the MonetaryAccountJoint providing extra information regarding the status. Should be ignored for POST requests. In case of PUT requests with status CANCELLED it can only be REDEMPTION_VOLUNTARY, while with status PENDING_REOPEN it can only be NONE. When updating the status and/or sub_status no other fields can be updated in the same request (and vice versa).</param>
        /// <param name="reason">The reason for voluntarily cancelling (closing) the MonetaryAccountJoint, can only be OTHER. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="reasonDescription">The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountJoint. Can be any user provided message. Should only be specified if updating the status to CANCELLED.</param>
        /// <param name="setting">The settings of the MonetaryAccountJoint.</param>
        public static BunqResponse<long> Update(long monetaryAccountJointId, string description = null, AmountObject dailyLimit = null, string avatarUuid = null, string status = null, string subStatus = null, string reason = null, string reasonDescription = null, MonetaryAccountSettingObject setting = null, IDictionary<string, string> customHeaders = null)
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
    {FIELD_SETTING, setting},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), monetaryAccountJointId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<MonetaryAccountJointApiObject>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<MonetaryAccountJointApiObject>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.Share != null)
            {
                return false;
            }
    
            if (this.RelationUser != null)
            {
                return false;
            }
    
            if (this.AllCoOwner != null)
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
    
            if (this.Setting != null)
            {
                return false;
            }
    
            if (this.AllAutoSaveId != null)
            {
                return false;
            }
    
            if (this.Fulfillments != null)
            {
                return false;
            }
    
            if (this.CoOwnerInvite != null)
            {
                return false;
            }
    
            if (this.BalanceConverted != null)
            {
                return false;
            }
    
            if (this.Budget != null)
            {
                return false;
            }
    
            if (this.OpenBankingAccount != null)
            {
                return false;
            }
    
            if (this.BirdeeInvestmentPortfolio != null)
            {
                return false;
            }
    
            if (this.AllAccess != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccountJointApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountJointApiObject>(json);
        }
    }
}
