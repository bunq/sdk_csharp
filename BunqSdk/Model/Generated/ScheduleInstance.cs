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
    /// view for reading, updating and listing the scheduled instance.
    /// </summary>
    public class ScheduleInstance : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATE = "state";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ScheduleInstance";

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
        /// The scheduled object.
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_object")]
        public BunqModel ScheduledObject { get; private set; }

        /// <summary>
        /// The result object of this schedule instance. (payment, payment batch)
        /// </summary>
        [JsonProperty(PropertyName = "result_object")]
        public BunqModel ResultObject { get; private set; }

        public static ScheduleInstance Get(ApiContext apiContext, int userId, int monetaryAccountId, int scheduleId,
            int scheduleInstanceId)
        {
            return Get(apiContext, userId, monetaryAccountId, scheduleId, scheduleInstanceId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static ScheduleInstance Get(ApiContext apiContext, int userId, int monetaryAccountId, int scheduleId,
            int scheduleInstanceId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, scheduleId, scheduleInstanceId),
                    customHeaders);

            return FromJson<ScheduleInstance>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int scheduleId, int scheduleInstanceId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, scheduleId, scheduleInstanceId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static int Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int scheduleId, int scheduleInstanceId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, scheduleId, scheduleInstanceId),
                    requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static List<ScheduleInstance> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int scheduleId)
        {
            return List(apiContext, userId, monetaryAccountId, scheduleId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static List<ScheduleInstance> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int scheduleId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, scheduleId),
                customHeaders);

            return FromJsonList<ScheduleInstance>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
