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
    /// Manage the url notification filters for a user.
    /// </summary>
    public class NotificationFilterFailure : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/notification-filter-failure";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/notification-filter-failure";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NOTIFICATION_FILTER_FAILED_IDS = "notification_filter_failed_ids";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "NotificationFilterFailure";
    
        /// <summary>
        /// The IDs to retry.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filter_failed_ids")]
        public string NotificationFilterFailedIds { get; set; }
        /// <summary>
        /// The types of notifications that will result in a url notification for this user.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; set; }
        /// <summary>
        /// The category of the failed notification.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// The event type of the failed notification.
        /// </summary>
        [JsonProperty(PropertyName = "event_type")]
        public string EventType { get; set; }
        /// <summary>
        /// The object id used to generate the body of the notification.
        /// </summary>
        [JsonProperty(PropertyName = "object_id")]
        public int? ObjectId { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="notificationFilterFailedIds">The IDs to retry.</param>
        public static BunqResponse<int> Create(string notificationFilterFailedIds, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_NOTIFICATION_FILTER_FAILED_IDS, notificationFilterFailedIds},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<NotificationFilterFailure>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<NotificationFilterFailure>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NotificationFilters != null)
            {
                return false;
            }
    
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.EventType != null)
            {
                return false;
            }
    
            if (this.ObjectId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static NotificationFilterFailure CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterFailure>(json);
        }
    }
}
