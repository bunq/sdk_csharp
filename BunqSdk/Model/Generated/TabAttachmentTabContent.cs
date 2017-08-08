using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of a tab attachment with given ID. The raw content is the binary representation of a file,
    /// without any JSON wrapping.
    /// </summary>
    public class TabAttachmentTabContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "tab/{0}/attachment/{1}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabAttachmentTabContent";

        public static BunqResponse<byte[]> List(ApiContext apiContext, string tabUuid, int attachmentId)
        {
            return List(apiContext, tabUuid, attachmentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the raw content of a specific attachment.
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, string tabUuid, int attachmentId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, tabUuid, attachmentId), customHeaders);

            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    }
}
