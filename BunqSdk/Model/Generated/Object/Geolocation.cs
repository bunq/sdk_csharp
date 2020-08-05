using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Geolocation : BunqModel
    {
        /// <summary>
        ///     The latitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        ///     The longitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        ///     The altitude for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "altitude")]
        public double? Altitude { get; set; }

        /// <summary>
        ///     The radius for a geolocation restriction.
        /// </summary>
        [JsonProperty(PropertyName = "radius")]
        public double? Radius { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Latitude != null) return false;

            if (Longitude != null) return false;

            if (Altitude != null) return false;

            if (Radius != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Geolocation CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Geolocation>(json);
        }
    }
}