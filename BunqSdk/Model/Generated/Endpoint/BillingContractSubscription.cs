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
    /// Show the subscription billing contract for the authenticated user.
    /// </summary>
    public class BillingContractSubscription : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_SUBSCRIPTION_TYPE = "subscription_type";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/billing-contract-subscription";
        private const string ENDPOINT_URL_LISTING = "user/{0}/billing-contract-subscription";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "BillingContractSubscription";
    
        /// <summary>
        /// The id of the billing contract.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp when the billing contract was made.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp when the billing contract was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The date from when the billing contract is valid.
        /// </summary>
        [JsonProperty(PropertyName = "contract_date_start")]
        public string ContractDateStart { get; private set; }
    
        /// <summary>
        /// The date until when the billing contract is valid.
        /// </summary>
        [JsonProperty(PropertyName = "contract_date_end")]
        public string ContractDateEnd { get; private set; }
    
        /// <summary>
        /// The version of the billing contract.
        /// </summary>
        [JsonProperty(PropertyName = "contract_version")]
        public int? ContractVersion { get; private set; }
    
        /// <summary>
        /// The subscription type of the user. Can be one of PERSON_SUPER_LIGHT_V1, PERSON_LIGHT_V1, PERSON_MORE_V1,
        /// PERSON_FREE_V1, PERSON_PREMIUM_V1, COMPANY_V1, or COMPANY_V2.
        /// </summary>
        [JsonProperty(PropertyName = "subscription_type")]
        public string SubscriptionType { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<BillingContractSubscription> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);
    
            return FromJson<BillingContractSubscription>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get all subscription billing contract for the authenticated user.
        /// </summary>
        public static BunqResponse<List<BillingContractSubscription>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), urlParams, customHeaders);
    
            return FromJsonList<BillingContractSubscription>(responseRaw, OBJECT_TYPE);
        }
    }
}
