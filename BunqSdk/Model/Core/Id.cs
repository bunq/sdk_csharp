using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Core
{
    public class Id
    {
        [JsonProperty(PropertyName = "id")] public long IdInt { get; private set; }

        public Id(long idInt)
        {
            IdInt = idInt;
        }
    }
}