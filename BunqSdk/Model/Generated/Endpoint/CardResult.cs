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
    /// Endpoint for Card result requests (failed and successful transactions).
    /// </summary>
    public class CardResult : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/card-result/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/card-result";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CardResult";
    
        /// <summary>
        /// The id of the monetary account this card result links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The id of the card this card result links to.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public int? CardId { get; private set; }
    
        /// <summary>
        /// The original amount of the message.
        /// </summary>
        [JsonProperty(PropertyName = "amount_original")]
        public Amount AmountOriginal { get; private set; }
    
        /// <summary>
        /// The final amount of the message to be booked to the account.
        /// </summary>
        [JsonProperty(PropertyName = "amount_final")]
        public Amount AmountFinal { get; private set; }
    
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
        /// The type of message that this card result is created for.
        /// </summary>
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; private set; }
    
        /// <summary>
        /// The way the cardholder was authorised to the POS or ATM.
        /// </summary>
        [JsonProperty(PropertyName = "authorisation_type")]
        public string AuthorisationType { get; private set; }
    
        /// <summary>
        /// The city where the message originates from.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; private set; }
    
        /// <summary>
        /// The monetary account label of the account that this result is created for.
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
        /// The status of the reservation if the transaction is a reservation.
        /// </summary>
        [JsonProperty(PropertyName = "reservation_status")]
        public string ReservationStatus { get; private set; }
    
        /// <summary>
        /// The moment the reservation will expire.
        /// </summary>
        [JsonProperty(PropertyName = "reservation_expiry_time")]
        public string ReservationExpiryTime { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CardResult> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cardResultId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cardResultId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CardResult>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<CardResult>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<CardResult>(responseRaw, OBJECT_TYPE);
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
    
            if (this.AmountOriginal != null)
            {
                return false;
            }
    
            if (this.AmountFinal != null)
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
    
            if (this.MessageType != null)
            {
                return false;
            }
    
            if (this.AuthorisationType != null)
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
    
            if (this.ReservationStatus != null)
            {
                return false;
            }
    
            if (this.ReservationExpiryTime != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardResult CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardResult>(json);
        }
    }
}
