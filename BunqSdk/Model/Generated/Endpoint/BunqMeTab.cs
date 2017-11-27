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
    /// bunq.me tabs allows you to create a payment request and share the link through e-mail, chat, etc. Multiple
    /// persons are able to respond to the payment request and pay through bunq, iDeal or SOFORT.
    /// </summary>
    public class BunqMeTab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/bunqme-tab";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/bunqme-tab/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/bunqme-tab";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/bunqme-tab/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_BUNQME_TAB_ENTRY = "bunqme_tab_entry";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "BunqMeTab";
    
        /// <summary>
        /// The id of the created bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The timestamp of when the bunq.me expired or will expire.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; private set; }
    
        /// <summary>
        /// The id of the MonetaryAccount the bunq.me was sent from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The status of the bunq.me. Can be WAITING_FOR_PAYMENT, CANCELLED or EXPIRED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The url that points to the bunq.me page.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_tab_share_url")]
        public string BunqmeTabShareUrl { get; private set; }
    
        /// <summary>
        /// The bunq.me entry containing the payment information.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_tab_entry")]
        public BunqMeTabEntry BunqmeTabEntry { get; private set; }
    
        /// <summary>
        /// The list of bunq.me result Inquiries successfully made and paid.
        /// </summary>
        [JsonProperty(PropertyName = "result_inquiries")]
        public List<BunqMeTabResultInquiry> ResultInquiries { get; private set; }
    
        /// <summary>
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
        /// </summary>
        public static BunqResponse<BunqMeTab> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int bunqMeTabId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, bunqMeTabId), requestBytes, customHeaders);
    
            return FromJson<BunqMeTab>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<BunqMeTab>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<BunqMeTab>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<BunqMeTab> Get(ApiContext apiContext, int userId, int monetaryAccountId, int bunqMeTabId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, bunqMeTabId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<BunqMeTab>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
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
    
            if (this.TimeExpiry != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.BunqmeTabShareUrl != null)
            {
                return false;
            }
    
            if (this.BunqmeTabEntry != null)
            {
                return false;
            }
    
            if (this.ResultInquiries != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
