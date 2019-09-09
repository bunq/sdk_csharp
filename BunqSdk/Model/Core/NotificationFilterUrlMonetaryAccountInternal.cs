using System;
using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;

namespace Bunq.Sdk.Model.Core
{
    public class NotificationFilterUrlMonetaryAccountInternal : NotificationFilterUrlMonetaryAccount
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const String OBJECT_TYPE_GET = "NotificationFilterUrl";

        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterUrl>> CreateWithListResponse()
        {
            return CreateWithListResponse(null, new List<NotificationFilterUrl>(), null);
        }
        
        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterUrl>> CreateWithListResponse(
            int monetaryAccountId,
            List<NotificationFilterUrl> allNotificationFilter
        )
        {
            return CreateWithListResponse(monetaryAccountId, allNotificationFilter, null);
        }

        /// <summary>
        /// Create notification filters with list response type.
        /// </summary>
        public static BunqResponse<List<NotificationFilterUrl>> CreateWithListResponse(
            int? monetaryAccountId,
            List<NotificationFilterUrl> allNotificationFilter,
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
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
            
            return FromJsonList<NotificationFilterUrl>(responseRaw, OBJECT_TYPE_GET);
        }
    }
}