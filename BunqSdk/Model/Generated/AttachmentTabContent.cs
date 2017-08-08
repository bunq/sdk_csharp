using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of a tab attachment with given ID. The raw content is the binary representation of a file,
    /// without any JSON wrapping.
    /// </summary>
    public class AttachmentTabContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/attachment-tab/{2}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentTabContent";

        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int attachmentTabId)
        {
            return List(apiContext, userId, monetaryAccountId, attachmentTabId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the raw content of a specific attachment.
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int attachmentTabId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, attachmentTabId),
                    customHeaders);

            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    }
}
