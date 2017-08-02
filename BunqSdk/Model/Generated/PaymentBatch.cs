using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Create a payment batch, or show the payment batches of a monetary account.
    /// </summary>
    public class PaymentBatch : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENTS = "payments";
        public const string FIELD_BUNQTO_STATUS = "bunqto_status";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment-batch";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-batch";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "PaymentBatch";

        /// <summary>
        /// The list of mutations that were made.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a payment batch by sending an array of single payment objects, that will become part of the batch.
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
            int monetaryAccountId, int paymentBatchId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, paymentBatchId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Revoke a bunq.to payment batch. The status of all the payments will be set to REVOKED.
        /// </summary>
        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int paymentBatchId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, paymentBatchId),
                requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static PaymentBatch Get(ApiContext apiContext, int userId, int monetaryAccountId, int paymentBatchId)
        {
            return Get(apiContext, userId, monetaryAccountId, paymentBatchId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return the details of a specific payment batch.
        /// </summary>
        public static PaymentBatch Get(ApiContext apiContext, int userId, int monetaryAccountId, int paymentBatchId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, paymentBatchId),
                customHeaders);

            return FromJson<PaymentBatch>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<PaymentBatch> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return all the payment batches for a monetary account.
        /// </summary>
        public static List<PaymentBatch> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), customHeaders);

            return FromJsonList<PaymentBatch>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
