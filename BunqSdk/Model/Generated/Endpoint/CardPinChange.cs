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
    /// View for the pin change.
    /// </summary>
    public class CardPinChange : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card/{1}/pin-change";

        protected const string ENDPOINT_URL_READ = "user/{0}/card/{1}/pin-change/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CardPinChange";

        /// <summary>
        /// The id of the pin change.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The label of the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_card")]
        public LabelCard LabelCard { get; set; }

        /// <summary>
        /// The monetary account this card was ordered on and the label user that owns the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account_current")]
        public MonetaryAccountReference LabelMonetaryAccountCurrent { get; set; }

        /// <summary>
        /// The request date of the pin change.
        /// </summary>
        [JsonProperty(PropertyName = "time_request")]
        public string TimeRequest { get; set; }

        /// <summary>
        /// The acceptance date of the pin change.
        /// </summary>
        [JsonProperty(PropertyName = "time_accept")]
        public string TimeAccept { get; set; }

        /// <summary>
        /// The status of the pin change request, PIN_UPDATE_REQUESTED or PIN_UPDATE_ACCEPTED
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<CardPinChange>> List(int cardId, IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), cardId), urlParams,
                customHeaders);

            return FromJsonList<CardPinChange>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<CardPinChange> Get(int cardId, int cardPinChangeId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), cardId, cardPinChangeId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<CardPinChange>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.LabelCard != null)
            {
                return false;
            }

            if (this.LabelMonetaryAccountCurrent != null)
            {
                return false;
            }

            if (this.TimeRequest != null)
            {
                return false;
            }

            if (this.TimeAccept != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardPinChange CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardPinChange>(json);
        }
    }
}