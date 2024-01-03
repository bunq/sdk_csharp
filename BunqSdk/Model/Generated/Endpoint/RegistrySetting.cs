using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to manage Slice group settings.
    /// </summary>
    public class RegistrySetting : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_COLOR = "color";
        public const string FIELD_ICON = "icon";
        public const string FIELD_DEFAULT_AVATAR_STATUS = "default_avatar_status";
        public const string FIELD_SDD_EXPIRATION_ACTION = "sdd_expiration_action";
    
    
        /// <summary>
        /// The color chosen for the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        /// <summary>
        /// The icon chosen for the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        /// <summary>
        /// The status of the avatar. Can be either AVATAR_DEFAULT, AVATAR_CUSTOM, AVATAR_ICON or AVATAR_UNDETERMINED.
        /// </summary>
        [JsonProperty(PropertyName = "default_avatar_status")]
        public string DefaultAvatarStatus { get; set; }
        /// <summary>
        /// A monetaryAccountSetting field that should not be here, added for app support.
        /// </summary>
        [JsonProperty(PropertyName = "sdd_expiration_action")]
        public string SddExpirationAction { get; set; }
    
    
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistrySetting CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistrySetting>(json);
        }
    }
}
