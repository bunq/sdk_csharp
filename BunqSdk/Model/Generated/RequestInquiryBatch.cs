using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Create a batch of requests for payment, or show the request batches of a monetary account.
    /// </summary>
    public class RequestInquiryBatch : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_REQUEST_INQUIRIES = "request_inquiries";
        public const string FIELD_STATUS = "status";
        public const string FIELD_TOTAL_AMOUNT_INQUIRED = "total_amount_inquired";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry-batch";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry-batch";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestInquiryBatch";

        /// <summary>
        /// The list of requests that were made.
        /// </summary>
        [JsonProperty(PropertyName = "request_inquiries")]
        public List<RequestInquiry> RequestInquiries { get; private set; }

        /// <summary>
        /// The total amount originally inquired for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_inquired")]
        public Amount TotalAmountInquired { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a request batch by sending an array of single request objects, that will become part of the batch.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes,
                customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int requestInquiryBatchId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, requestInquiryBatchId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Revoke a request batch. The status of all the requests will be set to REVOKED.
        /// </summary>
        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int requestInquiryBatchId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestInquiryBatchId),
                    requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static RequestInquiryBatch Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestInquiryBatchId)
        {
            return Get(apiContext, userId, monetaryAccountId, requestInquiryBatchId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return the details of a specific request batch.
        /// </summary>
        public static RequestInquiryBatch Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestInquiryBatchId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, requestInquiryBatchId),
                    customHeaders);

            return FromJson<RequestInquiryBatch>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<RequestInquiryBatch> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return all the request batches for a monetary account.
        /// </summary>
        public static List<RequestInquiryBatch> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), customHeaders);

            return FromJsonList<RequestInquiryBatch>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
