using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqMeMerchantAvailable : BunqModel
    {
        /// <summary>
        /// A merchant type supported by bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_type")]
        public string MerchantType { get; set; }
    
        /// <summary>
        /// Whether or not the merchant is available for the user.
        /// </summary>
        [JsonProperty(PropertyName = "available")]
        public bool? Available { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.MerchantType != null)
            {
                return false;
            }
    
            if (this.Available != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
