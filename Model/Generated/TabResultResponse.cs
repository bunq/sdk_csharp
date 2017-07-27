using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
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
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/tab-result-response/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/tab-result-response";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabResultResponse";

        /// <summary>
        /// The Tab details.
        /// </summary>
        [JsonProperty(PropertyName = "tab")]
        public Tab Tab { get; private set; }

        /// <summary>
        /// The payment made for the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; private set; }

        public static TabResultResponse Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int tabResultResponseId)
        {
            return Get(apiContext, userId, monetaryAccountId, tabResultResponseId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Used to view a single TabResultResponse belonging to a tab.
        /// </summary>
        public static TabResultResponse Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int tabResultResponseId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, tabResultResponseId),
                    customHeaders);

            return FromJson<TabResultResponse>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<TabResultResponse> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Used to view a list of TabResultResponse objects belonging to a tab.
        /// </summary>
        public static List<TabResultResponse> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), customHeaders);

            return FromJsonList<TabResultResponse>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
