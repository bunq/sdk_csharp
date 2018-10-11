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
    /// Create a batch of tab items.
    /// </summary>
    public class TabItemShopBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item-batch";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TAB_ITEMS = "tab_items";

        /// <summary>
        /// The list of tab items in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "tab_items")]
        public List<TabItemShop> TabItems { get; set; }

        /// <summary>
        /// Create tab items as a batch.
        /// </summary>
        /// <param name="tabItems">The list of tab items we want to create in a single batch. Limited to 50 items per batch.</param>
        public static BunqResponse<int> Create(int cashRegisterId, string tabUuid, List<TabItemShop> tabItems,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_TAB_ITEMS, tabItems},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, tabUuid), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.TabItems != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TabItemShopBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabItemShopBatch>(json);
        }
    }
}