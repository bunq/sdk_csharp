using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// This call is used to upload an attachment that can be referenced to as an avatar (through the Avatar endpoint)
    /// or in a tab sent. Attachments supported are png, jpg and gif.
    /// </summary>
    public class AttachmentPublic : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "attachment-public";
        private const string ENDPOINT_URL_READ = "attachment-public/{0}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentPublic";
    
        /// <summary>
        /// The UUID of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; private set; }
    
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
    
        /// <summary>
        /// Create a new public attachment. Create a POST request with a payload that contains a binary representation
        /// of the file, without any JSON wrapping. Make sure you define the MIME type (i.e. image/jpeg, or image/png)
        /// in the Content-Type header. You are required to provide a description of the attachment using the
        /// X-Bunq-Attachment-Description header.
        /// </summary>
        public static BunqResponse<string> Create(ApiContext apiContext, byte[] requestBytes, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);
    
            return ProcessForUuid(responseRaw);
        }
    
        /// <summary>
        /// Get a specific attachment's metadata through its UUID. The Content-Type header of the response will describe
        /// the MIME type of the attachment file.
        /// </summary>
        public static BunqResponse<AttachmentPublic> Get(ApiContext apiContext, string attachmentPublicUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, attachmentPublicUuid), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<AttachmentPublic>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
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
        public static AttachmentPublic CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentPublic>(json);
        }
    }
}
