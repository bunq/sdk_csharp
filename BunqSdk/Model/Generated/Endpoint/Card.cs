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
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/card/{1}";

        protected const string ENDPOINT_URL_READ = "user/{0}/card/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PIN_CODE = "pin_code";

        public const string FIELD_ACTIVATION_CODE = "activation_code";
        public const string FIELD_STATUS = "status";
        public const string FIELD_CARD_LIMIT = "card_limit";
        public const string FIELD_CARD_LIMIT_ATM = "card_limit_atm";
        public const string FIELD_MAG_STRIPE_PERMISSION = "mag_stripe_permission";
        public const string FIELD_COUNTRY_PERMISSION = "country_permission";
        public const string FIELD_PIN_CODE_ASSIGNMENT = "pin_code_assignment";
        public const string FIELD_PRIMARY_ACCOUNT_NUMBERS_VIRTUAL = "primary_account_numbers_virtual";
        public const string FIELD_PRIMARY_ACCOUNT_NUMBERS = "primary_account_numbers";
        public const string FIELD_MONETARY_ACCOUNT_ID_FALLBACK = "monetary_account_id_fallback";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_PUT = "CardDebit";

        private const string OBJECT_TYPE_GET = "CardDebit";

        /// <summary>
        /// The plaintext pin code. Requests require encryption to be enabled.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code")]
        public string PinCode { get; set; }

        /// <summary>
        /// DEPRECATED: Activate a card by setting status to ACTIVE when the order_status is ACCEPTED_FOR_PRODUCTION.
        /// </summary>
        [JsonProperty(PropertyName = "activation_code")]
        public string ActivationCode { get; set; }

        /// <summary>
        /// The status to set for the card. Can be ACTIVE, DEACTIVATED, LOST, STOLEN, CANCELLED, EXPIRED or
        /// PIN_TRIES_EXCEEDED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The spending limit for the card.
        /// </summary>
        [JsonProperty(PropertyName = "card_limit")]
        public Amount CardLimit { get; set; }

        /// <summary>
        /// The ATM spending limit for the card.
        /// </summary>
        [JsonProperty(PropertyName = "card_limit_atm")]
        public Amount CardLimitAtm { get; set; }

        /// <summary>
        /// DEPRECATED: Whether or not it is allowed to use the mag stripe for the card.
        /// </summary>
        [JsonProperty(PropertyName = "mag_stripe_permission")]
        public CardMagStripePermission MagStripePermission { get; set; }

        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "country_permission")]
        public List<CardCountryPermission> CountryPermission { get; set; }

        /// <summary>
        /// Array of Types, PINs, account IDs assigned to the card.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code_assignment")]
        public List<CardPinAssignment> PinCodeAssignment { get; set; }

        /// <summary>
        /// Array of PANs, status, description and account id for online cards.
        /// </summary>
        [JsonProperty(PropertyName = "primary_account_numbers_virtual")]
        public List<CardVirtualPrimaryAccountNumber> PrimaryAccountNumbersVirtual { get; set; }

        /// <summary>
        /// Array of PANs and their attributes.
        /// </summary>
        [JsonProperty(PropertyName = "primary_account_numbers")]
        public List<CardPrimaryAccountNumber> PrimaryAccountNumbers { get; set; }

        /// <summary>
        /// ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if
        /// not supplied.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id_fallback")]
        public int? MonetaryAccountIdFallback { get; set; }

        /// <summary>
        /// The id of the card.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the card's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the card's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The public UUID of the card.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The type of the card. Can be MAESTRO, MASTERCARD.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The sub-type of the card.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// The second line of text on the card
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }

        /// <summary>
        /// The sub-status of the card. Can be NONE or REPLACED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The order status of the card. Can be CARD_UPDATE_REQUESTED, CARD_UPDATE_SENT, CARD_UPDATE_ACCEPTED,
        /// ACCEPTED_FOR_PRODUCTION or DELIVERED_TO_CUSTOMER.
        /// </summary>
        [JsonProperty(PropertyName = "order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Expiry date of the card.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The user's name on the card.
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }

        /// <summary>
        /// The last 4 digits of the PAN of the card.
        /// </summary>
        [JsonProperty(PropertyName = "primary_account_number_four_digit")]
        public string PrimaryAccountNumberFourDigit { get; set; }

        /// <summary>
        /// The monetary account this card was ordered on and the label user that owns the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account_ordered")]
        public MonetaryAccountReference LabelMonetaryAccountOrdered { get; set; }

        /// <summary>
        /// The monetary account that this card is currently linked to and the label user viewing it.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account_current")]
        public MonetaryAccountReference LabelMonetaryAccountCurrent { get; set; }

        /// <summary>
        /// The country that is domestic to the card. Defaults to country of residence of user.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Update the card details. Allow to change pin code, status, limits, country permissions and the monetary
        /// account connected to the card. When the card has been received, it can be also activated through this
        /// endpoint.
        /// </summary>
        /// <param name="pinCode">The plaintext pin code. Requests require encryption to be enabled.</param>
        /// <param name="activationCode">DEPRECATED: Activate a card by setting status to ACTIVE when the order_status is ACCEPTED_FOR_PRODUCTION.</param>
        /// <param name="status">The status to set for the card. Can be ACTIVE, DEACTIVATED, LOST, STOLEN or CANCELLED, and can only be set to LOST/STOLEN/CANCELLED when order status is ACCEPTED_FOR_PRODUCTION/DELIVERED_TO_CUSTOMER/CARD_UPDATE_REQUESTED/CARD_UPDATE_SENT/CARD_UPDATE_ACCEPTED. Can only be set to DEACTIVATED after initial activation, i.e. order_status is DELIVERED_TO_CUSTOMER/CARD_UPDATE_REQUESTED/CARD_UPDATE_SENT/CARD_UPDATE_ACCEPTED. Mind that all the possible choices (apart from ACTIVE and DEACTIVATED) are permanent and cannot be changed after.</param>
        /// <param name="cardLimit">The spending limit for the card.</param>
        /// <param name="cardLimitAtm">The ATM spending limit for the card.</param>
        /// <param name="magStripePermission">DEPRECATED: Whether or not it is allowed to use the mag stripe for the card.</param>
        /// <param name="countryPermission">The countries for which to grant (temporary) permissions to use the card.</param>
        /// <param name="pinCodeAssignment">Array of Types, PINs, account IDs assigned to the card.</param>
        /// <param name="primaryAccountNumbersVirtual">Array of PANs, status, description and account id for online cards.</param>
        /// <param name="primaryAccountNumbers">Array of PANs and their attributes.</param>
        /// <param name="monetaryAccountIdFallback">ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if not supplied.</param>
        public static BunqResponse<Card> Update(int cardId, string pinCode = null, string activationCode = null,
            string status = null, Amount cardLimit = null, Amount cardLimitAtm = null,
            CardMagStripePermission magStripePermission = null, List<CardCountryPermission> countryPermission = null,
            List<CardPinAssignment> pinCodeAssignment = null,
            List<CardVirtualPrimaryAccountNumber> primaryAccountNumbersVirtual = null,
            List<CardPrimaryAccountNumber> primaryAccountNumbers = null, int? monetaryAccountIdFallback = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_PIN_CODE, pinCode},
                {FIELD_ACTIVATION_CODE, activationCode},
                {FIELD_STATUS, status},
                {FIELD_CARD_LIMIT, cardLimit},
                {FIELD_CARD_LIMIT_ATM, cardLimitAtm},
                {FIELD_MAG_STRIPE_PERMISSION, magStripePermission},
                {FIELD_COUNTRY_PERMISSION, countryPermission},
                {FIELD_PIN_CODE_ASSIGNMENT, pinCodeAssignment},
                {FIELD_PRIMARY_ACCOUNT_NUMBERS_VIRTUAL, primaryAccountNumbersVirtual},
                {FIELD_PRIMARY_ACCOUNT_NUMBERS, primaryAccountNumbers},
                {FIELD_MONETARY_ACCOUNT_ID_FALLBACK, monetaryAccountIdFallback},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(GetApiContext(), requestBytes, customHeaders);
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), cardId), requestBytes,
                customHeaders);

            return FromJson<Card>(responseRaw, OBJECT_TYPE_PUT);
        }

        /// <summary>
        /// Return the details of a specific card.
        /// </summary>
        public static BunqResponse<Card> Get(int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), cardId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Card>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Return all the cards available to the user.
        /// </summary>
        public static BunqResponse<List<Card>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<Card>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.PrimaryAccountNumbersVirtual != null)
            {
                return false;
            }

            if (this.PrimaryAccountNumbers != null)
            {
                return false;
            }

            if (this.CardLimit != null)
            {
                return false;
            }

            if (this.CardLimitAtm != null)
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