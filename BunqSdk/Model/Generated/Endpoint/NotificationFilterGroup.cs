using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the notification filter groups for a user.
    /// </summary>
    public class NotificationFilterGroup : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/notification-filter-group";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/notification-filter-group";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_GROUP = "group";
        public const string FIELD_STATUS_PUSH = "status_push";
        public const string FIELD_STATUS_EMAIL = "status_email";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "NotificationFilterGroup";
        private const string OBJECT_TYPE_GET = "NotificationFilterGroup";
    
        /// <summary>
        /// The notification filter group.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string Group { get; set; }
    
        /// <summary>
        /// The status for push messaging.
        /// </summary>
        [JsonProperty(PropertyName = "status_push")]
        public string StatusPush { get; set; }
    
        /// <summary>
        /// The status for emails.
        /// </summary>
        [JsonProperty(PropertyName = "status_email")]
        public string StatusEmail { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="group">The notification filter group.</param>
        /// <param name="statusPush">The status for push messaging.</param>
        /// <param name="statusEmail">The status for emails.</param>
        public static BunqResponse<NotificationFilterGroup> Create(string group, string statusPush, string statusEmail, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_GROUP, group},
    {FIELD_STATUS_PUSH, statusPush},
    {FIELD_STATUS_EMAIL, statusEmail},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return FromJson<NotificationFilterGroup>(responseRaw, OBJECT_TYPE_POST);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<NotificationFilterGroup>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<NotificationFilterGroup>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Group != null)
            {
                return false;
            }
    
            if (this.StatusPush != null)
            {
                return false;
            }
    
            if (this.StatusEmail != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static NotificationFilterGroup CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterGroup>(json);
        }
    }
}
