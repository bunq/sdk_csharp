using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint to retrieve point mutation.
    /// </summary>
    public class PointMutationApiObject : BunqModel
    {
        /// <summary>
        /// The number of points earned.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_point")]
        public long? NumberOfPoint { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NumberOfPoint != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PointMutationApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PointMutationApiObject>(json);
        }
    }
}
