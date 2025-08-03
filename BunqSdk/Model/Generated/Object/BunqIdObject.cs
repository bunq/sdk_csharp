using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqIdObject : BunqModel
    {
        /// <summary>
        /// An integer ID of an object. Unique per object type.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
    
        public BunqIdObject(long? id)
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
        public static BunqIdObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqIdObject>(json);
        }
    }
}
