using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// CashRegisters are virtual points of sale. They have a specific name and avatar, and optionally, a
    /// location.<br/>With a CashRegister you can create a Tab and then use a QR code to receive payments.<br/>Check out
    /// our Quickstart example to learn how you can easily <a href="/api/1/page/usecase-tab-payment">create Tab
    /// payments</a>.<br/><br/>Notification filters can be set on a CashRegister to receive callbacks. For more
    /// information check the <a href="/api/1/page/callbacks">dedicated callbacks page</a>.
    /// </summary>
    public class CashRegister : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/cash-register/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NAME = "name";
        public const string FIELD_STATUS = "status";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_LOCATION = "location";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
        public const string FIELD_TAB_TEXT_WAITING_SCREEN = "tab_text_waiting_screen";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CashRegister";
    
        /// <summary>
        /// The id of the created CashRegister.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the CashRegister's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the CashRegister's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The name of the CashRegister.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }
    
        /// <summary>
        /// The status of the CashRegister. Can be PENDING_APPROVAL, ACTIVE, DENIED or CLOSED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The Avatar of the CashRegister.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; private set; }
    
        /// <summary>
        /// The geolocation of the CashRegister. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Geolocation Location { get; private set; }
    
        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this CashRegister.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; private set; }
    
        /// <summary>
        /// The tab text for waiting screen of CashRegister.
        /// </summary>
        [JsonProperty(PropertyName = "tab_text_waiting_screen")]
        public List<TabTextWaitingScreen> TabTextWaitingScreen { get; private set; }
    
        /// <summary>
        /// Create a new CashRegister. Only an UserCompany can create a CashRegisters. They need to be created with
        /// status PENDING_APPROVAL, an bunq admin has to approve your CashRegister before you can use it. In the
        /// sandbox testing environment an CashRegister will be automatically approved immediately after creation.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get a specific CashRegister.
        /// </summary>
        public static BunqResponse<CashRegister> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CashRegister>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Modify or close an existing CashRegister. You must set the status back to PENDING_APPROVAL if you modify the
        /// name, avatar or location of a CashRegister. To close a cash register put its status to CLOSED.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, cashRegisterId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of CashRegister for a given user and monetary account.
        /// </summary>
        public static BunqResponse<List<CashRegister>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<CashRegister>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Avatar != null)
            {
                return false;
            }
    
            if (this.Location != null)
            {
                return false;
            }
    
            if (this.NotificationFilters != null)
            {
                return false;
            }
    
            if (this.TabTextWaitingScreen != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CashRegister CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CashRegister>(json);
        }
    }
}
