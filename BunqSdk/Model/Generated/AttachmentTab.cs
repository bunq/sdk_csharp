using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// This call is used to upload an attachment that will be accessible only through tabs. This can be used for
    /// example to upload special promotions or other attachments. Attachments supported are png, jpg and gif.
    /// </summary>
    public class AttachmentTab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/attachment-tab";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/attachment-tab/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentTab";

        /// <summary>
        /// The id of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the attachment's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the attachment's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, byte[] requestBytes, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestBytes, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Upload a new attachment to use with a tab, and to read its metadata. Create a POST request with a payload
        /// that contains the binary representation of the file, without any JSON wrapping. Make sure you define the
        /// MIME type (i.e. image/jpeg) in the Content-Type header. You are required to provide a description of the
        /// attachment using the X-Bunq-Attachment-Description header.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, byte[] requestBytes, int userId,
            int monetaryAccountId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<AttachmentTab> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int attachmentTabId)
        {
            return Get(apiContext, userId, monetaryAccountId, attachmentTabId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific attachment. The header of the response contains the content-type of the attachment.
        /// </summary>
        public static BunqResponse<AttachmentTab> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int attachmentTabId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, attachmentTabId),
                    customHeaders);

            return FromJson<AttachmentTab>(responseRaw, OBJECT_TYPE);
        }
    }
}
