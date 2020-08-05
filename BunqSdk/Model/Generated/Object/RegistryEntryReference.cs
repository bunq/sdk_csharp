using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RegistryEntryReference : BunqModel
    {
        /// <summary>
        ///     The object type that will be linked to the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        ///     The ID of the object that will be used for the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistryEntryReference CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistryEntryReference>(json);
        }
    }
}