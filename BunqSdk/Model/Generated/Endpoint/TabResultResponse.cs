using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view TabResultResponse objects belonging to a tab. A TabResultResponse is an object that holds details
    /// on a tab which has been paid from the provided monetary account.
    /// </summary>
    public class TabResultResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/tab-result-response/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/tab-result-response";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TabResultResponse";

        /// <summary>
        /// The Tab details.
        /// </summary>
        [JsonProperty(PropertyName = "tab")]
        public Tab Tab { get; set; }

        /// <summary>
        /// The payment made for the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReference> RequestReferenceSplitTheBill { get; set; }


        /// <summary>
        /// Used to view a single TabResultResponse belonging to a tab.
        /// </summary>
        public static BunqResponse<TabResultResponse> Get(int tabResultResponseId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        tabResultResponseId), new Dictionary<string, string>(), customHeaders);

            return FromJson<TabResultResponse>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Used to view a list of TabResultResponse objects belonging to a tab.
        /// </summary>
        public static BunqResponse<List<TabResultResponse>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<TabResultResponse>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Tab != null)
            {
                return false;
            }

            if (this.Payment != null)
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
        public static TabResultResponse CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TabResultResponse>(json);
        }
    }
}