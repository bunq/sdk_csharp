using System;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of MonetaryAccountReference required to provide compatibility between the two types
    /// used to refer to Monetary Accounts: Pointers in requests and Monetary Account Labels in responses.
    /// </summary>
    public class MonetaryAccountReferenceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var monetaryAccountReference = (MonetaryAccountReference) value;

            if (monetaryAccountReference == null || monetaryAccountReference.Pointer == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteRaw(BunqJsonConvert.SerializeObject(monetaryAccountReference.Pointer));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var labelMonetaryAccount = BunqJsonConvert.DeserializeObject<LabelMonetaryAccount>(jObject.ToString());

            return new MonetaryAccountReference(labelMonetaryAccount);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MonetaryAccountReference);
        }
    }
}
