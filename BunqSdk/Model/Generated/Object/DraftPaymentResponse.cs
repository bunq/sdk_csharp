using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class DraftPaymentResponse : BunqModel
    {
        /// <summary>
        /// The status with which was responded.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The user that responded to the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }
    }
}
