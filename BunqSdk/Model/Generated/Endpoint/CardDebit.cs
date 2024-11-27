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
        public const string FIELD_PREFERRED_NAME_ON_CARD = "preferred_name_on_card";
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_TYPE = "type";
        public const string FIELD_PRODUCT_TYPE = "product_type";
        public const string FIELD_PIN_CODE_ASSIGNMENT = "pin_code_assignment";
        public const string FIELD_MONETARY_ACCOUNT_ID_FALLBACK = "monetary_account_id_fallback";
        public const string FIELD_ORDER_STATUS = "order_status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "CardDebit";
    
        /// <summary>
        /// The second line of text on the card, used as name/description for it. It can contain at most 17 characters
        /// and it can be empty.
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }
        /// <summary>
        /// The user's name as it will be on the card. Check 'card-name' for the available card names for a user.
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }
        /// <summary>
        /// The user's preferred name that can be put on the card.
        /// </summary>
        [JsonProperty(PropertyName = "preferred_name_on_card")]
        public string PreferredNameOnCard { get; set; }
        /// <summary>
        /// The pointer to the monetary account that will be connected at first with the card. Its IBAN code is also the
        /// one that will be printed on the card itself. The pointer must be of type IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The type of card to order. Can be MAESTRO or MASTERCARD.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The product type of the card to order.
        /// </summary>
        [JsonProperty(PropertyName = "product_type")]
        public string ProductType { get; set; }
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
        /// The order status of this card. Can be CARD_REQUEST_PENDING or VIRTUAL_DELIVERY.
        /// </summary>
        [JsonProperty(PropertyName = "order_status")]
        public string OrderStatus { get; set; }
    
        /// <summary>
        /// Create a new debit card request.
        /// </summary>
        /// <param name="secondLine">The second line of text on the card, used as name/description for it. It can contain at most 17 characters and it can be empty.</param>
        /// <param name="nameOnCard">The user's name as it will be on the card. Check 'card-name' for the available card names for a user.</param>
        /// <param name="type">The type of card to order. Can be MAESTRO or MASTERCARD.</param>
        /// <param name="productType">The product type of the card to order.</param>
        /// <param name="preferredNameOnCard">The user's preferred name that can be put on the card.</param>
        /// <param name="alias">The pointer to the monetary account that will be connected at first with the card. Its IBAN code is also the one that will be printed on the card itself. The pointer must be of type IBAN.</param>
        /// <param name="pinCodeAssignment">Array of Types, PINs, account IDs assigned to the card.</param>
        /// <param name="monetaryAccountIdFallback">ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if not supplied.</param>
        /// <param name="orderStatus">The order status of this card. Can be CARD_REQUEST_PENDING or VIRTUAL_DELIVERY.</param>
        public static BunqResponse<CardDebit> Create(string secondLine, string nameOnCard, string type, string productType, string preferredNameOnCard = null, Pointer alias = null, List<CardPinAssignment> pinCodeAssignment = null, int? monetaryAccountIdFallback = null, string orderStatus = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_SECOND_LINE, secondLine},
    {FIELD_NAME_ON_CARD, nameOnCard},
    {FIELD_PREFERRED_NAME_ON_CARD, preferredNameOnCard},
    {FIELD_ALIAS, alias},
    {FIELD_TYPE, type},
    {FIELD_PRODUCT_TYPE, productType},
    {FIELD_PIN_CODE_ASSIGNMENT, pinCodeAssignment},
    {FIELD_MONETARY_ACCOUNT_ID_FALLBACK, monetaryAccountIdFallback},
    {FIELD_ORDER_STATUS, orderStatus},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return FromJson<CardDebit>(responseRaw, OBJECT_TYPE_POST);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
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
