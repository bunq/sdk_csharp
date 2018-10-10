using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqId : BunqModel
    {
        /// <summary>
        /// An integer ID of an object. Unique per object type.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        public BunqId(int? id)
        {
            Id = id;
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BunqId CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqId>(json);
        }
    }
}