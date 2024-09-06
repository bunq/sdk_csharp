using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// This call is used to upload an photo that is accessible by all members of a registry.
    /// </summary>
    public class RegistryGalleryAttachment : BunqModel
    {
        /// <summary>
        /// The id of the user owner.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }
        /// <summary>
        /// The attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }
        /// <summary>
        /// The membership of the owner uuid.
        /// </summary>
        [JsonProperty(PropertyName = "membership_uuid")]
        public string MembershipUuid { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserId != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.MembershipUuid != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistryGalleryAttachment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistryGalleryAttachment>(json);
        }
    }
}
