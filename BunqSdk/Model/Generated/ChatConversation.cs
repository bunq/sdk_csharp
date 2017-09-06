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

        /// <summary>
        /// </summary>
        public static BunqResponse<List<ChatConversation>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), urlParams, customHeaders);

            return FromJsonList<ChatConversation>(responseRaw, OBJECT_TYPE);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<ChatConversation> Get(ApiContext apiContext, int userId, int chatConversationId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, chatConversationId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<ChatConversation>(responseRaw, OBJECT_TYPE);
        }
    }
}
