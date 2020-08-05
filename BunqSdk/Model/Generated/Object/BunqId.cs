using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqId : BunqModel
    {
        public BunqId(int? id)
        {
            Id = id;
        }

        /// <summary>
        ///     An integer ID of an object. Unique per object type.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static BunqId CreateFromJsonString(string json)
        {
            return CreateFromJsonString<BunqId>(json);
        }
    }
}