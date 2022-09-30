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
    /// Manage the email notification filters for a user.
    /// </summary>
    public class NotificationFilterEmail : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/notification-filter-email";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/notification-filter-email";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "NotificationFilterEmail";
        private const string OBJECT_TYPE_GET = "NotificationFilterEmail";
    
        /// <summary>
        /// The types of notifications that will result in a email notification for this user.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilterEmail> NotificationFilters { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="notificationFilters">The types of notifications that will result in a email notification for this user.</param>
        public static BunqResponse<NotificationFilterEmail> Create(List<NotificationFilterEmail> notificationFilters = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_NOTIFICATION_FILTERS, notificationFilters},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return FromJson<NotificationFilterEmail>(responseRaw, OBJECT_TYPE_POST);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<NotificationFilterEmail>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<NotificationFilterEmail>(responseRaw, OBJECT_TYPE_GET);
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
        public static NotificationFilterEmail CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterEmail>(json);
        }
    }
}
