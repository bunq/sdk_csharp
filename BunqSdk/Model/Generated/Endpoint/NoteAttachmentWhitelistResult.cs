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
    /// Used to manage attachment notes.
    /// </summary>
    public class NoteAttachmentWhitelistResult : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/whitelist/{2}/whitelist-result/{3}/note-attachment";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/whitelist/{2}/whitelist-result/{3}/note-attachment/{4}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/whitelist/{2}/whitelist-result/{3}/note-attachment/{4}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/whitelist/{2}/whitelist-result/{3}/note-attachment";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/whitelist/{2}/whitelist-result/{3}/note-attachment/{4}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ATTACHMENT_ID = "attachment_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "NoteAttachment";
    
        /// <summary>
        /// Optional description of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The reference to the uploaded file to attach to this note.
        /// </summary>
        [JsonProperty(PropertyName = "attachment_id")]
        public int? AttachmentId { get; set; }
    
        /// <summary>
        /// The id of the note.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the note's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the note's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The label of the user who created this note.
        /// </summary>
        [JsonProperty(PropertyName = "label_user_creator")]
        public MonetaryAccountReference LabelUserCreator { get; set; }
    
        /// <summary>
        /// The attachment attached to the note.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPayment> Attachment { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="attachmentId">The reference to the uploaded file to attach to this note.</param>
        /// <param name="description">Optional description of the attachment.</param>
        public static BunqResponse<int> Create(int whitelistId, int whitelistResultId, int? attachmentId, int? monetaryAccountId= null, string description = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_DESCRIPTION, description},
    {FIELD_ATTACHMENT_ID, attachmentId},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistId, whitelistResultId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="description">Optional description of the attachment.</param>
        public static BunqResponse<int> Update(int whitelistId, int whitelistResultId, int noteAttachmentWhitelistResultId, int? monetaryAccountId= null, string description = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_DESCRIPTION, description},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistId, whitelistResultId, noteAttachmentWhitelistResultId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int whitelistId, int whitelistResultId, int noteAttachmentWhitelistResultId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistId, whitelistResultId, noteAttachmentWhitelistResultId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// Manage the notes for a given user.
        /// </summary>
        public static BunqResponse<List<NoteAttachmentWhitelistResult>> List(int whitelistId, int whitelistResultId, int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistId, whitelistResultId), urlParams, customHeaders);
    
            return FromJsonList<NoteAttachmentWhitelistResult>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<NoteAttachmentWhitelistResult> Get(int whitelistId, int whitelistResultId, int noteAttachmentWhitelistResultId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistId, whitelistResultId, noteAttachmentWhitelistResultId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<NoteAttachmentWhitelistResult>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.LabelUserCreator != null)
            {
                return false;
            }
    
            if (this.Description != null)
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
        public static NoteAttachmentWhitelistResult CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<NoteAttachmentWhitelistResult>(json);
        }
    }
}
