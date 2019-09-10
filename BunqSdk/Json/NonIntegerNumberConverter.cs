using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of InstallationContext required due to presence in it of the encryption
    /// keys which should be formatted when serialized in a special way.
    /// </summary>
    public class NonIntegerNumberConverter : JsonConverter
    {
        private const string FORMAT_DECIMAL = "0.##";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(((double) value).ToString(FORMAT_DECIMAL));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jToken = JToken.Load(reader);

            if (jToken.Type == JTokenType.String)
            {
                return jToken.ToObject<double>();
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double?) || objectType == typeof(decimal?) || objectType == typeof(float?);
        }
    }
}
