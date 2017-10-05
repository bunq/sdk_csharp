using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Geolocation : BunqModel
    {
        /// <summary>
        /// The latitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }
    
        /// <summary>
        /// The longitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }
    
        /// <summary>
        /// The altitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "altitude")]
        public double? Altitude { get; set; }
    
        /// <summary>
        /// The radius for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "radius")]
        public double? Radius { get; set; }
    }
}
