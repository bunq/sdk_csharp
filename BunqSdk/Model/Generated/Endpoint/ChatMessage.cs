using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for retrieving the messages that are part of a conversation.
    /// </summary>
    public class ChatMessage :  BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/chat-conversation/{1}/message";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ChatMessage";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageAnnouncement")]
        public ChatMessageAnnouncement ChatMessageAnnouncement { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageStatus")]
        public ChatMessageStatus ChatMessageStatus { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageUser")]
        public ChatMessageUser ChatMessageUser { get; private set; }
    
        /// <summary>
        /// Get all the messages that are part of a specific conversation.
        /// </summary>
        public static BunqResponse<List<ChatMessage>> List(ApiContext apiContext, int userId, int chatConversationId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, chatConversationId), urlParams, customHeaders);
    
            return FromJsonList<ChatMessage>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.ChatMessageAnnouncement != null)
            {
                return this.ChatMessageAnnouncement;
            }
    
            if (this.ChatMessageStatus != null)
            {
                return this.ChatMessageStatus;
            }
    
            if (this.ChatMessageUser != null)
            {
                return this.ChatMessageUser;
            }
    
            throw new BunqException(ERROR_NULL_FIELDS);
        }
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.ChatMessageAnnouncement != null)
            {
                return false;
            }
    
            if (this.ChatMessageStatus != null)
            {
                return false;
            }
    
            if (this.ChatMessageUser != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
