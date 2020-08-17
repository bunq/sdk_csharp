using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to get events based on time and insight category.
    /// </summary>
    public class InsightEvent : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/insights-search";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Event";

        /// <summary>
        ///     The id of the event.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the event's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the event's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        ///     The performed action. Can be: CREATE or UPDATE.
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        ///     The id of the user the event applied to (if it was a user event).
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        /// <summary>
        ///     The id of the monetary account the event applied to (if it was a monetary account event).
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public string MonetaryAccountId { get; set; }

        /// <summary>
        ///     The details of the external object the event was created for.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public EventObject Object { get; set; }

        /// <summary>
        ///     The event status. Can be: FINALIZED or AWAITING_REPLY. An example of FINALIZED event is a payment received
        ///     event, while an AWAITING_REPLY event is a request received event.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<List<InsightEvent>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<InsightEvent>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (Action != null) return false;

            if (UserId != null) return false;

            if (MonetaryAccountId != null) return false;

            if (Object != null) return false;

            if (Status != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static InsightEvent CreateFromJsonString(string json)
        {
            return CreateFromJsonString<InsightEvent>(json);
        }
    }
}