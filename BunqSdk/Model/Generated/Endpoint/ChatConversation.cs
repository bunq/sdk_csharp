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
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/chat-conversation";

        protected const string ENDPOINT_URL_READ = "user/{0}/chat-conversation/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ChatConversation";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SupportConversationExternal")]
        public ChatConversationSupportExternal SupportConversationExternal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatConversationReference")]
        public ChatConversationReference ChatConversationReference { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<ChatConversation>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<ChatConversation>(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<ChatConversation> Get(int chatConversationId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), chatConversationId),
                new Dictionary<string, string>(), customHeaders);

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

            throw new BunqException(ERROR_NULL_FIELDS);
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