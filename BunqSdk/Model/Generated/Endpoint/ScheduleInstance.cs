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
    /// view for reading, updating and listing the scheduled instance.
    /// </summary>
    public class ScheduleInstance : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATE = "state";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ScheduledInstance";
    
        /// <summary>
        /// The state of the scheduleInstance. (FINISHED_SUCCESSFULLY, RETRY, FAILED_USER_ERROR)
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; private set; }
    
        /// <summary>
        /// The schedule start time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_start")]
        public string TimeStart { get; private set; }
    
        /// <summary>
        /// The schedule end time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_end")]
        public string TimeEnd { get; private set; }
    
        /// <summary>
        /// The message when the scheduled instance has run and failed due to user error.
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public List<Error> ErrorMessage { get; private set; }
    
        /// <summary>
        /// The scheduled object. (Payment, PaymentBatch)
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_object")]
        public ScheduleAnchorObject ScheduledObject { get; private set; }
    
        /// <summary>
        /// The result object of this schedule instance. (Payment, PaymentBatch)
        /// </summary>
        [JsonProperty(PropertyName = "result_object")]
        public ScheduleInstanceAnchorObject ResultObject { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<ScheduleInstance> Get(ApiContext apiContext, int userId, int monetaryAccountId, int scheduleId, int scheduleInstanceId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, scheduleId, scheduleInstanceId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ScheduleInstance>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int scheduleId, int scheduleInstanceId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, scheduleId, scheduleInstanceId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<ScheduleInstance>> List(ApiContext apiContext, int userId, int monetaryAccountId, int scheduleId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, scheduleId), urlParams, customHeaders);
    
            return FromJsonList<ScheduleInstance>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.State != null)
            {
                return false;
            }
    
            if (this.TimeStart != null)
            {
                return false;
            }
    
            if (this.TimeEnd != null)
            {
                return false;
            }
    
            if (this.ErrorMessage != null)
            {
                return false;
            }
    
            if (this.ScheduledObject != null)
            {
                return false;
            }
    
            if (this.ResultObject != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ScheduleInstance CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ScheduleInstance>(json);
        }
    }
}
