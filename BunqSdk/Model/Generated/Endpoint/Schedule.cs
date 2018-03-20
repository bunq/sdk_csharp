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
    /// view for reading the scheduled definitions.
    /// </summary>
    public class Schedule : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TIME_START = "time_start";

        public const string FIELD_TIME_END = "time_end";
        public const string FIELD_RECURRENCE_UNIT = "recurrence_unit";
        public const string FIELD_RECURRENCE_SIZE = "recurrence_size";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Schedule";

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
        /// The schedule recurrence unit, options: ONCE, HOURLY, DAILY, WEEKLY, MONTHLY, YEARLY
        /// </summary>
        [JsonProperty(PropertyName = "recurrence_unit")]
        public string RecurrenceUnit { get; set; }

        /// <summary>
        /// The schedule recurrence size. For example size 4 and unit WEEKLY means the recurrence is every 4 weeks.
        /// </summary>
        [JsonProperty(PropertyName = "recurrence_size")]
        public int? RecurrenceSize { get; set; }

        /// <summary>
        /// The schedule status, options: ACTIVE, FINISHED, CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The scheduled object. (Payment, PaymentBatch)
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public ScheduleAnchorObject Object { get; set; }

        /// <summary>
        /// Get a specific schedule definition for a given monetary account.
        /// </summary>
        public static BunqResponse<Schedule> Get(int scheduleId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        scheduleId), new Dictionary<string, string>(), customHeaders);

            return FromJson<Schedule>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a collection of scheduled definition for a given monetary account. You can add the parameter type to
        /// filter the response. When type={SCHEDULE_DEFINITION_PAYMENT,SCHEDULE_DEFINITION_PAYMENT_BATCH} is provided
        /// only schedule definition object that relate to these definitions are returned.
        /// </summary>
        public static BunqResponse<List<Schedule>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<Schedule>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.TimeStart != null)
            {
                return false;
            }

            if (this.TimeEnd != null)
            {
                return false;
            }

            if (this.RecurrenceUnit != null)
            {
                return false;
            }

            if (this.RecurrenceSize != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.Object != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Schedule CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Schedule>(json);
        }
    }
}