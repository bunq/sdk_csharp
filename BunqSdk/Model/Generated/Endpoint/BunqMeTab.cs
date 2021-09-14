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
    /// bunq.me tabs allows you to create a payment request and share the link through e-mail, chat, etc. Multiple
    /// persons are able to respond to the payment request and pay through bunq, iDeal or SOFORT.
    /// </summary>
    public class BunqMeTab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/bunqme-tab";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/bunqme-tab/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/bunqme-tab";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/bunqme-tab/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_BUNQME_TAB_ENTRY = "bunqme_tab_entry";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BunqMeTab";
    
        /// <summary>
        /// The bunq.me entry containing the payment information.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_tab_entry")]
        public BunqMeTabEntry BunqmeTabEntry { get; set; }
    
        /// <summary>
        /// The status of the bunq.me. Can be WAITING_FOR_PAYMENT, CANCELLED or EXPIRED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The id of the created bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The timestamp of when the bunq.me expired or will expire.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
    
        /// <summary>
        /// The id of the MonetaryAccount the bunq.me was sent from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The type of the bunq.me Tab. Can be BUNQ_ME or SPLIT_RECEIPT.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the User and the MonetaryAccount that created the
        /// bunq.me link.
        /// </summary>
        [JsonProperty(PropertyName = "alias_monetary_account")]
        public MonetaryAccountReference AliasMonetaryAccount { get; set; }
    
        /// <summary>
        /// The url that points to the bunq.me page.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_tab_share_url")]
        public string BunqmeTabShareUrl { get; set; }
    
        /// <summary>
        /// The bunq.me tab entries attached to this bunq.me Tab.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_tab_entries")]
        public List<BunqMeTabEntry> BunqmeTabEntries { get; set; }
    
        /// <summary>
        /// The list of bunq.me result Inquiries successfully made and paid.
        /// </summary>
        [JsonProperty(PropertyName = "result_inquiries")]
        public List<BunqMeTabResultInquiry> ResultInquiries { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="bunqmeTabEntry">The bunq.me entry containing the payment information.</param>
        /// <param name="status">The status of the bunq.me. Ignored in POST requests but can be used for cancelling the bunq.me by setting status as CANCELLED with a PUT request.</param>
        public static BunqResponse<int> Create(BunqMeTabEntry bunqmeTabEntry, int? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_BUNQME_TAB_ENTRY, bunqmeTabEntry},
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the bunq.me. Ignored in POST requests but can be used for cancelling the bunq.me by setting status as CANCELLED with a PUT request.</param>
        public static BunqResponse<int> Update(int bunqMeTabId, int? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), bunqMeTabId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<BunqMeTab>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<BunqMeTab>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<BunqMeTab> Get(int bunqMeTabId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), bunqMeTabId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<BunqMeTab>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.AliasMonetaryAccount != null)
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
    
            if (this.BunqmeTabEntries != null)
            {
                return false;
            }
    
            if (this.ResultInquiries != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BunqMeTab CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeTab>(json);
        }
    }
}
