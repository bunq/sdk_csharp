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
    /// Endpoint to create a quote for currency conversions.
    /// </summary>
    public class CurrencyConversionQuote : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/currency-conversion-quote";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/currency-conversion-quote/{2}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/currency-conversion-quote/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_CURRENCY_SOURCE = "currency_source";
        public const string FIELD_CURRENCY_TARGET = "currency_target";
        public const string FIELD_ORDER_TYPE = "order_type";
        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CurrencyConversionQuote";
        private const string OBJECT_TYPE_PUT = "";
    
        /// <summary>
        /// The amount to convert.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The currency we are converting.
        /// </summary>
        [JsonProperty(PropertyName = "currency_source")]
        public string CurrencySource { get; set; }
        /// <summary>
        /// The currency we are converting towards.
        /// </summary>
        [JsonProperty(PropertyName = "currency_target")]
        public string CurrencyTarget { get; set; }
        /// <summary>
        /// The type of the quote, SELL or BUY.
        /// </summary>
        [JsonProperty(PropertyName = "order_type")]
        public string OrderType { get; set; }
        /// <summary>
        /// The Alias of the party we are transferring the money to.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The status of the quote.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The id of the quote.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The timestamp of the quote's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the quote's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The amount to convert.
        /// </summary>
        [JsonProperty(PropertyName = "amount_source")]
        public Amount AmountSource { get; set; }
        /// <summary>
        /// The amount to convert to.
        /// </summary>
        [JsonProperty(PropertyName = "amount_target")]
        public Amount AmountTarget { get; set; }
        /// <summary>
        /// The conversion rate.
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }
        /// <summary>
        /// Timestamp for when this quote expires and the user should request a new one.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="amount">The amount to convert.</param>
        /// <param name="currencySource">The currency we are converting.</param>
        /// <param name="currencyTarget">The currency we are converting towards.</param>
        /// <param name="counterpartyAlias">The Alias of the party we are transferring the money to.</param>
        /// <param name="orderType">The type of the quote, SELL or BUY.</param>
        /// <param name="status">The status of the quote.</param>
        public static BunqResponse<int> Create(Amount amount, string currencySource, string currencyTarget, Pointer counterpartyAlias, int? monetaryAccountId= null, string orderType = null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_AMOUNT, amount},
    {FIELD_CURRENCY_SOURCE, currencySource},
    {FIELD_CURRENCY_TARGET, currencyTarget},
    {FIELD_ORDER_TYPE, orderType},
    {FIELD_COUNTERPARTY_ALIAS, counterpartyAlias},
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CurrencyConversionQuote> Get(int currencyConversionQuoteId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), currencyConversionQuoteId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CurrencyConversionQuote>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the quote.</param>
        public static BunqResponse<CurrencyConversionQuote> Update(int currencyConversionQuoteId, int? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), currencyConversionQuoteId), requestBytes, customHeaders);
    
            return FromJson<CurrencyConversionQuote>(responseRaw, OBJECT_TYPE_PUT);
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
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.AmountSource != null)
            {
                return false;
            }
    
            if (this.AmountTarget != null)
            {
                return false;
            }
    
            if (this.Rate != null)
            {
                return false;
            }
    
            if (this.TimeExpiry != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CurrencyConversionQuote CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CurrencyConversionQuote>(json);
        }
    }
}
