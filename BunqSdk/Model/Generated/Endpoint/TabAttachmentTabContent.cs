using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;

namespace Bunq.Sdk.Model.Generated.Endpoint
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
        protected const string ENDPOINT_URL_LISTING = "tab/{0}/attachment/{1}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TabAttachmentTabContent";

        /// <summary>
        /// Get the raw content of a specific attachment.
        /// </summary>
        public static BunqResponse<byte[]> List(string tabUuid, int attachmentId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, tabUuid, attachmentId),
                new Dictionary<string, string>(), customHeaders);

            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        public static TabAttachmentTabContent CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TabAttachmentTabContent>(json);
        }
    }
}