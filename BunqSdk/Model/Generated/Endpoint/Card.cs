using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for retrieving details for the cards the user has access to.
    /// </summary>
    public class Card : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlUpdate = "user/{0}/card/{1}";
        private const string EndpointUrlRead = "user/{0}/card/{1}";
        private const string EndpointUrlListing = "user/{0}/card";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldPinCode = "pin_code";
        public const string FieldActivationCode = "activation_code";
        public const string FieldStatus = "status";
        public const string FieldLimit = "limit";
        public const string FieldMagStripePermission = "mag_stripe_permission";
        public const string FieldCountryPermission = "country_permission";
        public const string FieldMonetaryAccountCurrentId = "monetary_account_current_id";
        public const string FieldPinCodeAssignment = "pin_code_assignment";
        public const string FieldMonetaryAccountIdFallback = "monetary_account_id_fallback";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "CardDebit";
    
        /// <summary>
        /// The id of the card.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the card's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the card's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The public UUID of the card.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; private set; }
    
        /// <summary>
        /// The type of the card. Can be MAESTRO, MASTERCARD.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }
    
        /// <summary>
        /// The sub-type of the card.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; private set; }
    
        /// <summary>
        /// The second line of text on the card
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; private set; }
    
        /// <summary>
        /// The status to set for the card. Can be ACTIVE, DEACTIVATED, LOST, STOLEN, CANCELLED, EXPIRED or
        /// PIN_TRIES_EXCEEDED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The sub-status of the card. Can be NONE or REPLACED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; private set; }
    
        /// <summary>
        /// The order status of the card. Can be CARD_UPDATE_REQUESTED, CARD_UPDATE_SENT, CARD_UPDATE_ACCEPTED,
        /// ACCEPTED_FOR_PRODUCTION or DELIVERED_TO_CUSTOMER.
        /// </summary>
        [JsonProperty(PropertyName = "order_status")]
        public string OrderStatus { get; private set; }
    
        /// <summary>
        /// Expiry date of the card.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; private set; }
    
        /// <summary>
        /// The user's name on the card.
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; private set; }
    
        /// <summary>
        /// The last 4 digits of the PAN of the card.
        /// </summary>
        [JsonProperty(PropertyName = "primary_account_number_four_digit")]
        public string PrimaryAccountNumberFourDigit { get; private set; }
    
        /// <summary>
        /// The limits to define for the card, among CARD_LIMIT_CONTACTLESS, CARD_LIMIT_ATM, CARD_LIMIT_DIPPING and
        /// CARD_LIMIT_POS_ICC (e.g. 25 EUR for CARD_LIMIT_CONTACTLESS)
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public List<CardLimit> Limit { get; private set; }
    
        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "mag_stripe_permission")]
        public CardMagStripePermission MagStripePermission { get; private set; }
    
        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "country_permission")]
        public List<CardCountryPermission> CountryPermission { get; private set; }
    
        /// <summary>
        /// The monetary account this card was ordered on and the label user that owns the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account_ordered")]
        public MonetaryAccountReference LabelMonetaryAccountOrdered { get; private set; }
    
        /// <summary>
        /// The monetary account that this card is currently linked to and the label user viewing it.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account_current")]
        public MonetaryAccountReference LabelMonetaryAccountCurrent { get; private set; }
    
        /// <summary>
        /// Array of Types, PINs, account IDs assigned to the card.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code_assignment")]
        public List<CardPinAssignment> PinCodeAssignment { get; private set; }
    
        /// <summary>
        /// ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if
        /// not supplied.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id_fallback")]
        public int? MonetaryAccountIdFallback { get; private set; }
    
        /// <summary>
        /// The country that is domestic to the card. Defaults to country of residence of user.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; private set; }
    
        /// <summary>
        /// Update the card details. Allow to change pin code, status, limits, country permissions and the monetary
        /// account connected to the card. When the card has been received, it can be also activated through this
        /// endpoint.
        /// </summary>
        public static BunqResponse<Card> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(apiContext, requestBytes, customHeaders);
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, cardId), requestBytes, customHeaders);
    
            return FromJson<Card>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Return the details of a specific card.
        /// </summary>
        public static BunqResponse<Card> Get(ApiContext apiContext, int userId, int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, cardId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<Card>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Return all the cards available to the user.
        /// </summary>
        public static BunqResponse<List<Card>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<Card>(responseRaw, ObjectType);
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
    
            if (this.PublicUuid != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.SubType != null)
            {
                return false;
            }
    
            if (this.SecondLine != null)
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
    
            if (this.OrderStatus != null)
            {
                return false;
            }
    
            if (this.ExpiryDate != null)
            {
                return false;
            }
    
            if (this.NameOnCard != null)
            {
                return false;
            }
    
            if (this.PrimaryAccountNumberFourDigit != null)
            {
                return false;
            }
    
            if (this.Limit != null)
            {
                return false;
            }
    
            if (this.MagStripePermission != null)
            {
                return false;
            }
    
            if (this.CountryPermission != null)
            {
                return false;
            }
    
            if (this.LabelMonetaryAccountOrdered != null)
            {
                return false;
            }
    
            if (this.LabelMonetaryAccountCurrent != null)
            {
                return false;
            }
    
            if (this.PinCodeAssignment != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountIdFallback != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Card CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Card>(json);
        }
    }
}
