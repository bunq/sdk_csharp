using Newtonsoft.Json;

namespace Bunq.Sdk.Model
{
    public class Uuid
    {
        [JsonProperty(PropertyName = "uuid")]
        public string UuidString { get; private set; }

        public Uuid(string uuidString)
        {
            UuidString = uuidString;
        }
    }
}
