using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Manages user's conversations.
    /// </summary>
    public class ChatConversation : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/chat-conversation";
        private const string ENDPOINT_URL_READ = "user/{0}/chat-conversation/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ChatConversation";

        public static List<ChatConversation> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static List<ChatConversation> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<ChatConversation>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static ChatConversation Get(ApiContext apiContext, int userId, int chatConversationId)
        {
            return Get(apiContext, userId, chatConversationId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static ChatConversation Get(ApiContext apiContext, int userId, int chatConversationId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, chatConversationId), customHeaders);

            return FromJson<ChatConversation>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
