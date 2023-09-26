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
    /// Used to get quotes from Transferwise. These can be used to initiate payments.
    /// </summary>
    public class TransferwiseQuote : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/transferwise-quote";
        protected const string ENDPOINT_URL_READ = "user/{0}/transferwise-quote/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY_SOURCE = "currency_source";
        public const string FIELD_CURRENCY_TARGET = "currency_target";
        public const string FIELD_AMOUNT_SOURCE = "amount_source";
        public const string FIELD_AMOUNT_TARGET = "amount_target";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwiseQuote";
    
        /// <summary>
        /// The source currency.
        /// </summary>
        [JsonProperty(PropertyName = "currency_source")]
        public string CurrencySource { get; set; }
        /// <summary>
        /// The target currency.
        /// </summary>
        [JsonProperty(PropertyName = "currency_target")]
        public string CurrencyTarget { get; set; }
        /// <summary>
        /// The source amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_source")]
        public Amount AmountSource { get; set; }
        /// <summary>
        /// The target amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_target")]
        public Amount AmountTarget { get; set; }
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
        /// The expiration timestamp of the quote.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
        /// <summary>
        /// The quote id Transferwise needs.
        /// </summary>
        [JsonProperty(PropertyName = "quote_id")]
        public string QuoteId { get; set; }
        /// <summary>
        /// The fee amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_fee")]
        public Amount AmountFee { get; set; }
        /// <summary>
        /// The rate.
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }
        /// <summary>
        /// The estimated delivery time.
        /// </summary>
        [JsonProperty(PropertyName = "time_delivery_estimate")]
        public string TimeDeliveryEstimate { get; set; }
    
        /// <summary>
        /// </summary>
        /// <param name="currencySource">The source currency.</param>
        /// <param name="currencyTarget">The target currency.</param>
        /// <param name="amountSource">The source amount. Required if target amount is left empty.</param>
        /// <param name="amountTarget">The target amount. Required if source amount is left empty.</param>
        public static BunqResponse<int> Create(string currencySource, string currencyTarget, Amount amountSource = null, Amount amountTarget = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_CURRENCY_SOURCE, currencySource},
    {FIELD_CURRENCY_TARGET, currencyTarget},
    {FIELD_AMOUNT_SOURCE, amountSource},
    {FIELD_AMOUNT_TARGET, amountTarget},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<TransferwiseQuote> Get(int transferwiseQuoteId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), transferwiseQuoteId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TransferwiseQuote>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.QuoteId != null)
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
    
            if (this.AmountFee != null)
            {
                return false;
            }
    
            if (this.Rate != null)
            {
                return false;
            }
    
            if (this.TimeDeliveryEstimate != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseQuote CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseQuote>(json);
        }
    }
}
