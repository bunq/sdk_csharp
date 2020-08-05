using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

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
        public override bool IsAllFieldNull()
        {
            if (TargetUrl != null) return false;

            if (Category != null) return false;

            if (EventType != null) return false;

            if (Object != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static NotificationUrl CreateFromJsonString(string json)
        {
            return CreateFromJsonString<NotificationUrl>(json);
        }
    }
}