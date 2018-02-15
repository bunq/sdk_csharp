using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for retrieving the messages that are part of a conversation.
    /// </summary>
    public class ChatMessageUser : BunqModel
    {
        /// <summary>
        /// The id of the message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp when the message was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp when the message was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The id of the conversation this message belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "conversation_id")]
        public int? ConversationId { get; private set; }
    
        /// <summary>
        /// The user who initiated the action that caused this message to appear.
        /// </summary>
        [JsonProperty(PropertyName = "creator")]
        public LabelUser Creator { get; private set; }
    
        /// <summary>
        /// The user displayed as the sender of this message.
        /// </summary>
        [JsonProperty(PropertyName = "displayed_sender")]
        public LabelUser DisplayedSender { get; private set; }
    
        /// <summary>
        /// The content of this message.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public ChatMessageContent Content { get; private set; }
    
    
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
    
            if (this.ConversationId != null)
            {
                return false;
            }
    
            if (this.Creator != null)
            {
                return false;
            }
    
            if (this.DisplayedSender != null)
            {
                return false;
            }
    
            if (this.Content != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatMessageUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageUser>(json);
        }
    }
}
