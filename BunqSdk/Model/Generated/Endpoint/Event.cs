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
    /// Used to view events. Events are automatically created and contain information about everything that happens to
    /// your bunq account. In the bunq app events are shown in your 'overview'. Examples of when events are created or
    /// modified: payment sent, payment received, request for payment received or connect invite received.
    /// </summary>
    public class Event : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/event/{1}";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/event";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Event";

        /// <summary>
        /// The id of the event.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the event's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the event's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The performed action. Can be: CREATE or UPDATE.
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The id of the user the event applied to (if it was a user event).
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the monetary account the event applied to (if it was a monetary account event).
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public string MonetaryAccountId { get; set; }

        /// <summary>
        /// The details of the external object the event was created for.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public EventObject Object { get; set; }

        /// <summary>
        /// The event status. Can be: FINALIZED or AWAITING_REPLY. An example of FINALIZED event is a payment received
        /// event, while an AWAITING_REPLY event is a request received event.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Get a specific event for a given user.
        /// </summary>
        public static BunqResponse<Event> Get(int eventId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), eventId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Event>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a collection of events for a given user. You can add query the parameters monetary_account_id, status
        /// and/or display_user_event to filter the response. When monetary_account_id={id,id} is provided only events
        /// that relate to these monetary account ids are returned. When status={AWAITING_REPLY/FINALIZED} is provided
        /// the response only contains events with the status AWAITING_REPLY or FINALIZED. When
        /// display_user_event={true/false} is set to false user events are excluded from the response, when not
        /// provided user events are displayed. User events are events that are not related to a monetary account (for
        /// example: connect invites).
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

            if (this.Action != null)
            {
                return false;
            }

            if (this.UserId != null)
            {
                return false;
            }

            if (this.MonetaryAccountId != null)
            {
                return false;
            }

            if (this.Object != null)
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
        public static Event CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Event>(json);
        }
    }
}