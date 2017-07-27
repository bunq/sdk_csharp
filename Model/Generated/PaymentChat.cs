using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Manage the chat connected to a payment.
    /// </summary>
    public class PaymentChat : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_LAST_READ_MESSAGE_ID = "last_read_message_id";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment/{2}/chat";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment/{2}/chat/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment/{2}/chat";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ChatConversationPayment";

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

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int paymentId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, paymentId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a chat for a specific payment.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int paymentId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, paymentId),
                requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static PaymentChat Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int paymentId, int paymentChatId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, paymentId, paymentChatId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Update the last read message in the chat of a specific payment.
        /// </summary>
        public static PaymentChat Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int paymentId, int paymentChatId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, paymentId, paymentChatId),
                    requestBytes, customHeaders);

            return FromJson<PaymentChat>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<PaymentChat> List(ApiContext apiContext, int userId, int monetaryAccountId, int paymentId)
        {
            return List(apiContext, userId, monetaryAccountId, paymentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the chat for a specific payment.
        /// </summary>
        public static List<PaymentChat> List(ApiContext apiContext, int userId, int monetaryAccountId, int paymentId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, paymentId),
                customHeaders);

            return FromJsonList<PaymentChat>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
