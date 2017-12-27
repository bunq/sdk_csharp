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
    /// Manages user's conversations.
    /// </summary>
    public class ChatConversation : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ErrorNullFields = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlListing = "user/{0}/chat-conversation";
        private const string EndpointUrlRead = "user/{0}/chat-conversation/{1}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ChatConversation";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SupportConversationExternal")]
        public ChatConversationSupportExternal SupportConversationExternal { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatConversationReference")]
        public ChatConversationReference ChatConversationReference { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<ChatConversation>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<ChatConversation>(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<ChatConversation> Get(ApiContext apiContext, int userId, int chatConversationId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, chatConversationId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ChatConversation>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.SupportConversationExternal != null)
            {
                return this.SupportConversationExternal;
            }
    
            if (this.ChatConversationReference != null)
            {
                return this.ChatConversationReference;
            }
    
            throw new BunqException(ErrorNullFields);
        }
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.SupportConversationExternal != null)
            {
                return false;
            }
    
            if (this.ChatConversationReference != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatConversation CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatConversation>(json);
        }
    }
}
