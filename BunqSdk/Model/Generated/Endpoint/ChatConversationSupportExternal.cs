using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manages user's support conversation.
    /// </summary>
    public class ChatConversationSupportExternal : BunqModel
    {
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "SupportConversationExternal";
    
        /// <summary>
        /// The id of this conversation.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the support conversation's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the support conversation's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The last message posted to this conversation if any.
        /// </summary>
        [JsonProperty(PropertyName = "last_message")]
        public ChatMessage LastMessage { get; private set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.LastMessage != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatConversationSupportExternal CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatConversationSupportExternal>(json);
        }
    }
}
