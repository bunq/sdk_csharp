using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentStatusMembership : BunqModel
    {
        /// <summary>
        /// Action which occurred over a member. Could be MEMBER_ADDED or MEMBER_REMOVED
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }
    
        /// <summary>
        /// The member over which the action has occurred.
        /// </summary>
        [JsonProperty(PropertyName = "member")]
        public LabelUser Member { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Action != null)
            {
                return false;
            }
    
            if (this.Member != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
