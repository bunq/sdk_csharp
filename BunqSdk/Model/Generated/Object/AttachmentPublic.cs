using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentPublic : BunqModel
    {
        /// <summary>
        ///     The uuid of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        ///     The description of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     The content type of the attachment's file.
        /// </summary>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Uuid != null) return false;

            if (Description != null) return false;

            if (ContentType != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static AttachmentPublic CreateFromJsonString(string json)
        {
            return CreateFromJsonString<AttachmentPublic>(json);
        }
    }
}