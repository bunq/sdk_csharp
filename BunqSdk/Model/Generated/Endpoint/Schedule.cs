using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
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
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/schedule/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Schedule";
    
        /// <summary>
        /// Get a specific schedule definition for a given monetary account.
        /// </summary>
        public static BunqResponse<Schedule> Get(ApiContext apiContext, int userId, int monetaryAccountId, int scheduleId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, scheduleId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<Schedule>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get a collection of scheduled definition for a given monetary account. You can add the parameter type to
        /// filter the response. When type={SCHEDULE_DEFINITION_PAYMENT,SCHEDULE_DEFINITION_PAYMENT_BATCH} is provided
        /// only schedule definition object that relate to these definitions are returned.
        /// </summary>
        public static BunqResponse<List<Schedule>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<Schedule>(responseRaw, OBJECT_TYPE);
        }
    }
}
