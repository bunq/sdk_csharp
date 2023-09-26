using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CurrencyCloudBeneficiaryRequirementField : BunqModel
    {
        /// <summary>
        /// The label to display for the field.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        /// <summary>
        /// The name of the field.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// The expression to validate field input.
        /// </summary>
        [JsonProperty(PropertyName = "validation_expression")]
        public string ValidationExpression { get; set; }
        /// <summary>
        /// The type of data to input. Determines the keyboard to display.
        /// </summary>
        [JsonProperty(PropertyName = "input_type")]
        public string InputType { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Label != null)
            {
                return false;
            }
    
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.ValidationExpression != null)
            {
                return false;
            }
    
            if (this.InputType != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CurrencyCloudBeneficiaryRequirementField CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CurrencyCloudBeneficiaryRequirementField>(json);
        }
    }
}
