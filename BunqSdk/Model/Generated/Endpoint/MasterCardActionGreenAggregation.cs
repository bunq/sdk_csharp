using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Aggregation of how many card payments have been done with a Green Card in the current calendar month.
    /// </summary>
    public class MasterCardActionGreenAggregation : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/mastercard-action-green-aggregation";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MasterCardActionGreenAggregation";

        /// <summary>
        ///     The date of the aggregation.
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        ///     The percentage of card payments that were done with a Green Card.
        /// </summary>
        [JsonProperty(PropertyName = "percentage")]
        public string Percentage { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<List<MasterCardActionGreenAggregation>> List(
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<MasterCardActionGreenAggregation>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Date != null) return false;

            if (Percentage != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static MasterCardActionGreenAggregation CreateFromJsonString(string json)
        {
            return CreateFromJsonString<MasterCardActionGreenAggregation>(json);
        }
    }
}