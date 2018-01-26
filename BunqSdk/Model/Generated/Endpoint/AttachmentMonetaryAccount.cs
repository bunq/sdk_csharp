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
    /// This call is used to upload an attachment that can be referenced to in payment requests and payments sent from a
    /// specific monetary account. Attachments supported are png, jpg and gif.
    /// </summary>
    public class AttachmentMonetaryAccount : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/attachment";
    
        /// <summary>
        /// Object type.
        /// </summary>
    
        /// <summary>
        /// The attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; private set; }
    
        /// <summary>
        /// The ID of the attachment created.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// Create a new monetary account attachment. Create a POST request with a payload that contains the binary
        /// representation of the file, without any JSON wrapping. Make sure you define the MIME type (i.e. image/jpeg)
        /// in the Content-Type header. You are required to provide a description of the attachment using the
        /// X-Bunq-Attachment-Description header.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, byte[] requestBytes, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.Id != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AttachmentMonetaryAccount CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentMonetaryAccount>(json);
        }
    }
}
