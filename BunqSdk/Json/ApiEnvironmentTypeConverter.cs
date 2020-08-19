using System;
using Bunq.Sdk.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of ApiEnvironmentType required due to the hakish nature of C# "Enum with string
    /// property" pattern.
    /// </summary>
    public class ApiEnvironmentTypeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return new ApiEnvironmentType(JToken.Load(reader).ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((ApiEnvironmentType) value).TypeString);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ApiEnvironmentType);
        }
    }
}