using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Error : BunqModel
    {
        /// <summary>
        /// The error description (in English).
        /// </summary>
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// The error description (in the user language).
        /// </summary>
        [JsonProperty(PropertyName = "error_description_translated")]
        public string ErrorDescriptionTranslated { get; set; }
    }
}
