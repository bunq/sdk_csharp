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
    /// Used to manage recipient accounts with Transferwise.
    /// </summary>
    public class TransferwiseAccountQuote : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/transferwise-quote/{1}/transferwise-recipient";
        protected const string ENDPOINT_URL_READ = "user/{0}/transferwise-quote/{1}/transferwise-recipient/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/transferwise-quote/{1}/transferwise-recipient";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/transferwise-quote/{1}/transferwise-recipient/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_COUNTRY = "country";
        public const string FIELD_NAME_ACCOUNT_HOLDER = "name_account_holder";
        public const string FIELD_TYPE = "type";
        public const string FIELD_DETAIL = "detail";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwiseRecipient";
    
        /// <summary>
        /// The country of the account.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// The name of the account holder.
        /// </summary>
        [JsonProperty(PropertyName = "name_account_holder")]
        public string NameAccountHolder { get; set; }
        /// <summary>
        /// The chosen recipient account type. The possible options are provided dynamically in the response endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The fields which were specified as "required" and have since been filled by the user. Always provide the
        /// full list.
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public List<TransferwiseRequirementField> Detail { get; set; }
        /// <summary>
        /// Transferwise's id of the account.
        /// </summary>
        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }
        /// <summary>
        /// The currency the account.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The account number.
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// The bank code.
        /// </summary>
        [JsonProperty(PropertyName = "bank_code")]
        public string BankCode { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="nameAccountHolder">The name of the account holder.</param>
        /// <param name="type">The chosen recipient account type. The possible options are provided dynamically in the response endpoint.</param>
        /// <param name="country">The country of the receiving account.</param>
        /// <param name="detail">The fields which were specified as "required" and have since been filled by the user. Always provide the full list.</param>
        public static BunqResponse<int> Create(int transferwiseQuoteId, string nameAccountHolder, string type, string country = null, List<TransferwiseRequirementField> detail = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_COUNTRY, country},
    {FIELD_NAME_ACCOUNT_HOLDER, nameAccountHolder},
    {FIELD_TYPE, type},
    {FIELD_DETAIL, detail},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), transferwiseQuoteId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<TransferwiseAccountQuote> Get(int transferwiseQuoteId, int transferwiseAccountQuoteId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), transferwiseQuoteId, transferwiseAccountQuoteId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TransferwiseAccountQuote>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<TransferwiseAccountQuote>> List(int transferwiseQuoteId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), transferwiseQuoteId), urlParams, customHeaders);
    
            return FromJsonList<TransferwiseAccountQuote>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int transferwiseQuoteId, int transferwiseAccountQuoteId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), transferwiseQuoteId, transferwiseAccountQuoteId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AccountId != null)
            {
                return false;
            }
    
            if (this.Currency != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            if (this.NameAccountHolder != null)
            {
                return false;
            }
    
            if (this.AccountNumber != null)
            {
                return false;
            }
    
            if (this.BankCode != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseAccountQuote CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseAccountQuote>(json);
        }
    }
}
