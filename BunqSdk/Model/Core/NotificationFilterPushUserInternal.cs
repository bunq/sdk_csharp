using System;
using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;

namespace Bunq.Sdk.Model.Core
{
    public class NotificationFilterPushUserInternal : NotificationFilterPushUser
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const String OBJECT_TYPE_GET = "NotificationFilterPush";

        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterPush>> CreateWithListResponse()
        {
            return CreateWithListResponse(new List<NotificationFilterPush>(), null);
        }

        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterPush>> CreateWithListResponse(
            List<NotificationFilterPush> allNotificationFilter
        )
        {
            return CreateWithListResponse(allNotificationFilter, null);
        }

        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterPush>> CreateWithListResponse(
            List<NotificationFilterPush> allNotificationFilter,
            Dictionary<String, String> customHeaders
        ) {
            ApiClient apiClient = new ApiClient(GetApiContext());

            if (customHeaders == null)
            {
                customHeaders = new Dictionary<string, string>();
            }

            Dictionary<string, object> requestMap = new Dictionary<string, object>();
            requestMap.Add(FIELD_NOTIFICATION_FILTERS, allNotificationFilter);
            
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
            
            return FromJsonList<NotificationFilterPush>(responseRaw, OBJECT_TYPE_GET);
        }
    }
}
