using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentStatusConversation : BunqModel
    {
        /// <summary>
        /// Action which occurred over a conversation. Always CONVERSATION_CREATED
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Action != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
