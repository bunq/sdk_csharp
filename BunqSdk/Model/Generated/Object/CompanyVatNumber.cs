using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CompanyVatNumber : BunqModel
    {
        /// <summary>
        /// The country of the VAT identification number.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    
        /// <summary>
        /// The VAT identification number number.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    
    
        public CompanyVatNumber(string country, string value)
        {
            Country = country;
            Value = value;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Country != null)
            {
                return false;
            }
    
            if (this.Value != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CompanyVatNumber CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CompanyVatNumber>(json);
        }
    }
}
