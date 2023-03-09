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
    /// Endpoint for managing currency conversions.
    /// </summary>
    public class CurrencyConversion : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/currency-conversion";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/currency-conversion/{2}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CurrencyConversion";
    
        /// <summary>
        /// The id of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the conversion's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the conversion's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The status of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The expected delivery date of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "date_delivery_expected")]
        public string DateDeliveryExpected { get; set; }
    
        /// <summary>
        /// The rate of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }
    
        /// <summary>
        /// The amount of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The amount of the counter conversion.
        /// </summary>
        [JsonProperty(PropertyName = "counter_amount")]
        public Amount CounterAmount { get; set; }
    
        /// <summary>
        /// The group uuid of the conversion.
        /// </summary>
        [JsonProperty(PropertyName = "group_uuid")]
        public string GroupUuid { get; set; }
    
        /// <summary>
        /// The type of this conversion.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The order type, buying or selling.
        /// </summary>
        [JsonProperty(PropertyName = "order_type")]
        public string OrderType { get; set; }
    
        /// <summary>
        /// The label of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account")]
        public MonetaryAccountReference LabelMonetaryAccount { get; set; }
    
        /// <summary>
        /// The label of the counter monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "counter_label_monetary_account")]
        public MonetaryAccountReference CounterLabelMonetaryAccount { get; set; }
    
        /// <summary>
        /// The payment associated with this conversion.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<CurrencyConversion>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<CurrencyConversion>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CurrencyConversion> Get(int currencyConversionId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), currencyConversionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CurrencyConversion>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.DateDeliveryExpected != null)
            {
                return false;
            }
    
            if (this.Rate != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.CounterAmount != null)
            {
                return false;
            }
    
            if (this.GroupUuid != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.OrderType != null)
            {
                return false;
            }
    
            if (this.LabelMonetaryAccount != null)
            {
                return false;
            }
    
            if (this.CounterLabelMonetaryAccount != null)
            {
                return false;
            }
    
            if (this.Payment != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CurrencyConversion CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CurrencyConversion>(json);
        }
    }
}
