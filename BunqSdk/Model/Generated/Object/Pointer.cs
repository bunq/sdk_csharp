using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Pointer : BunqModel
    {
        /// <summary>
        /// The alias type, can be: EMAIL|PHONE_NUMBER|IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The alias value.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    
        /// <summary>
        /// The alias name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        public Pointer(string type, string value, string name)
        {
            Type = type;
            Value = value;
            Name = name;
        }
    }
}
