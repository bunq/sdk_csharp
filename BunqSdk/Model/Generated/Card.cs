using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Security;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Endpoint for retrieving details for the cards the user has access to.
    /// </summary>
    public class Card : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PIN_CODE = "pin_code";
        public const string FIELD_ACTIVATION_CODE = "activation_code";
        public const string FIELD_STATUS = "status";
        public const string FIELD_LIMIT = "limit";
        public const string FIELD_MAG_STRIPE_PERMISSION = "mag_stripe_permission";
        public const string FIELD_COUNTRY_PERMISSION = "country_permission";
        public const string FIELD_MONETARY_ACCOUNT_CURRENT_ID = "monetary_account_current_id";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_UPDATE = "user/{0}/card/{1}";
        private const string ENDPOINT_URL_READ = "user/{0}/card/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/card";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CardDebit";

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

        public static BunqResponse<Card> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int cardId)
        {
            return Update(apiContext, requestMap, userId, cardId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Update the card details. Allow to change pin code, status, limits, country permissions and the monetary
        /// account connected to the card. When the card has been received, it can be also activated through this
        /// endpoint.
        /// </summary>
        public static BunqResponse<Card> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int cardId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(apiContext, requestBytes, customHeaders);
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, cardId), requestBytes,
                customHeaders);

            return FromJson<Card>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<Card> Get(ApiContext apiContext, int userId, int cardId)
        {
            return Get(apiContext, userId, cardId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return the details of a specific card.
        /// </summary>
        public static BunqResponse<Card> Get(ApiContext apiContext, int userId, int cardId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, cardId), customHeaders);

            return FromJson<Card>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<Card>> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return all the cards available to the user.
        /// </summary>
        public static BunqResponse<List<Card>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<Card>(responseRaw, OBJECT_TYPE);
        }
    }
}
