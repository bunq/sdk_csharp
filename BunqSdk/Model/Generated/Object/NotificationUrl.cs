using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationUrl : BunqModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "target_url")]
        public string TargetUrl { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "event_type")]
        public string EventType { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public NotificationAnchorObject Object { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.TargetUrl != null)
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
    
            if (this.Object != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
