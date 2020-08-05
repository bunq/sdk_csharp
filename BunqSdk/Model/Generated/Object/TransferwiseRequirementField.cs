using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TransferwiseRequirementField : BunqModel
    {
        public TransferwiseRequirementField(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///     The name of the required field.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        ///     The value of the required field.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        ///     The descriptive label of the field.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The field group.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public BunqModel Group { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Name != null) return false;

            if (Group != null) return false;

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