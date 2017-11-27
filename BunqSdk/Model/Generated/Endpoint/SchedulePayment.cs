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
    /// Endpoint for schedule payments.
    /// </summary>
    public class SchedulePayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/schedule-payment";
        private const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule-payment";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENT = "payment";
        public const string FIELD_SCHEDULE = "schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ScheduledPayment";
    
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
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int schedulePaymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, schedulePaymentId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePayment> Get(ApiContext apiContext, int userId, int monetaryAccountId, int schedulePaymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, schedulePaymentId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<SchedulePayment>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<SchedulePayment>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<SchedulePayment>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePayment> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int schedulePaymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, schedulePaymentId), requestBytes, customHeaders);
    
            return FromJson<SchedulePayment>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }
    
            if (this.Schedule != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
