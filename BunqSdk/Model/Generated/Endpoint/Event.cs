using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    public class Event : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/event";

        protected const string ENDPOINT_URL_READ = "user/{0}/event/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Event";

        /// <summary>
        /// The id of the event object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the event object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the event object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The timestamp of the event object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The timestamp of the event object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// The id of the MonetaryAccount the Payment was made to or from (depending on whether this is an incoming or
        /// outgoing Payment).
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        /// <summary>
        /// The object of the event
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public EventObject Object { get; set; }

        /// <summary>
        /// The timestamp of the event object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Get a collection of events.
        /// You can add query the parameters monetary_account_id, status and/or display_user_event to filter the response. When monetary_account_id={id,id} is provided only events that relate to these monetary account ids are returned.
        /// When status={AWAITING_REPLY/FINALIZED} is provided the response only contains events with the status AWAITING_REPLY or FINALIZED.
        /// When display_user_event={true/false} is set to false user events are excluded from the response, when not provided user events are displayed.
        /// User events are events that are not related to a monetary account (for example: connect invites).
        /// </summary>
        public static BunqResponse<List<Event>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<Event>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<Event> Get(int eventId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), eventId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Event>(responseRaw, OBJECT_TYPE_GET);
        }

        public override bool IsAllFieldNull()
        {
            if (Action != null)
                return false;

            if (UserId != null)
                return false;

            if (MonetaryAccountId != null)
                return false;

            if (Object != null)
                return false;

            if (Status != null)
                return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Event CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Event>(json);
        }
    }
}
