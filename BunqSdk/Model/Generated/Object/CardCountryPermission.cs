using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardCountryPermission : BunqModel
    {
        /// <summary>
        /// The country to allow transactions in (e.g. NL, DE).
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Expiry time of this rule.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }

        /// <summary>
        /// The id of the card country permission entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        public CardCountryPermission(string country)
        {
            Country = country;
        }
    }
}
