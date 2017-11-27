using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContent :  BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
    
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
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.ChatMessageContentAnchorEvent != null)
            {
                return this.ChatMessageContentAnchorEvent;
            }
    
            if (this.ChatMessageContentAttachment != null)
            {
                return this.ChatMessageContentAttachment;
            }
    
            if (this.ChatMessageContentGeolocation != null)
            {
                return this.ChatMessageContentGeolocation;
            }
    
            if (this.ChatMessageContentStatusConversationTitle != null)
            {
                return this.ChatMessageContentStatusConversationTitle;
            }
    
            if (this.ChatMessageContentStatusConversation != null)
            {
                return this.ChatMessageContentStatusConversation;
            }
    
            if (this.ChatMessageContentStatusMembership != null)
            {
                return this.ChatMessageContentStatusMembership;
            }
    
            if (this.ChatMessageContentText != null)
            {
                return this.ChatMessageContentText;
            }
    
            throw new BunqException(ERROR_NULL_FIELDS);
        }
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.ChatMessageContentAnchorEvent != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentAttachment != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentGeolocation != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentStatusConversationTitle != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentStatusConversation != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentStatusMembership != null)
            {
                return false;
            }
    
            if (this.ChatMessageContentText != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
