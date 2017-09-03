using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Endpoint for retrieving the messages that are part of a conversation.
    /// </summary>
    public class ChatMessage : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/chat-conversation/{1}/message";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ChatMessage";

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
        /// The id of the ticket this message is linked with, if any.
        /// </summary>
        [JsonProperty(PropertyName = "ticket_id")]
        public int? TicketId { get; private set; }

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
        public BunqModel Content { get; private set; }

        /// <summary>
        /// Get all the messages that are part of a specific conversation.
        /// </summary>
        public static BunqResponse<List<ChatMessage>> List(ApiContext apiContext, int userId, int chatConversationId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, chatConversationId), urlParams,
                customHeaders);

            return FromJsonList<ChatMessage>(responseRaw, OBJECT_TYPE);
        }
    }
}
