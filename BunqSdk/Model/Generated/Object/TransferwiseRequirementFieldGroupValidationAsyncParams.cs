using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TransferwiseRequirementFieldGroupValidationAsyncParams : BunqModel
    {
        /// <summary>
        /// The parameter key.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// The parameter label.
        /// </summary>
        [JsonProperty(PropertyName = "parameter_name")]
        public string ParameterName { get; set; }
        /// <summary>
        /// Shows whether the parameter is required or not.
        /// </summary>
        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Key != null)
            {
                return false;
            }
    
            if (this.ParameterName != null)
            {
                return false;
            }
    
            if (this.Required != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseRequirementFieldGroupValidationAsyncParams CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseRequirementFieldGroupValidationAsyncParams>(json);
        }
    }
}
