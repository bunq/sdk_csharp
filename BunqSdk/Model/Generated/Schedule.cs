using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// view for reading the scheduled definitions.
    /// </summary>
    public class Schedule : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Schedule";

        public static BunqResponse<Schedule> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int scheduleId)
        {
            return Get(apiContext, userId, monetaryAccountId, scheduleId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific schedule definition for a given monetary account.
        /// </summary>
        public static BunqResponse<Schedule> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int scheduleId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, scheduleId),
                customHeaders);

            return FromJson<Schedule>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<Schedule>> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of scheduled definition for a given monetary account. You can add the parameter type to
        /// filter the response. When type={SCHEDULE_DEFINITION_PAYMENT,SCHEDULE_DEFINITION_PAYMENT_BATCH} is provided
        /// only schedule definition object that relate to these definitions are returned.
        /// </summary>
        public static BunqResponse<List<Schedule>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId),
                customHeaders);

            return FromJsonList<Schedule>(responseRaw, OBJECT_TYPE);
        }
    }
}
