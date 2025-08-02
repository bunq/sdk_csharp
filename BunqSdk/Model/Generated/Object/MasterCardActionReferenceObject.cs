using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class MasterCardActionReferenceObject : BunqModel
    {
        /// <summary>
        /// The id of the event.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public long? EventId { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.EventId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardActionReferenceObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardActionReferenceObject>(json);
        }
    }
}
