using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

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


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ErrorDescription != null)
            {
                return false;
            }

            if (this.ErrorDescriptionTranslated != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Error CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Error>(json);
        }
    }
}