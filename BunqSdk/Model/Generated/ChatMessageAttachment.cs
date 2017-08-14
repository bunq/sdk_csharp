using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Create new messages holding file attachments.
    /// </summary>
    public class ChatMessageAttachment : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CLIENT_MESSAGE_UUID = "client_message_uuid";
        public const string FIELD_ATTACHMENT = "attachment";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/chat-conversation/{1}/message-attachment";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Id";

        /// <summary>
        /// The id of the newly created chat message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int chatConversationId)
        {
            return Create(apiContext, requestMap, userId, chatConversationId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new message holding a file attachment to a specific conversation.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int chatConversationId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, chatConversationId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }
    }
}
