using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class MonetaryAccountSetting : BunqModel
    {
        /// <summary>
        /// The color chosen for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    
        /// <summary>
        /// The icon chosen for the MonetaryAccount.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    
        /// <summary>
        /// The status of the avatar. Can be either AVATAR_DEFAULT, AVATAR_CUSTOM or AVATAR_UNDETERMINED.
        /// </summary>
        [JsonProperty(PropertyName = "default_avatar_status")]
        public string DefaultAvatarStatus { get; set; }
    
        /// <summary>
        /// The chat restriction. Possible values are ALLOW_INCOMING or BLOCK_INCOMING
        /// </summary>
        [JsonProperty(PropertyName = "restriction_chat")]
        public string RestrictionChat { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Color != null)
            {
                return false;
            }
    
            if (this.Icon != null)
            {
                return false;
            }
    
            if (this.DefaultAvatarStatus != null)
            {
                return false;
            }
    
            if (this.RestrictionChat != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccountSetting CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountSetting>(json);
        }
    }
}
