using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Image : BunqModel
    {
        /// <summary>
        /// The public UUID of the public attachment containing the image.
        /// </summary>
        [JsonProperty(PropertyName = "attachment_public_uuid")]
        public string AttachmentPublicUuid { get; set; }

        /// <summary>
        /// The content-type as a MIME filetype.
        /// </summary>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int? Height { get; set; }

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public int? Width { get; set; }
    }
}
