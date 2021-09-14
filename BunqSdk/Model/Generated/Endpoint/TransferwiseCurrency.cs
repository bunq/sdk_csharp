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
    /// Used to get a list of supported currencies for Transferwise.
    /// </summary>
    public class TransferwiseCurrency : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/transferwise-currency";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwiseCurrency";
    
        /// <summary>
        /// The currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    
        /// <summary>
        /// The currency name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        /// <summary>
        /// The country code associated with the currency.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<TransferwiseCurrency>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<TransferwiseCurrency>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Currency != null)
            {
                return false;
            }
    
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseCurrency CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseCurrency>(json);
        }
    }
}
