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
    /// Manage the push notification filters for a user.
    /// </summary>
    public class NotificationFilterPushUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/notification-filter-push";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/notification-filter-push";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "NotificationFilterPush";

        private const string OBJECT_TYPE_GET = "NotificationFilterPush";

        /// <summary>
        /// The types of notifications that will result in a push notification for this user.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilterPush> NotificationFilters { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="notificationFilters">The types of notifications that will result in a push notification for this user.</param>
        public static BunqResponse<NotificationFilterPushUser> Create(
            List<NotificationFilterPush> notificationFilters = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_NOTIFICATION_FILTERS, notificationFilters},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return FromJson<NotificationFilterPushUser>(responseRaw, OBJECT_TYPE_POST);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<NotificationFilterPushUser>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<NotificationFilterPushUser>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NotificationFilters != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static NotificationFilterPushUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterPushUser>(json);
        }
    }
}