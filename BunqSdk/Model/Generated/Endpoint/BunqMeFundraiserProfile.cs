using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// bunq.me public profile of the user.
    /// </summary>
    public class BunqMeFundraiserProfile : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_POINTER = "pointer";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "BunqMeFundraiserProfileModel";
    
        /// <summary>
        /// The color chosen for the bunq.me fundraiser profile in hexadecimal format.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; private set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the User and the MonetaryAccount that created the
        /// bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The description of the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The attachments attached to the fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentPublic> Attachment { get; private set; }
    
        /// <summary>
        /// The pointer (url) which will be used to access the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "pointer")]
        public MonetaryAccountReference Pointer { get; private set; }
    
        /// <summary>
        /// The status of the bunq.me fundraiser profile, can be ACTIVE or DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The URL which the user is sent to when a payment is completed.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Color != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.Pointer != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.RedirectUrl != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
