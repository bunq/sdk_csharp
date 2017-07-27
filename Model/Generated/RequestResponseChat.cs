using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Manage the chat connected to a request response. In the same way a request inquiry and a request response are
    /// created together, so that each side of the interaction can work on a different object, also a request inquiry
    /// chat and a request response chat are created at the same time. See 'request-inquiry-chat' for the chat endpoint
    /// for the inquiring user.
    /// </summary>
    public class RequestResponseChat : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_LAST_READ_MESSAGE_ID = "last_read_message_id";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-response/{2}/chat";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-response/{2}/chat/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-response/{2}/chat";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestResponseChat";

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

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int requestResponseId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, requestResponseId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a chat for a specific request response.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int requestResponseId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, requestResponseId),
                    requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static RequestResponseChat Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int requestResponseId, int requestResponseChatId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, requestResponseId, requestResponseChatId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Update the last read message in the chat of a specific request response.
        /// </summary>
        public static RequestResponseChat Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int requestResponseId, int requestResponseChatId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestResponseId,
                        requestResponseChatId), requestBytes, customHeaders);

            return FromJson<RequestResponseChat>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<RequestResponseChat> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestResponseId)
        {
            return List(apiContext, userId, monetaryAccountId, requestResponseId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the chat for a specific request response.
        /// </summary>
        public static List<RequestResponseChat> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestResponseId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, requestResponseId),
                    customHeaders);

            return FromJsonList<RequestResponseChat>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
