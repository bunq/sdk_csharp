using System;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of Geolocation for GSON, required because Geolocation uses Double's, but their
    /// precision at the moment of serialization should be higher than that of a normal Double from bunq SDK.
    /// </summary>
    public class GeolocationConverter : JsonConverter
    {
        private const string FieldLatitude = "latitude";
        private const string FieldLongitude = "longitude";
        private const string FieldAltitude = "altitude";
        private const string FieldRadius = "radius";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var geolocation = (Geolocation) value;

            writer.WriteStartObject();

            writer.WritePropertyName(FieldLatitude);
            writer.WriteValue(geolocation.Latitude.ToString());

            writer.WritePropertyName(FieldLongitude);
            writer.WriteValue(geolocation.Longitude.ToString());

            writer.WritePropertyName(FieldAltitude);
            writer.WriteValue(geolocation.Altitude.ToString());

            writer.WritePropertyName(FieldRadius);
            writer.WriteValue(geolocation.Radius.ToString());

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Geolocation);
        }
    }
}
