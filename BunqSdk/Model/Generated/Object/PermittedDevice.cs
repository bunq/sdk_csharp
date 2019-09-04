using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class PermittedDevice : BunqModel
    {
        /// <summary>
        /// The description of the device that may use the credential.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The IP address of the device that may use the credential.
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Ip != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PermittedDevice CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PermittedDevice>(json);
        }
    }
}
