using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Once your CashRegister has been activated you can use it to create Tabs. A Tab is a template for a payment. In
    /// contrast to requests a Tab is not pointed towards a specific user. Any user can pay the Tab as long as it is
    /// made visible by you. The creation of a Tab happens with /tab-usage-single or /tab-usage-multiple. A
    /// TabUsageSingle is a Tab that can be paid once. A TabUsageMultiple is a Tab that can be paid multiple times by
    /// different users.
    /// </summary>
    public class Tab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/tab";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Tab";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabUsageSingle")]
        public TabUsageSingle TabUsageSingle { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabUsageMultiple")]
        public TabUsageMultiple TabUsageMultiple { get; private set; }

        public static Tab Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid)
        {
            return Get(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific tab. This returns a TabUsageSingle or TabUsageMultiple.
        /// </summary>
        public static Tab Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    customHeaders);

            return FromJson<Tab>(response.Content.ReadAsStringAsync().Result);
        }

        public static List<Tab> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of tabs.
        /// </summary>
        public static List<Tab> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId),
                customHeaders);

            return FromJsonList<Tab>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
