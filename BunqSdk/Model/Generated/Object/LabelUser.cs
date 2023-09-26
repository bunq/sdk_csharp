using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class LabelUser : BunqModel
    {
        /// <summary>
        /// The public UUID of the label-user.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// The name to be displayed for this user, as it was given on the request.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// The country of the user. 000 stands for "unknown"
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// The current avatar of the user.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }
        /// <summary>
        /// The current nickname of the user.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; set; }
    
        public LabelUser(string uuid, string displayName, string country)
        {
            Uuid = uuid;
            DisplayName = displayName;
            Country = country;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }
    
            if (this.Avatar != null)
            {
                return false;
            }
    
            if (this.PublicNickName != null)
            {
                return false;
            }
    
            if (this.DisplayName != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static LabelUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<LabelUser>(json);
        }
    }
}
