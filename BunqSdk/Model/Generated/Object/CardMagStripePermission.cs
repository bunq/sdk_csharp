using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardMagStripePermission : BunqModel
    {
        /// <summary>
        /// Expiry time of this rule.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }
    }
}
