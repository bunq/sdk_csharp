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
    /// Used to show the MonetaryAccounts that you can access. Currently the only MonetaryAccount type is
    /// MonetaryAccountBank. See also: monetary-account-bank.<br/><br/>Notification filters can be set on a monetary
    /// account level to receive callbacks. For more information check the <a href="/api/2/page/callbacks">dedicated
    /// callbacks page</a>.
    /// </summary>
    public class MonetaryAccount : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MonetaryAccount";
    
        /// <summary>
        /// The aliases for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }
        /// <summary>
        /// The current available balance amount of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }
        /// <summary>
        /// The profiles of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public List<MonetaryAccountProfile> MonetaryAccountProfile { get; set; }
        /// <summary>
        /// The settings of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; set; }
        /// <summary>
        /// The budgets of the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "budget")]
        public List<MonetaryAccountBudget> Budget { get; set; }
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
        public ShareInviteMonetaryAccountResponse Share { get; set; }
        /// <summary>
        /// The ids of the AutoSave.
        /// </summary>
        [JsonProperty(PropertyName = "all_auto_save_id")]
        public List<BunqId> AllAutoSaveId { get; set; }
        /// <summary>
        /// The fulfillments for this MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "fulfillments")]
        public List<Fulfillment> Fulfillments { get; set; }
        /// <summary>
        /// The RelationUser when the MonetaryAccount is accessed by the User via a share/connect.
        /// </summary>
        [JsonProperty(PropertyName = "relation_user")]
        public RelationUser RelationUser { get; set; }
        /// <summary>
        /// The users the account will be joint with.
        /// </summary>
        [JsonProperty(PropertyName = "all_co_owner")]
        public List<CoOwner> AllCoOwner { get; set; }
        /// <summary>
        /// The CoOwnerInvite when the MonetaryAccount is accessed by the User via a CoOwnerInvite.
        /// </summary>
        [JsonProperty(PropertyName = "co_owner_invite")]
        public CoOwnerInviteResponse CoOwnerInvite { get; set; }
        /// <summary>
        /// The open banking account for information about the external account.
        /// </summary>
        [JsonProperty(PropertyName = "open_banking_account")]
        public OpenBankingAccount OpenBankingAccount { get; set; }
        /// <summary>
        /// The Birdee investment portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "birdee_investment_portfolio")]
        public BirdeeInvestmentPortfolio BirdeeInvestmentPortfolio { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountLight")]
        public MonetaryAccountLight MonetaryAccountLight { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountBank")]
        public MonetaryAccountBank MonetaryAccountBank { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountExternal")]
        public MonetaryAccountExternal MonetaryAccountExternal { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountInvestment")]
        public MonetaryAccountInvestment MonetaryAccountInvestment { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountJoint")]
        public MonetaryAccountJoint MonetaryAccountJoint { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountSavings")]
        public MonetaryAccountSavings MonetaryAccountSavings { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountSwitchService")]
        public MonetaryAccountSwitchService MonetaryAccountSwitchService { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountExternalSavings")]
        public MonetaryAccountExternalSavings MonetaryAccountExternalSavings { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountCard")]
        public MonetaryAccountCard MonetaryAccountCard { get; set; }
    
        /// <summary>
        /// Get a specific MonetaryAccount.
        /// </summary>
        public static BunqResponse<MonetaryAccount> Get(int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MonetaryAccount>(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of all your MonetaryAccounts.
        /// </summary>
        public static BunqResponse<List<MonetaryAccount>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<MonetaryAccount>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Balance != null)
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
    
            if (this.MonetaryAccountLight != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountBank != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountExternal != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountInvestment != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountJoint != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountSavings != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountSwitchService != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountExternalSavings != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountCard != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccount CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccount>(json);
        }
    }
}
