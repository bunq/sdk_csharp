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
    /// MasterCard transaction view.
    /// </summary>
    public class MasterCardAction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/mastercard-action/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/mastercard-action";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "MasterCardAction";
    
        /// <summary>
        /// The id of the monetary account this action links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The id of the card this action links to.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public int? CardId { get; private set; }
    
        /// <summary>
        /// The amount of the transaction in local currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_local")]
        public Amount AmountLocal { get; private set; }
    
        /// <summary>
        /// The amount of the transaction in the monetary account's currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_billing")]
        public Amount AmountBilling { get; private set; }
    
        /// <summary>
        /// The original amount in local currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_original_local")]
        public Amount AmountOriginalLocal { get; private set; }
    
        /// <summary>
        /// The original amount in the monetary account's currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_original_billing")]
        public Amount AmountOriginalBilling { get; private set; }
    
        /// <summary>
        /// The fee amount as charged by the merchant, if applicable.
        /// </summary>
        [JsonProperty(PropertyName = "amount_fee")]
        public Amount AmountFee { get; private set; }
    
        /// <summary>
        /// Why the transaction was denied, if it was denied, or just ALLOWED.
        /// </summary>
        [JsonProperty(PropertyName = "decision")]
        public string Decision { get; private set; }
    
        /// <summary>
        /// Empty if allowed, otherwise a textual explanation of why it was denied.
        /// </summary>
        [JsonProperty(PropertyName = "decision_description")]
        public string DecisionDescription { get; private set; }
    
        /// <summary>
        /// Empty if allowed, otherwise a textual explanation of why it was denied in user's language.
        /// </summary>
        [JsonProperty(PropertyName = "decision_description_translated")]
        public string DecisionDescriptionTranslated { get; private set; }
    
        /// <summary>
        /// The description for this transaction to display.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The status in the authorisation process.
        /// </summary>
        [JsonProperty(PropertyName = "authorisation_status")]
        public string AuthorisationStatus { get; private set; }
    
        /// <summary>
        /// The type of transaction that was delivered using the card.
        /// </summary>
        [JsonProperty(PropertyName = "authorisation_type")]
        public string AuthorisationType { get; private set; }
    
        /// <summary>
        /// The type of entry mode the user used. Can be 'ATM', 'ICC', 'MAGNETIC_STRIPE' or 'E_COMMERCE'.
        /// </summary>
        [JsonProperty(PropertyName = "pan_entry_mode_user")]
        public string PanEntryModeUser { get; private set; }
    
        /// <summary>
        /// The city where the message originates from as announced by the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; private set; }
    
        /// <summary>
        /// The monetary account label of the account that this action is created for.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The monetary account label of the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }
    
        /// <summary>
        /// The label of the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_card")]
        public LabelCard LabelCard { get; private set; }
    
        /// <summary>
        /// If this is a tokenisation action, this shows the status of the token.
        /// </summary>
        [JsonProperty(PropertyName = "token_status")]
        public string TokenStatus { get; private set; }
    
        /// <summary>
        /// If this is a reservation, the moment the reservation will expire.
        /// </summary>
        [JsonProperty(PropertyName = "reservation_expiry_time")]
        public string ReservationExpiryTime { get; private set; }
    
        /// <summary>
        /// The type of the limit applied to validate if this MasterCardAction was within the spending limits. The
        /// returned string matches the limit types as defined in the card endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "applied_limit")]
        public string AppliedLimit { get; private set; }
    
        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; private set; }
    
        /// <summary>
        /// The whitelist id for this mastercard action or null.
        /// </summary>
        [JsonProperty(PropertyName = "eligible_whitelist_id")]
        public int? EligibleWhitelistId { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<MasterCardAction> Get(ApiContext apiContext, int userId, int monetaryAccountId, int masterCardActionId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, masterCardActionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MasterCardAction>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<MasterCardAction>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<MasterCardAction>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.CardId != null)
            {
                return false;
            }
    
            if (this.AmountLocal != null)
            {
                return false;
            }
    
            if (this.AmountBilling != null)
            {
                return false;
            }
    
            if (this.AmountOriginalLocal != null)
            {
                return false;
            }
    
            if (this.AmountOriginalBilling != null)
            {
                return false;
            }
    
            if (this.AmountFee != null)
            {
                return false;
            }
    
            if (this.Decision != null)
            {
                return false;
            }
    
            if (this.DecisionDescription != null)
            {
                return false;
            }
    
            if (this.DecisionDescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.AuthorisationStatus != null)
            {
                return false;
            }
    
            if (this.AuthorisationType != null)
            {
                return false;
            }
    
            if (this.PanEntryModeUser != null)
            {
                return false;
            }
    
            if (this.City != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.LabelCard != null)
            {
                return false;
            }
    
            if (this.TokenStatus != null)
            {
                return false;
            }
    
            if (this.ReservationExpiryTime != null)
            {
                return false;
            }
    
            if (this.AppliedLimit != null)
            {
                return false;
            }
    
            if (this.AllowChat != null)
            {
                return false;
            }
    
            if (this.EligibleWhitelistId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardAction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardAction>(json);
        }
    }
}
