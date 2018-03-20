using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentGeolocation : BunqModel
    {
        /// <summary>
        /// A geolocation, using WGS 84 coordinates.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Geolocation != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessageContentGeolocation CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageContentGeolocation>(json);
        }
    }
}