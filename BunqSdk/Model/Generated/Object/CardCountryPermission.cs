using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardCountryPermission : BunqModel
    {
        public CardCountryPermission(string country)
        {
            Country = country;
        }

        /// <summary>
        ///     The country to allow transactions in (e.g. NL, DE).
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        ///     Expiry time of this rule.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }

        /// <summary>
        ///     The id of the card country permission entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Country != null) return false;

            if (ExpiryTime != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardCountryPermission CreateFromJsonString(string json)
        {
            return CreateFromJsonString<CardCountryPermission>(json);
        }
    }
}