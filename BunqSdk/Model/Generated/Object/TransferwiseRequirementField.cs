using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TransferwiseRequirementField : BunqModel
    {
        /// <summary>
        /// The name of the required field.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// The value of the required field.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The descriptive label of the field.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The field group.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public TransferwiseRequirementFieldGroup Group { get; set; }


        public TransferwiseRequirementField(string key, string value)
        {
            Key = key;
            Value = value;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Name != null)
            {
                return false;
            }

            if (this.Group != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TransferwiseRequirementField CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TransferwiseRequirementField>(json);
        }
    }
}