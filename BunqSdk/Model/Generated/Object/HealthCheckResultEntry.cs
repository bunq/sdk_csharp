using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class HealthCheckResultEntry : BunqModel
    {
        /// <summary>
        /// The type of HealthCheckResultEntry.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The status of the HealthCheckResultEntry
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static HealthCheckResultEntry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<HealthCheckResultEntry>(json);
        }
    }
}
