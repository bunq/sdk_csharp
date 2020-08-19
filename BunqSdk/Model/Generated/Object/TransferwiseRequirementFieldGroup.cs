using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TransferwiseRequirementFieldGroup : BunqModel
    {
        /// <summary>
        /// The key of the field. This is the value to send as input.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// The field's input type: "text", "select" or "radio".
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The field name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates that any changes in this field affect the requirements, if this field is changed, the requirements
        /// endpoint must be called again to recheck if there are any additional requirements.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_requirements_on_change")]
        public bool? RefreshRequirementsOnChange { get; set; }

        /// <summary>
        /// Whether or not the field is required.
        /// </summary>
        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        /// <summary>
        /// Formatting mask to guide user input.
        /// </summary>
        [JsonProperty(PropertyName = "display_format")]
        public string DisplayFormat { get; set; }

        /// <summary>
        /// An example value for this field.
        /// </summary>
        [JsonProperty(PropertyName = "example")]
        public string Example { get; set; }

        /// <summary>
        /// The minimum length of the field's value.
        /// </summary>
        [JsonProperty(PropertyName = "min_length")]
        public string MinLength { get; set; }

        /// <summary>
        /// The maximum length of the field's value.
        /// </summary>
        [JsonProperty(PropertyName = "max_length")]
        public string MaxLength { get; set; }

        /// <summary>
        /// A regular expression which may be used to validate the user input.
        /// </summary>
        [JsonProperty(PropertyName = "validation_regexp")]
        public string ValidationRegexp { get; set; }

        /// <summary>
        /// Details of an endpoint which may be used to validate the user input.
        /// </summary>
        [JsonProperty(PropertyName = "validation_async")]
        public TransferwiseRequirementFieldGroupValidationAsync ValidationAsync { get; set; }

        /// <summary>
        /// Shows which values are allowed for fields of type "select" or "radio".
        /// </summary>
        [JsonProperty(PropertyName = "values_allowed")]
        public TransferwiseRequirementFieldGroupValuesAllowed ValuesAllowed { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Key != null)
            {
                return false;
            }

            if (this.Type != null)
            {
                return false;
            }

            if (this.Name != null)
            {
                return false;
            }

            if (this.RefreshRequirementsOnChange != null)
            {
                return false;
            }

            if (this.Required != null)
            {
                return false;
            }

            if (this.DisplayFormat != null)
            {
                return false;
            }

            if (this.Example != null)
            {
                return false;
            }

            if (this.MinLength != null)
            {
                return false;
            }

            if (this.MaxLength != null)
            {
                return false;
            }

            if (this.ValidationRegexp != null)
            {
                return false;
            }

            if (this.ValidationAsync != null)
            {
                return false;
            }

            if (this.ValuesAllowed != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TransferwiseRequirementFieldGroup CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TransferwiseRequirementFieldGroup>(json);
        }
    }
}