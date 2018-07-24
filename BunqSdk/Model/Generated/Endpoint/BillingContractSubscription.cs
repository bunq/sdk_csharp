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
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/billing-contract-subscription";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/billing-contract-subscription";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_SUBSCRIPTION_TYPE = "subscription_type";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BillingContractSubscription";

        /// <summary>
        /// The id of the billing contract.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp when the billing contract was made.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp when the billing contract was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The date from when the billing contract is valid.
        /// </summary>
        [JsonProperty(PropertyName = "contract_date_start")]
        public string ContractDateStart { get; set; }

        /// <summary>
        /// The date until when the billing contract is valid.
        /// </summary>
        [JsonProperty(PropertyName = "contract_date_end")]
        public string ContractDateEnd { get; set; }

        /// <summary>
        /// The version of the billing contract.
        /// </summary>
        [JsonProperty(PropertyName = "contract_version")]
        public int? ContractVersion { get; set; }

        /// <summary>
        /// The subscription type of the user. Can be one of PERSON_SUPER_LIGHT_V1, PERSON_LIGHT_V1, PERSON_MORE_V1,
        /// PERSON_FREE_V1, PERSON_PREMIUM_V1, COMPANY_V1, or COMPANY_V2.
        /// </summary>
        [JsonProperty(PropertyName = "subscription_type")]
        public string SubscriptionType { get; set; }

        /// <summary>
        /// The subscription status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The subscription substatus.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="subscriptionType">The subscription type of the user. Can be one of PERSON_LIGHT_V1, PERSON_MORE_V1, PERSON_FREE_V1, PERSON_PREMIUM_V1, COMPANY_V1, or COMPANY_V2.</param>
        public static BunqResponse<int> Create(string subscriptionType,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_SUBSCRIPTION_TYPE, subscriptionType},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get all subscription billing contract for the authenticated user.
        /// </summary>
        public static BunqResponse<List<BillingContractSubscription>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<BillingContractSubscription>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.ContractDateStart != null)
            {
                return false;
            }

            if (this.ContractDateEnd != null)
            {
                return false;
            }

            if (this.ContractVersion != null)
            {
                return false;
            }

            if (this.SubscriptionType != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BillingContractSubscription CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BillingContractSubscription>(json);
        }
    }
}