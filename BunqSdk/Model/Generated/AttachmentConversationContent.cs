using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of an attachment with given ID. The raw content is the base64 of a file, without any JSON
    /// wrapping.
    /// </summary>
    public class AttachmentConversationContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/chat-conversation/{1}/attachment/{2}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentConversationContent";

        public static byte[] List(ApiContext apiContext, int userId, int chatConversationId, int attachmentId)
        {
            return List(apiContext, userId, chatConversationId, attachmentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the raw content of a specific attachment.
        /// </summary>
        public static byte[] List(ApiContext apiContext, int userId, int chatConversationId, int attachmentId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);

            return apiClient
                .Get(string.Format(ENDPOINT_URL_LISTING, userId, chatConversationId, attachmentId), customHeaders)
                .Content.ReadAsByteArrayAsync().Result;
        }
    }
}
