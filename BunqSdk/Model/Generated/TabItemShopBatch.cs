using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Create a batch of tab items.
    /// </summary>
    public class TabItemShopBatch : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TAB_ITEMS = "tab_items";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item-batch";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabItemShopBatch";

        /// <summary>
        /// The list of tab items in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "tab_items")]
        public List<TabItemShop> TabItems { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int cashRegisterId, string tabUuid)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Create tab items as a batch.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, int cashRegisterId, string tabUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response =
                apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }
    }
}
