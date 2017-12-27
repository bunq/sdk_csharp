using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the chat connected to a request inquiry. In the same way a request inquiry and a request response are
    /// created together, so that each side of the interaction can work on a different object, also a request inquiry
    /// chat and a request response chat are created at the same time. See 'request-response-chat' for the chat endpoint
    /// for the responding user.
    /// </summary>
    public class RequestInquiryChat : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry/{2}/chat";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry/{2}/chat/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry/{2}/chat";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_LAST_READ_MESSAGE_ID = "last_read_message_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestInquiryChat";
    
        /// <summary>
        /// The id of the newly created chat conversation.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp when the chat was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp when the chat was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The total number of messages in this conversation.
        /// </summary>
        [JsonProperty(PropertyName = "unread_message_count")]
        public int? UnreadMessageCount { get; private set; }
    
        /// <summary>
        /// Create a chat for a specific request inquiry.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int requestInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, requestInquiryId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Update the last read message in the chat of a specific request inquiry.
        /// </summary>
        public static BunqResponse<RequestInquiryChat> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int requestInquiryId, int requestInquiryChatId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestInquiryId, requestInquiryChatId), requestBytes, customHeaders);
    
            return FromJson<RequestInquiryChat>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get the chat for a specific request inquiry.
        /// </summary>
        public static BunqResponse<List<RequestInquiryChat>> List(ApiContext apiContext, int userId, int monetaryAccountId, int requestInquiryId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, requestInquiryId), urlParams, customHeaders);
    
            return FromJsonList<RequestInquiryChat>(responseRaw, OBJECT_TYPE);
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
    
            if (this.UnreadMessageCount != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RequestInquiryChat CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RequestInquiryChat>(json);
        }
    }
}
