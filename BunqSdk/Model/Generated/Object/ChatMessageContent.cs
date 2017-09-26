using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContent : BunqModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentAnchorEvent")]
        public ChatMessageContentAnchorEvent ChatMessageContentAnchorEvent { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentAttachment")]
        public ChatMessageContentAttachment ChatMessageContentAttachment { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentGeolocation")]
        public ChatMessageContentGeolocation ChatMessageContentGeolocation { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentStatusConversationTitle")]
        public ChatMessageContentStatusConversationTitle ChatMessageContentStatusConversationTitle { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentStatusConversation")]
        public ChatMessageContentStatusConversation ChatMessageContentStatusConversation { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentStatusMembership")]
        public ChatMessageContentStatusMembership ChatMessageContentStatusMembership { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageContentText")]
        public ChatMessageContentText ChatMessageContentText { get; set; }
    }
}
