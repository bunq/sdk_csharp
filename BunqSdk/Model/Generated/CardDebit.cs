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
    /// With bunq it is possible to order debit cards that can then be connected with each one of the monetary accounts
    /// the user has access to (including connected accounts).
    /// </summary>
    public class CardDebit : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_SECOND_LINE = "second_line";
        public const string FIELD_NAME_ON_CARD = "name_on_card";
        public const string FIELD_PIN_CODE = "pin_code";
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_TYPE = "type";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/card-debit";

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
        /// The timestamp when the card was crated.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp when the card was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The second line of text on the card
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; private set; }

        /// <summary>
        /// The user's name as will be on the card
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; private set; }

        /// <summary>
        /// The status to set for the card. After ordering the card it will be DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The order status of the card. After ordering the card it will be NEW_CARD_REQUEST_RECEIVED.
        /// </summary>
        [JsonProperty(PropertyName = "order_status")]
        public string OrderStatus { get; private set; }

        /// <summary>
        /// The expiry date of the card.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; private set; }

        /// <summary>
        /// The limits to define for the card (e.g. 25 EUR for CARD_LIMIT_CONTACTLESS).
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public List<CardLimit> Limit { get; private set; }

        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "country_permission")]
        public List<CardCountryPermission> CountryPermission { get; private set; }

        /// <summary>
        /// The label for the user who requested the card.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public LabelUser Alias { get; private set; }

        public static CardDebit Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId)
        {
            return Create(apiContext, requestMap, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new debit card request.
        /// </summary>
        public static CardDebit Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(apiContext, requestBytes, customHeaders);
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);

            return FromJson<CardDebit>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
