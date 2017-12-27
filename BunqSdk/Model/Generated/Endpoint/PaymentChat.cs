using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the chat connected to a payment.
    /// </summary>
    public class PaymentChat : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/monetary-account/{1}/payment/{2}/chat";
        private const string EndpointUrlUpdate = "user/{0}/monetary-account/{1}/payment/{2}/chat/{3}";
        private const string EndpointUrlListing = "user/{0}/monetary-account/{1}/payment/{2}/chat";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldLastReadMessageId = "last_read_message_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ChatConversationPayment";
    
        /// <summary>
        /// The id of the chat conversation.
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
        /// The total number of unread messages in this conversation.
        /// </summary>
        [JsonProperty(PropertyName = "unread_message_count")]
        public int? UnreadMessageCount { get; private set; }
    
        /// <summary>
        /// Create a chat for a specific payment.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int paymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, monetaryAccountId, paymentId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Update the last read message in the chat of a specific payment.
        /// </summary>
        public static BunqResponse<PaymentChat> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int paymentId, int paymentChatId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, monetaryAccountId, paymentId, paymentChatId), requestBytes, customHeaders);
    
            return FromJson<PaymentChat>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get the chat for a specific payment.
        /// </summary>
        public static BunqResponse<List<PaymentChat>> List(ApiContext apiContext, int userId, int monetaryAccountId, int paymentId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, monetaryAccountId, paymentId), urlParams, customHeaders);
    
            return FromJsonList<PaymentChat>(responseRaw, ObjectType);
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
        public static PaymentChat CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentChat>(json);
        }
    }
}
