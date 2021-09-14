using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TransferwiseRequirementFieldGroupValidationAsync : BunqModel
    {
        /// <summary>
        /// The url to be used to validate user input.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    
        /// <summary>
        /// The parameters to send when validating user input.
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        public TransferwiseRequirementFieldGroupValidationAsyncParams Params { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Url != null)
            {
                return false;
            }
    
            if (this.Params != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseRequirementFieldGroupValidationAsync CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseRequirementFieldGroupValidationAsync>(json);
        }
    }
}
