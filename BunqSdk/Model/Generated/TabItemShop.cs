using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// After you’ve created a Tab using /tab-usage-single or /tab-usage-multiple you can add items and attachments
    /// using tab-item. You can only add or modify TabItems of a Tab which status is OPEN. The amount of the TabItems
    /// will not influence the total_amount of the corresponding Tab. However, if you've created any TabItems for a Tab
    /// the sum of the amounts of these items must be equal to the total_amount of the Tab when you change its status to
    /// PAYABLE/WAITING_FOR_PAYMENT.
    /// </summary>
    public class TabItemShop : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_EAN_CODE = "ean_code";
        public const string FIELD_AVATAR_ATTACHMENT_UUID = "avatar_attachment_uuid";
        public const string FIELD_TAB_ATTACHMENT = "tab_attachment";
        public const string FIELD_QUANTITY = "quantity";
        public const string FIELD_AMOUNT = "amount";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        private const string ENDPOINT_URL_UPDATE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        private const string ENDPOINT_URL_DELETE =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/tab-item/{4}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabItem";

        /// <summary>
        /// The id of the created TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The TabItem's brief description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The TabItem's EAN code.
        /// </summary>
        [JsonProperty(PropertyName = "ean_code")]
        public string EanCode { get; private set; }

        /// <summary>
        /// A struct with an AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment")]
        public AttachmentPublic AvatarAttachment { get; private set; }

        /// <summary>
        /// A list of AttachmentTab attached to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<AttachmentTab> TabAttachment { get; private set; }

        /// <summary>
        /// The quantity of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; private set; }

        /// <summary>
        /// The money amount of the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUuid)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new TabItem for a given Tab.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUuid,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabItemShopId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Modify a TabItem from a given Tab.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int cashRegisterId, string tabUuid, int tabItemShopId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, cashRegisterId, tabUuid,
                        tabItemShopId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, int tabItemShopId)
        {
            return Delete(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Delete a specific TabItem from a Tab. This request returns an empty response.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, int tabItemShopId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, cashRegisterId, tabUuid,
                        tabItemShopId), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        public static BunqResponse<List<TabItemShop>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of TabItems from a given Tab.
        /// </summary>
        public static BunqResponse<List<TabItemShop>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    customHeaders);

            return FromJsonList<TabItemShop>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<TabItemShop> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, int tabItemShopId)
        {
            return Get(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific TabItem from a given Tab.
        /// </summary>
        public static BunqResponse<TabItemShop> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, string tabUuid, int tabItemShopId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId, tabUuid, tabItemShopId),
                    customHeaders);

            return FromJson<TabItemShop>(responseRaw, OBJECT_TYPE);
        }
    }
}
