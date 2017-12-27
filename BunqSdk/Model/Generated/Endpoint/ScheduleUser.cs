using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// view for reading the scheduled definitions.
    /// </summary>
    public class ScheduleUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlListing = "user/{0}/schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ScheduleUser";
    
        /// <summary>
        /// Get a collection of scheduled definition for all accessible monetary accounts of the user. You can add the
        /// parameter type to filter the response. When
        /// type={SCHEDULE_DEFINITION_PAYMENT,SCHEDULE_DEFINITION_PAYMENT_BATCH} is provided only schedule definition
        /// object that relate to these definitions are returned.
        /// </summary>
        public static BunqResponse<List<ScheduleUser>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<ScheduleUser>(responseRaw, ObjectType);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ScheduleUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ScheduleUser>(json);
        }
    }
}
