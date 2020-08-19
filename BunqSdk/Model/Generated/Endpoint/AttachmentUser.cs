using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// This call is used to upload an attachment that is accessible only by a specific user. This can be used for
    /// example to upload passport scans or other documents. Attachments supported are png, jpg and gif.
    /// </summary>
    public class AttachmentUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/attachment/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "AttachmentUser";

        /// <summary>
        /// The id of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the attachment's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the attachment's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }


        /// <summary>
        /// Get a specific attachment. The header of the response contains the content-type of the attachment.
        /// </summary>
        public static BunqResponse<AttachmentUser> Get(int attachmentUserId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), attachmentUserId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<AttachmentUser>(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.Created != null)
            {
                return false;
            }

            if (this.Updated != null)
            {
                return false;
            }

            if (this.Attachment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static AttachmentUser CreateFromJsonString(string json)
        {
            return CreateFromJsonString<AttachmentUser>(json);
        }
    }
}