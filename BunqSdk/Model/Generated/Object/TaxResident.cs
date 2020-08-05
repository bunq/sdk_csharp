using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TaxResident : BunqModel
    {
        public TaxResident(string country, string taxNumber)
        {
            Country = country;
            TaxNumber = taxNumber;
        }

        /// <summary>
        ///     The country of the tax number.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        ///     The tax number.
        /// </summary>
        [JsonProperty(PropertyName = "tax_number")]
        public string TaxNumber { get; set; }

        /// <summary>
        ///     The status of the tax number. Either CONFIRMED or UNCONFIRMED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Country != null) return false;

            if (TaxNumber != null) return false;

            if (Status != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static TaxResident CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TaxResident>(json);
        }
    }
}