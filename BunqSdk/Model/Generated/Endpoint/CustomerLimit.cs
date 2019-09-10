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
    /// Show the limits for the authenticated user.
    /// </summary>
    public class CustomerLimit : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/limit";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CustomerLimit";
    
        /// <summary>
        /// The limit of monetary accounts.
        /// </summary>
        [JsonProperty(PropertyName = "limit_monetary_account")]
        public int? LimitMonetaryAccount { get; set; }
    
        /// <summary>
        /// The amount of additional monetary accounts you can create.
        /// </summary>
        [JsonProperty(PropertyName = "limit_monetary_account_remaining")]
        public int? LimitMonetaryAccountRemaining { get; set; }
    
        /// <summary>
        /// The limit of Maestro cards.
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_debit_maestro")]
        public int? LimitCardDebitMaestro { get; set; }
    
        /// <summary>
        /// The limit of MasterCard cards.
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_debit_mastercard")]
        public int? LimitCardDebitMastercard { get; set; }
    
        /// <summary>
        /// DEPRECTATED: The limit of wildcards, e.g. Maestro or MasterCard cards.
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_debit_wildcard")]
        public int? LimitCardDebitWildcard { get; set; }
    
        /// <summary>
        /// The limit of wildcards, e.g. Maestro or MasterCard cards.
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_wildcard")]
        public int? LimitCardWildcard { get; set; }
    
        /// <summary>
        /// DEPRECTATED: The limit of free replacement debit cards, replaced by: limit_card_replacement
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_debit_replacement")]
        public int? LimitCardDebitReplacement { get; set; }
    
        /// <summary>
        /// The limit of free replacement cards.
        /// </summary>
        [JsonProperty(PropertyName = "limit_card_replacement")]
        public int? LimitCardReplacement { get; set; }
    
        /// <summary>
        /// The maximum amount a user is allowed to spend in a month.
        /// </summary>
        [JsonProperty(PropertyName = "limit_amount_monthly")]
        public Amount LimitAmountMonthly { get; set; }
    
        /// <summary>
        /// The amount the user has spent in the last month.
        /// </summary>
        [JsonProperty(PropertyName = "spent_amount_monthly")]
        public Amount SpentAmountMonthly { get; set; }
    
    
        /// <summary>
        /// Get all limits for the authenticated user.
        /// </summary>
        public static BunqResponse<List<CustomerLimit>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<CustomerLimit>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.LimitMonetaryAccount != null)
            {
                return false;
            }
    
            if (this.LimitMonetaryAccountRemaining != null)
            {
                return false;
            }
    
            if (this.LimitCardDebitMaestro != null)
            {
                return false;
            }
    
            if (this.LimitCardDebitMastercard != null)
            {
                return false;
            }
    
            if (this.LimitCardDebitWildcard != null)
            {
                return false;
            }
    
            if (this.LimitCardWildcard != null)
            {
                return false;
            }
    
            if (this.LimitCardDebitReplacement != null)
            {
                return false;
            }
    
            if (this.LimitCardReplacement != null)
            {
                return false;
            }
    
            if (this.LimitAmountMonthly != null)
            {
                return false;
            }
    
            if (this.SpentAmountMonthly != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CustomerLimit CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CustomerLimit>(json);
        }
    }
}
