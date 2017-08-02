using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// view for reading the scheduled definitions.
    /// </summary>
    public class ScheduleUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/schedule";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ScheduleUser";

        public static List<ScheduleUser> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of scheduled definition for all accessible monetary accounts of the user. You can add the
        /// parameter type to filter the response. When
        /// type={SCHEDULE_DEFINITION_PAYMENT,SCHEDULE_DEFINITION_PAYMENT_BATCH} is provided only schedule definition
        /// object that relate to these definitions are returned.
        /// </summary>
        public static List<ScheduleUser> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<ScheduleUser>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
