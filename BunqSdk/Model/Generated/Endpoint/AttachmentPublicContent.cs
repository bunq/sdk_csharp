using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Fetch the raw content of a public attachment with given ID. The raw content is the binary representation of a
    ///     file, without any JSON wrapping.
    /// </summary>
    public class AttachmentPublicContent : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "attachment-public/{0}/content";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "AttachmentPublicContent";

        /// <summary>
        ///     Get the raw content of a specific attachment.
        /// </summary>
        public static BunqResponse<byte[]> List(string attachmentPublicUuid,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, attachmentPublicUuid),
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
        public static AttachmentPublicContent CreateFromJsonString(string json)
        {
            return CreateFromJsonString<AttachmentPublicContent>(json);
        }
    }
}