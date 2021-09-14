using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TaxResident : BunqModel
    {
        /// <summary>
        /// The country of the tax number.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    
        /// <summary>
        /// The tax number.
        /// </summary>
        [JsonProperty(PropertyName = "tax_number")]
        public string TaxNumber { get; set; }
    
        /// <summary>
        /// The status of the tax number. Either CONFIRMED or UNCONFIRMED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
    
        public TaxResident(string country, string taxNumber)
        {
            Country = country;
            TaxNumber = taxNumber;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Country != null)
            {
                return false;
            }
    
            if (this.TaxNumber != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TaxResident CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TaxResident>(json);
        }
    }
}
