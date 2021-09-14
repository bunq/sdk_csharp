using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationFilterPush : BunqModel
    {
        /// <summary>
        /// The notification category that will match this notification filter.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        public NotificationFilterPush(string category)
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static NotificationFilterPush CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NotificationFilterPush>(json);
        }
    }
}
