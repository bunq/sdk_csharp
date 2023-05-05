using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationFilterUrl : BunqModel
    {
        /// <summary>
        /// The notification category that will match this notification filter.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// The users this filter pertains to.
        /// </summary>
        [JsonProperty(PropertyName = "all_user_id")]
        public List<string> AllUserId { get; set; }
    
        /// <summary>
        /// The MAs this filter pertains to.
        /// </summary>
        [JsonProperty(PropertyName = "all_monetary_account_id")]
        public List<string> AllMonetaryAccountId { get; set; }
    
        /// <summary>
        /// Type of verification required for the connection.
        /// </summary>
        [JsonProperty(PropertyName = "all_verification_type")]
        public List<string> AllVerificationType { get; set; }
    
        /// <summary>
        /// The URL to which the callback should be made.
        /// </summary>
        [JsonProperty(PropertyName = "notification_target")]
        public string NotificationTarget { get; set; }
    
        /// <summary>
        /// The id of the NotificationFilterUrl.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the NotificationFilterUrl's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the NotificationFilterUrl's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
    
        public NotificationFilterUrl(string category, string notificationTarget)
        {
            Category = category;
            NotificationTarget = notificationTarget;
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
    
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.AllUserId != null)
            {
                return false;
            }
    
            if (this.AllMonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.AllVerificationType != null)
            {
                return false;
            }
    
            if (this.NotificationTarget != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static NotificationFilterUrl CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterUrl>(json);
        }
    }
}
