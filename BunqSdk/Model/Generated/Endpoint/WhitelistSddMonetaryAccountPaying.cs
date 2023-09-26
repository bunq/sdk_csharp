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
    /// Whitelist an SDD so that when one comes in, it is automatically accepted.
    /// </summary>
    public class WhitelistSddMonetaryAccountPaying : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/whitelist-sdd/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/whitelist-sdd";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "WhitelistSdd";
    
        /// <summary>
        /// The ID of the whitelist entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The account to which payments will come in before possibly being 'redirected' by the whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_incoming_id")]
        public int? MonetaryAccountIncomingId { get; set; }
        /// <summary>
        /// The account from which payments will be deducted when a transaction is matched with this whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_paying_id")]
        public int? MonetaryAccountPayingId { get; set; }
        /// <summary>
        /// The type of the SDD whitelist, can be CORE or B2B.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The status of the whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The credit scheme ID provided by the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "credit_scheme_identifier")]
        public string CreditSchemeIdentifier { get; set; }
        /// <summary>
        /// The mandate ID provided by the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "mandate_identifier")]
        public string MandateIdentifier { get; set; }
        /// <summary>
        /// The account to which payments will be paid.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The monthly maximum amount that can be deducted from the target account.
        /// </summary>
        [JsonProperty(PropertyName = "maximum_amount_per_month")]
        public Amount MaximumAmountPerMonth { get; set; }
        /// <summary>
        /// The user who created the whitelist entry.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public MonetaryAccountReference UserAliasCreated { get; set; }
    
        /// <summary>
        /// Get a specific SDD whitelist entry.
        /// </summary>
        public static BunqResponse<WhitelistSddMonetaryAccountPaying> Get(int whitelistSddMonetaryAccountPayingId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), whitelistSddMonetaryAccountPayingId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<WhitelistSddMonetaryAccountPaying>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Get a listing of all SDD whitelist entries for a target monetary account.
        /// </summary>
        public static BunqResponse<List<WhitelistSddMonetaryAccountPaying>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<WhitelistSddMonetaryAccountPaying>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountIncomingId != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountPayingId != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.CreditSchemeIdentifier != null)
            {
                return false;
            }
    
            if (this.MandateIdentifier != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.MaximumAmountPerMonth != null)
            {
                return false;
            }
    
            if (this.UserAliasCreated != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static WhitelistSddMonetaryAccountPaying CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<WhitelistSddMonetaryAccountPaying>(json);
        }
    }
}
