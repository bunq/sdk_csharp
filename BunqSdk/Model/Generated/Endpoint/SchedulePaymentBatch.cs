using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for schedule payment batches.
    /// </summary>
    public class SchedulePaymentBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/monetary-account/{1}/schedule-payment-batch";
        private const string EndpointUrlUpdate = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
        private const string EndpointUrlDelete = "user/{0}/monetary-account/{1}/schedule-payment-batch/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldPayments = "payments";
        public const string FieldSchedule = "schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ScheduledPaymentBatch";
    
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
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePaymentBatch> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int schedulePaymentBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, monetaryAccountId, schedulePaymentBatchId), requestBytes, customHeaders);
    
            return FromJson<SchedulePaymentBatch>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int schedulePaymentBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(EndpointUrlDelete, userId, monetaryAccountId, schedulePaymentBatchId), customHeaders);
    
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
        public static SchedulePaymentBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SchedulePaymentBatch>(json);
        }
    }
}
