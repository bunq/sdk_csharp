using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// It is possible to order a card replacement with the bunq API.<br/><br/>You can order up to one free card
    /// replacement per year. Additional replacement requests will be billed.<br/><br/>The card replacement will have
    /// the same expiry date and the same pricing as the old card, but it will have a new card number. You can change
    /// the description and optional the PIN through the card replacement endpoint.
    /// </summary>
    public class CardReplace : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/card/{1}/replace";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PIN_CODE = "pin_code";

        public const string FIELD_SECOND_LINE = "second_line";


        /// <summary>
        /// The id of the new card.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Request a card replacement.
        /// </summary>
        /// <param name="pinCode">The plaintext pin code. Requests require encryption to be enabled.</param>
        /// <param name="secondLine">The second line on the card.</param>
        public static BunqResponse<int> Create(int cardId, string pinCode = null, string secondLine = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_PIN_CODE, pinCode},
                {FIELD_SECOND_LINE, secondLine},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(GetApiContext(), requestBytes, customHeaders);
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), cardId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardReplace CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardReplace>(json);
        }
    }
}