using Newtonsoft.Json;

namespace Bunq.Sdk.Model
{
    public class Id
    {
        [JsonProperty(PropertyName = "id")]
        public int IdInt { get; private set; }

        public Id(int idInt)
        {
            IdInt = idInt;
        }
    }
}
