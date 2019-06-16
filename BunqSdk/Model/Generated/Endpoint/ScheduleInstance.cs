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
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";

        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance/{3}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule/{2}/schedule-instance";

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
        public string State { get; set; }

        /// <summary>
        /// The schedule start time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// The schedule end time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// The message when the scheduled instance has run and failed due to user error.
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public List<Error> ErrorMessage { get; set; }

        /// <summary>
        /// The scheduled object. (Payment, PaymentBatch)
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_object")]
        public ScheduleAnchorObject ScheduledObject { get; set; }

        /// <summary>
        /// The result object of this schedule instance. (Payment, PaymentBatch)
        /// </summary>
        [JsonProperty(PropertyName = "result_object")]
        public ScheduleInstanceAnchorObject ResultObject { get; set; }

        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReference> RequestReferenceSplitTheBill { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<ScheduleInstance> Get(int scheduleId, int scheduleInstanceId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        scheduleId, scheduleInstanceId), new Dictionary<string, string>(), customHeaders);

            return FromJson<ScheduleInstance>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="state">Change the state of the scheduleInstance from FAILED_USER_ERROR to RETRY.</param>
        public static BunqResponse<int> Update(int scheduleId, int scheduleInstanceId, int? monetaryAccountId = null,
            string state = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATE, state},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        scheduleId, scheduleInstanceId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<ScheduleInstance>> List(int scheduleId, int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId), scheduleId), urlParams, customHeaders);

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

            if (this.RequestReferenceSplitTheBill != null)
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