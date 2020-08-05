using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     It is possible to order a card replacement with the bunq API.<br /><br />You can order up to one free card
    ///     replacement per year. Additional replacement requests will be billed.<br /><br />The card replacement will have
    ///     the same expiry date and the same pricing as the old card, but it will have a new card number. You can change
    ///     the description and optional the PIN through the card replacement endpoint.
    /// </summary>
    public class CardReplace : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/card/{1}/replace";

        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_NAME_ON_CARD = "name_on_card";

        public const string FIELD_PIN_CODE_ASSIGNMENT = "pin_code_assignment";
        public const string FIELD_SECOND_LINE = "second_line";


        /// <summary>
        ///     The user's name as it will be on the card. Check 'card-name' for the available card names for a user.
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }

        /// <summary>
        ///     Array of Types, PINs, account IDs assigned to the card.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code_assignment")]
        public List<CardPinAssignment> PinCodeAssignment { get; set; }

        /// <summary>
        ///     The second line on the card.
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }

        /// <summary>
        ///     The id of the new card.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        ///     Request a card replacement.
        /// </summary>
        /// <param name="nameOnCard">
        ///     The user's name as it will be on the card. Check 'card-name' for the available card names for
        ///     a user.
        /// </param>
        /// <param name="pinCodeAssignment">Array of Types, PINs, account IDs assigned to the card.</param>
        /// <param name="secondLine">The second line on the card.</param>
        public static BunqResponse<int> Create(int cardId, string nameOnCard = null,
            List<CardPinAssignment> pinCodeAssignment = null, string secondLine = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_NAME_ON_CARD, nameOnCard},
                {FIELD_PIN_CODE_ASSIGNMENT, pinCodeAssignment},
                {FIELD_SECOND_LINE, secondLine}
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), cardId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardReplace CreateFromJsonString(string json)
        {
            return CreateFromJsonString<CardReplace>(json);
        }
    }
}