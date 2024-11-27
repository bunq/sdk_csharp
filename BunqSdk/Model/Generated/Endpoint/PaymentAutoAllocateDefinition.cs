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
    /// List all the definitions in a payment auto allocate.
    /// </summary>
    public class PaymentAutoAllocateDefinition : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}/definition";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TYPE = "type";
        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_FRACTION = "fraction";
        public const string FIELD_GINMON_COST_DISCLOSURE_ID = "ginmon_cost_disclosure_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentAutoAllocateDefinition";
    
        /// <summary>
        /// The type of definition.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The alias of the party we are allocating the money to.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The description for the payment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The amount to allocate.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The percentage of the triggering payment's amount to allocate.
        /// </summary>
        [JsonProperty(PropertyName = "fraction")]
        public double? Fraction { get; set; }
        /// <summary>
        /// The id of the ginmon cost disclosure, if this definition is a scheduled order.
        /// </summary>
        [JsonProperty(PropertyName = "ginmon_cost_disclosure_id")]
        public string GinmonCostDisclosureId { get; set; }
        /// <summary>
        /// The id of the PaymentAutoAllocateDefinition.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The timestamp when the PaymentAutoAllocateDefinition was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp when the PaymentAutoAllocateDefinition was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentAutoAllocateDefinition>> List(int paymentAutoAllocateId, int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentAutoAllocateId), urlParams, customHeaders);
    
            return FromJsonList<PaymentAutoAllocateDefinition>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Fraction != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentAutoAllocateDefinition CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentAutoAllocateDefinition>(json);
        }
    }
}
