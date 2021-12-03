using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentUrl : BunqModel
    {
        /// <summary>
        /// The file type of attachment.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The URL where the attachment can be downloaded.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Url != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AttachmentUrl CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentUrl>(json);
        }
    }
}
