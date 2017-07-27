using System;
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
    /// Endpoint for schedule payment batches.
    /// </summary>
    public class SchedulePaymentBatch : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENTS = "payments";
        public const string FIELD_SCHEDULE = "schedule";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/schedule-payment-batch";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
        private const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "SchedulePaymentBatch";

        /// <summary>
        /// The payment details.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<SchedulePaymentEntry> Payments { get; private set; }

        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public Schedule Schedule { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
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
            int monetaryAccountId, int schedulePaymentBatchId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, schedulePaymentBatchId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int schedulePaymentBatchId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, schedulePaymentBatchId),
                    requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static void Delete(ApiContext apiContext, int userId, int monetaryAccountId, int schedulePaymentBatchId)
        {
            Delete(apiContext, userId, monetaryAccountId, schedulePaymentBatchId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static void Delete(ApiContext apiContext, int userId, int monetaryAccountId, int schedulePaymentBatchId,
            IDictionary<String, String> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, schedulePaymentBatchId),
                customHeaders);
        }
    }
}
