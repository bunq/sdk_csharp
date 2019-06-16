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
    /// With bunq it is possible to order debit cards that can then be connected with each one of the monetary accounts
    /// the user has access to (including connected accounts).
    /// </summary>
    public class CardDebit : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/card-debit";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_SECOND_LINE = "second_line";

        public const string FIELD_NAME_ON_CARD = "name_on_card";
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_TYPE = "type";
        public const string FIELD_PIN_CODE_ASSIGNMENT = "pin_code_assignment";
        public const string FIELD_MONETARY_ACCOUNT_ID_FALLBACK = "monetary_account_id_fallback";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "CardDebit";

        /// <summary>
        /// The second line of text on the card
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }

        /// <summary>
        /// The user's name as will be on the card
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }

        /// <summary>
        /// The label for the user who requested the card.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public LabelUser Alias { get; set; }

        /// <summary>
        /// The type of the card. Can be MAESTRO, MASTERCARD.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Array of Types, PINs, account IDs assigned to the card.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code_assignment")]
        public List<CardPinAssignment> PinCodeAssignment { get; set; }

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
        /// The timestamp when the card was crated.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp when the card was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The public UUID of the card.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The sub_type of card.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// The last 4 digits of the PAN of the card.
        /// </summary>
        [JsonProperty(PropertyName = "primary_account_number_four_digit")]
        public string PrimaryAccountNumberFourDigit { get; set; }

        /// <summary>
        /// The status to set for the card. After ordering the card it will be DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The order status of the card. After ordering the card it will be NEW_CARD_REQUEST_RECEIVED.
        /// </summary>
        [JsonProperty(PropertyName = "order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// The expiry date of the card.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "country_permission")]
        public List<CardCountryPermission> CountryPermission { get; set; }

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
        /// Create a new debit card request.
        /// </summary>
        /// <param name="secondLine">The second line of text on the card, used as name/description for it. It can contain at most 17 characters and it can be empty.</param>
        /// <param name="nameOnCard">The user's name as it will be on the card. Check 'card-name' for the available card names for a user.</param>
        /// <param name="alias">The pointer to the monetary account that will be connected at first with the card. Its IBAN code is also the one that will be printed on the card itself. The pointer must be of type IBAN.</param>
        /// <param name="type">The type of card to order. Can be MAESTRO or MASTERCARD.</param>
        /// <param name="pinCodeAssignment">Array of Types, PINs, account IDs assigned to the card.</param>
        /// <param name="monetaryAccountIdFallback">ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if not supplied.</param>
        public static BunqResponse<CardDebit> Create(string secondLine, string nameOnCard, Pointer alias = null,
            string type = null, List<CardPinAssignment> pinCodeAssignment = null, int? monetaryAccountIdFallback = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_SECOND_LINE, secondLine},
                {FIELD_NAME_ON_CARD, nameOnCard},
                {FIELD_ALIAS, alias},
                {FIELD_TYPE, type},
                {FIELD_PIN_CODE_ASSIGNMENT, pinCodeAssignment},
                {FIELD_MONETARY_ACCOUNT_ID_FALLBACK, monetaryAccountIdFallback},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(GetApiContext(), requestBytes, customHeaders);
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return FromJson<CardDebit>(responseRaw, OBJECT_TYPE_POST);
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

            if (this.NameOnCard != null)
            {
                return false;
            }

            if (this.PrimaryAccountNumberFourDigit != null)
            {
                return false;
            }

            if (this.Status != null)
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

            if (this.Alias != null)
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
        public static CardDebit CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardDebit>(json);
        }
    }
}