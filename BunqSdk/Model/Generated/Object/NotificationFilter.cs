using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationFilter : BunqModel
    {
        /// <summary>
        /// The delivery method via which notifications that match this notification filter will be delivered. Possible
        /// choices are PUSH for delivery via push notification and URL for delivery via URL callback.
        /// </summary>
        [JsonProperty(PropertyName = "notification_delivery_method")]
        public string NotificationDeliveryMethod { get; set; }
        /// <summary>
        /// The target of notifications that match this notification filter. For URL notification filters this is the
        /// URL to which the callback will be made. For PUSH notifications filters this should always be null.
        /// </summary>
        [JsonProperty(PropertyName = "notification_target")]
        public string NotificationTarget { get; set; }
        /// <summary>
        /// The notification category that will match this notification filter. Possible choices are BILLING,
        /// CARD_TRANSACTION_FAILED, CARD_TRANSACTION_SUCCESSFUL, CHAT, DRAFT_PAYMENT, IDEAL, SOFORT,
        /// MONETARY_ACCOUNT_PROFILE, MUTATION, PAYMENT, PROMOTION, REQUEST, SCHEDULE_RESULT, SCHEDULE_STATUS, SHARE,
        /// SUPPORT, TAB_RESULT, USER_APPROVAL.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        public NotificationFilter(string notificationDeliveryMethod, string notificationTarget, string category)
        {
            NotificationDeliveryMethod = notificationDeliveryMethod;
            NotificationTarget = notificationTarget;
            Category = category;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NotificationDeliveryMethod != null)
            {
                return false;
            }
    
            if (this.NotificationTarget != null)
            {
                return false;
            }
    
            if (this.Category != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static NotificationFilter CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilter>(json);
        }
    }
}
