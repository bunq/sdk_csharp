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
    /// Endpoint to manage CurrencyCloud beneficiaries.
    /// </summary>
    public class CurrencyCloudBeneficiary : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/currency-cloud-beneficiary";
        protected const string ENDPOINT_URL_READ = "user/{0}/currency-cloud-beneficiary/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/currency-cloud-beneficiary";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NAME = "name";
        public const string FIELD_COUNTRY = "country";
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_PAYMENT_TYPE = "payment_type";
        public const string FIELD_LEGAL_ENTITY_TYPE = "legal_entity_type";
        public const string FIELD_ALL_FIELD = "all_field";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CurrencyCloudBeneficiary";
    
        /// <summary>
        /// The name of the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// The country of the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// The currency of the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The payment type this requirement is for.
        /// </summary>
        [JsonProperty(PropertyName = "payment_type")]
        public string PaymentType { get; set; }
        /// <summary>
        /// The legal entity type of the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "legal_entity_type")]
        public string LegalEntityType { get; set; }
        /// <summary>
        /// All fields that were required by CurrencyCloud. Obtained through the CurrencyCloudBeneficiaryRequirement
        /// listing.
        /// </summary>
        [JsonProperty(PropertyName = "all_field")]
        public List<string> AllField { get; set; }
        /// <summary>
        /// The id of the profile.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The timestamp of the beneficiaries creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the beneficiaries last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The account number to display for the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// The external identifier of the beneficiary.
        /// </summary>
        [JsonProperty(PropertyName = "external_identifier")]
        public string ExternalIdentifier { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="name">The name of the beneficiary.</param>
        /// <param name="country">The country of the beneficiary.</param>
        /// <param name="currency">The currency of the beneficiary.</param>
        /// <param name="paymentType">The payment type this requirement is for.</param>
        /// <param name="legalEntityType">The legal entity type of the beneficiary.</param>
        /// <param name="allField">All fields that were required by CurrencyCloud. Obtained through the CurrencyCloudBeneficiaryRequirement listing.</param>
        public static BunqResponse<int> Create(string name, string country, string currency, string paymentType, string legalEntityType, List<string> allField, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_NAME, name},
    {FIELD_COUNTRY, country},
    {FIELD_CURRENCY, currency},
    {FIELD_PAYMENT_TYPE, paymentType},
    {FIELD_LEGAL_ENTITY_TYPE, legalEntityType},
    {FIELD_ALL_FIELD, allField},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CurrencyCloudBeneficiary> Get(int currencyCloudBeneficiaryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), currencyCloudBeneficiaryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CurrencyCloudBeneficiary>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<CurrencyCloudBeneficiary>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<CurrencyCloudBeneficiary>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.AccountNumber != null)
            {
                return false;
            }
    
            if (this.Currency != null)
            {
                return false;
            }
    
            if (this.ExternalIdentifier != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CurrencyCloudBeneficiary CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CurrencyCloudBeneficiary>(json);
        }
    }
}
