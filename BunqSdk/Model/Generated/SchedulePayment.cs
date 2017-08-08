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
    /// Endpoint for schedule payments.
    /// </summary>
    public class SchedulePayment : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENT = "payment";
        public const string FIELD_SCHEDULE = "schedule";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/schedule-payment";
        private const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule-payment";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "SchedulePayment";

        /// <summary>
        /// The payment details.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public SchedulePaymentEntry Payment { get; private set; }

        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public Schedule Schedule { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int schedulePaymentId)
        {
            return Delete(apiContext, userId, monetaryAccountId, schedulePaymentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int schedulePaymentId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, schedulePaymentId),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        public static BunqResponse<SchedulePayment> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int schedulePaymentId)
        {
            return Get(apiContext, userId, monetaryAccountId, schedulePaymentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePayment> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int schedulePaymentId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, schedulePaymentId),
                    customHeaders);

            return FromJson<SchedulePayment>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<SchedulePayment>> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<SchedulePayment>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId),
                customHeaders);

            return FromJsonList<SchedulePayment>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int schedulePaymentId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, schedulePaymentId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int schedulePaymentId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, schedulePaymentId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }
    }
}
