using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// View for MonetaryAccountSwitchService
    /// </summary>
    public class MonetaryAccountSwitchServiceApiObject : BunqModel
    {
        /// <summary>
        /// The id of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp of the monetary account's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The description for the bank account.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The status of the account.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The sub-status of the account.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }
        /// <summary>
        /// The aliases for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<PointerObject> Alias { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public AmountObject Balance { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount, converted to the user's default currency.
        /// </summary>
        [JsonProperty(PropertyName = "balance_converted")]
        public AmountObject BalanceConverted { get; set; }
        /// <summary>
        /// The profiles of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public List<MonetaryAccountProfileApiObject> MonetaryAccountProfile { get; set; }
        /// <summary>
        /// The settings of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSettingObject Setting { get; set; }
        /// <summary>
        /// The budgets of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "budget")]
        public List<MonetaryAccountBudgetApiObject> Budget { get; set; }
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
        /// The ShareInviteBankResponse when the MonetaryAccount is accessed by the User via a share/connect.
        /// </summary>
        [JsonProperty(PropertyName = "share")]
        public ShareInviteMonetaryAccountResponseApiObject Share { get; set; }
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
        /// The RelationUser when the MonetaryAccount is accessed by the User via a share/connect.
        /// </summary>
        [JsonProperty(PropertyName = "relation_user")]
        public RelationUserApiObject RelationUser { get; set; }
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
    
            if (this.Description != null)
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
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Balance != null)
            {
                return false;
            }
    
            if (this.BalanceConverted != null)
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
    
            if (this.Budget != null)
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
    
            if (this.AllAutoSaveId != null)
            {
                return false;
            }
    
            if (this.Fulfillments != null)
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
    
            if (this.CoOwnerInvite != null)
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
        public static MonetaryAccountSwitchServiceApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountSwitchServiceApiObject>(json);
        }
    }
}
