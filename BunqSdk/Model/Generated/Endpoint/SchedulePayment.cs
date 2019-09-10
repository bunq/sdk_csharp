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
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/schedule-payment";

        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule-payment/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule-payment";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/schedule-payment/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENT = "payment";

        public const string FIELD_SCHEDULE = "schedule";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ScheduledPayment";

        private const string OBJECT_TYPE_PUT = "ScheduledPayment";

        /// <summary>
        /// The payment details.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public SchedulePaymentEntry Payment { get; set; }

        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public Schedule Schedule { get; set; }

        /// <summary>
        /// The schedule status, options: ACTIVE, FINISHED, CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="payment">The payment details.</param>
        /// <param name="schedule">The schedule details when creating or updating a scheduled payment.</param>
        public static BunqResponse<int> Create(SchedulePaymentEntry payment, Schedule schedule,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_PAYMENT, payment},
                {FIELD_SCHEDULE, schedule},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int schedulePaymentId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        schedulePaymentId), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<SchedulePayment> Get(int schedulePaymentId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        schedulePaymentId), new Dictionary<string, string>(), customHeaders);

            return FromJson<SchedulePayment>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<SchedulePayment>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<SchedulePayment>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="payment">The payment details.</param>
        /// <param name="schedule">The schedule details when creating or updating a scheduled payment.</param>
        public static BunqResponse<SchedulePayment> Update(int schedulePaymentId, int? monetaryAccountId = null,
            SchedulePaymentEntry payment = null, Schedule schedule = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_PAYMENT, payment},
                {FIELD_SCHEDULE, schedule},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        schedulePaymentId), requestBytes, customHeaders);

            return FromJson<SchedulePayment>(responseRaw, OBJECT_TYPE_PUT);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }

            if (this.Schedule != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static SchedulePayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SchedulePayment>(json);
        }
    }
}