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
    /// Endpoint for schedule payment batches.
    /// </summary>
    public class SchedulePaymentBatchApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/schedule-payment-batch";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENTS = "payments";
        public const string FIELD_SCHEDULE = "schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ScheduledPaymentBatch";
    
        /// <summary>
        /// The payment details.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<SchedulePaymentEntryObject> Payments { get; set; }
        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public ScheduleApiObject Schedule { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePaymentBatchApiObject> Get(long schedulePaymentBatchId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), schedulePaymentBatchId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<SchedulePaymentBatchApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="payments">The payment details.</param>
        /// <param name="schedule">The schedule details when creating a scheduled payment.</param>
        public static BunqResponse<long> Create(List<SchedulePaymentEntryObject> payments, ScheduleApiObject schedule, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_PAYMENTS, payments},
    {FIELD_SCHEDULE, schedule},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="payments">The payment details.</param>
        /// <param name="schedule">The schedule details when creating a scheduled payment.</param>
        public static BunqResponse<long> Update(long schedulePaymentBatchId, long? monetaryAccountId= null, List<SchedulePaymentEntryObject> payments = null, ScheduleApiObject schedule = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_PAYMENTS, payments},
    {FIELD_SCHEDULE, schedule},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), schedulePaymentBatchId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(long schedulePaymentBatchId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), schedulePaymentBatchId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payments != null)
            {
                return false;
            }
    
            if (this.Schedule != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static SchedulePaymentBatchApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SchedulePaymentBatchApiObject>(json);
        }
    }
}
