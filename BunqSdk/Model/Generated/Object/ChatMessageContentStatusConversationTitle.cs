using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentStatusConversationTitle : BunqModel
    {
        /// <summary>
        /// The new title of a conversation.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Title != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
