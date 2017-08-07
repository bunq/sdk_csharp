using Newtonsoft.Json;

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

        public TaxResident(string country, string taxNumber)
        {
            Country = country;
            TaxNumber = taxNumber;
        }
    }
}
