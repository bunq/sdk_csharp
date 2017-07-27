using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Ubo : BunqModel
    {
        /// <summary>
        /// The name of the ultimate beneficiary owner.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The date of birth of the ultimate beneficiary owner.
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// The nationality of the ultimate beneficiary owner.
        /// </summary>
        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }
    }
}
