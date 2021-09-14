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
    /// Used to get insights about transactions between given time range.
    /// </summary>
    public class Insight : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/insights";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "InsightCategory";
    
        /// <summary>
        /// The category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// The translated category.
        /// </summary>
        [JsonProperty(PropertyName = "category_translated")]
        public string CategoryTranslated { get; set; }
    
        /// <summary>
        /// The total amount of the transactions in the category.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public Amount AmountTotal { get; set; }
    
        /// <summary>
        /// The number of the transactions in the category.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_transactions")]
        public double? NumberOfTransactions { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<Insight>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<Insight>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.CategoryTranslated != null)
            {
                return false;
            }
    
            if (this.AmountTotal != null)
            {
                return false;
            }
    
            if (this.NumberOfTransactions != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Insight CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Insight>(json);
        }
    }
}
