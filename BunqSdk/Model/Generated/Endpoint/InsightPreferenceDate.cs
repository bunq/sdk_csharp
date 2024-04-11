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
    /// Used to allow users to set insight/budget preferences.
    /// </summary>
    public class InsightPreferenceDate : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/insight-preference-date";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DAY_OF_MONTH = "day_of_month";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "InsightPreferenceDate";
    
        /// <summary>
        /// The day of month at which budgeting/insights should start.
        /// </summary>
        [JsonProperty(PropertyName = "day_of_month")]
        public int? DayOfMonth { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<InsightPreferenceDate>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<InsightPreferenceDate>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.DayOfMonth != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static InsightPreferenceDate CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<InsightPreferenceDate>(json);
        }
    }
}
