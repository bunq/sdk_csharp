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
    /// This call is used to view an attachment that is linked to a tab.
    /// </summary>
    public class TabAttachmentTab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "tab/{0}/attachment/{1}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TabAttachmentTab";
    
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
    
        /// <summary>
        /// Get a specific attachment. The header of the response contains the content-type of the attachment.
        /// </summary>
        public static BunqResponse<TabAttachmentTab> Get(ApiContext apiContext, string tabUuid, int tabAttachmentTabId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, tabUuid, tabAttachmentTabId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TabAttachmentTab>(responseRaw, OBJECT_TYPE_GET);
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
        public static TabAttachmentTab CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabAttachmentTab>(json);
        }
    }
}
