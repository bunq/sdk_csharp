using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to view TabResultInquiry objects belonging to a tab. A TabResultInquiry is an object that holds details on
    /// both the tab and a single payment made for that tab.
    /// </summary>
    public class TabResultInquiry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-result-inquiry/{4}";
        private const string ENDPOINT_URL_LISTING =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-result-inquiry";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabResultInquiry";

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

        public static TabResultInquiry Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid, int tabResultInquiryId)
        {
            return Get(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid, tabResultInquiryId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Used to view a single TabResultInquiry belonging to a tab.
        /// </summary>
        public static TabResultInquiry Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid, int tabResultInquiryId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId, tabUuid,
                        tabResultInquiryId), customHeaders);

            return FromJson<TabResultInquiry>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<TabResultInquiry> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Used to view a list of TabResultInquiry objects belonging to a tab.
        /// </summary>
        public static List<TabResultInquiry> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    customHeaders);

            return FromJsonList<TabResultInquiry>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
