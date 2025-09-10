using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for managing investment monetary accounts.
    /// </summary>
    public class MonetaryAccountInvestmentApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_PROVIDER = "provider";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_DISPLAY_NAME = "display_name";
        public const string FIELD_SETTING = "setting";
        public const string FIELD_BIRDEE_INVESTMENT_PORTFOLIO = "birdee_investment_portfolio";
        public const string FIELD_MONETARY_ACCOUNT_DEPOSIT_INITIAL_ID = "monetary_account_deposit_initial_id";
        public const string FIELD_AMOUNT_DEPOSIT_INITIAL = "amount_deposit_initial";
    
    
        /// <summary>
        /// The currency of the MonetaryAccountInvestment as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The provider of the investment service.
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }
        /// <summary>
        /// The description of the MonetaryAccountInvestment. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountInvestment. Defaults to 1000 EUR. Currency must match
        /// the MonetaryAccountInvestment's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public AmountObject DailyLimit { get; set; }
        /// <summary>
        /// The UUID of the Avatar of the MonetaryAccountInvestment.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }
        /// <summary>
        /// The status of the MonetaryAccountInvestment. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The sub-status of the MonetaryAccountInvestment providing extra information regarding the status. Will be
        /// NONE for ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and
        /// REDEMPTION_INVOLUNTARY, REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
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
        /// The legal name of the user / company using this monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// The settings of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSettingObject Setting { get; set; }
        /// <summary>
        /// The Birdee investment portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "birdee_investment_portfolio")]
        public BirdeeInvestmentPortfolioApiObject BirdeeInvestmentPortfolio { get; set; }
        /// <summary>
        /// ID of the MA to be used for the initial deposit to the investment account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_deposit_initial_id")]
        public long? MonetaryAccountDepositInitialId { get; set; }
        /// <summary>
        /// The amount to be transferred to the investment account as the initial deposit.
        /// </summary>
        [JsonProperty(PropertyName = "amount_deposit_initial")]
        public AmountObject AmountDepositInitial { get; set; }
        /// <summary>
        /// The id of the MonetaryAccountInvestment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp of the MonetaryAccountInvestment's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the MonetaryAccountInvestment's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The Avatar of the MonetaryAccountInvestment.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public AvatarObject Avatar { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public AmountObject Balance { get; set; }
        /// <summary>
        /// The aliases for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<PointerObject> Alias { get; set; }
        /// <summary>
        /// The MonetaryAccountInvestment's public UUID.
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
        /// The id of the User who owns the MonetaryAccountInvestment.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// The profiles of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public MonetaryAccountProfileApiObject MonetaryAccountProfile { get; set; }
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
        /// The users the account will be joint with.
        /// </summary>
        [JsonProperty(PropertyName = "all_co_owner")]
        public List<CoOwnerObject> AllCoOwner { get; set; }
        /// <summary>
        /// The CoOwnerInvite when the MonetaryAccount is accessed by the User via a CoOwnerInvite.
        /// </summary>
        [JsonProperty(PropertyName = "co_owner_invite")]
        public CoOwnerInviteResponseApiObject CoOwnerInvite { get; set; }
        /// <summary>
        /// The open banking account for information about the external account.
        /// </summary>
        [JsonProperty(PropertyName = "open_banking_account")]
        public OpenBankingAccountApiObject OpenBankingAccount { get; set; }
        /// <summary>
        /// The access of this Monetary Account.
        /// </summary>
        [JsonProperty(PropertyName = "all_access")]
        public List<MonetaryAccountAccessApiObject> AllAccess { get; set; }
    
    
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
    
            if (this.Fulfillments != null)
            {
                return false;
            }
    
            if (this.BirdeeInvestmentPortfolio != null)
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
    
            if (this.AllCoOwner != null)
            {
                return false;
            }
    
            if (this.CoOwnerInvite != null)
            {
                return false;
            }
    
            if (this.OpenBankingAccount != null)
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
        public static MonetaryAccountInvestmentApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountInvestmentApiObject>(json);
        }
    }
}
