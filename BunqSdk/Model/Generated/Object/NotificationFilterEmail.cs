using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationFilterEmail : BunqModel
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
    
        public NotificationFilterEmail(string category)
        {
            Category = category;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
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
