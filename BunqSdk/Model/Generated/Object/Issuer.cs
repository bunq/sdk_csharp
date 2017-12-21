using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Issuer : BunqModel
    {
        /// <summary>
        /// The BIC code.
        /// </summary>
        [JsonProperty(PropertyName = "bic")]
        public string Bic { get; set; }
    
        /// <summary>
        /// The name of the bank.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        public Issuer(string bic)
        {
            Bic = bic;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Bic != null)
            {
                return false;
            }
    
            if (this.Name != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Issuer CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Issuer>(json);
        }
    }
}
