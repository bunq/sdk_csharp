using Newtonsoft.Json;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Used to lazy-initialize the static settings for the Newtonsoft's JsonConvert.
    /// </summary>
    public static class BunqJsonConvert
    {
        private const string FORMAT_DATE = "yyyy-MM-dd HH:mm:ss.ffffff";

        private static bool isInitialized;

        /// <summary>
        /// This method MUST be called before any (de)serialization with Newtonsoft JSON happens.
        /// </summary>
        private static void Initialize()
        {
            if (isInitialized) return;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new BunqContractResolver(),
                DateFormatString = FORMAT_DATE,
                FloatParseHandling = FloatParseHandling.Decimal,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            isInitialized = true;
        }

        /// <summary>Serializes the specified object to a JSON string.</summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(object value)
        {
            Initialize();

            return JsonConvert.SerializeObject(value);
        }

        /// <summary>Deserializes the JSON to the specified .NET type.</summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The JSON to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static T DeserializeObject<T>(string value)
        {
            Initialize();

            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>Deserializes the JSON to a .NET object.</summary>
        /// <param name="value">The JSON to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static object DeserializeObject(string value)
        {
            Initialize();

            return JsonConvert.DeserializeObject(value);
        }
    }
}
