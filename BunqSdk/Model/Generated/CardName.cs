using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Endpoint for getting all the accepted card names for a user. As bunq do not allow total freedom in choosing the
    /// name that is going to be printed on the card, the following formats are accepted: Name Surname, N. Surname, N
    /// Surname or Surname.
    /// </summary>
    public class CardName : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/card-name";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CardUserNameArray";

        /// <summary>
        /// All possible variations (of suitable length) of user's legal name for the debit card.
        /// </summary>
        [JsonProperty(PropertyName = "possible_card_name_array")]
        public List<string> PossibleCardNameArray { get; private set; }

        public static BunqResponse<List<CardName>> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return all the accepted card names for a specific user.
        /// </summary>
        public static BunqResponse<List<CardName>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<CardName>(responseRaw, OBJECT_TYPE);
        }
    }
}
