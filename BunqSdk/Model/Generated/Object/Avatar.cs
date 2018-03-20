using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Avatar : BunqModel
    {
        /// <summary>
        /// The public UUID of the avatar.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The public UUID of object this avatar is anchored to.
        /// </summary>
        [JsonProperty(PropertyName = "anchor_uuid")]
        public string AnchorUuid { get; set; }

        /// <summary>
        /// The actual image information of this avatar.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public List<Image> Image { get; set; }

        public Avatar(string uuid)
        {
            Uuid = uuid;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }

            if (this.AnchorUuid != null)
            {
                return false;
            }

            if (this.Image != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Avatar CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Avatar>(json);
        }
    }
}