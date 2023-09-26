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
    /// Endpoint for apps to fetch a challenge request.
    /// </summary>
    public class MasterCardIdentityCheckChallengeRequestUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/challenge-request/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/challenge-request/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MasterCardIdentityCheckChallengeRequest";
    
        /// <summary>
        /// The status of the secure code. Can be PENDING, ACCEPTED, REJECTED, EXPIRED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        /// <summary>
        /// When the identity check expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }
        /// <summary>
        /// The description of the purchase. NULL if no description is given.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Textual explanation of the decision.
        /// </summary>
        [JsonProperty(PropertyName = "decision_description")]
        public string DecisionDescription { get; set; }
        /// <summary>
        /// Textual explanation of the decision in user's language.
        /// </summary>
        [JsonProperty(PropertyName = "decision_description_translated")]
        public string DecisionDescriptionTranslated { get; set; }
        /// <summary>
        /// The return url for the merchant app after the challenge is accepted or rejected.
        /// </summary>
        [JsonProperty(PropertyName = "url_merchant_app")]
        public string UrlMerchantApp { get; set; }
        /// <summary>
        /// The monetary account label of the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The ID of the latest event for the identity check.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<MasterCardIdentityCheckChallengeRequestUser> Get(int masterCardIdentityCheckChallengeRequestUserId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), masterCardIdentityCheckChallengeRequestUserId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<MasterCardIdentityCheckChallengeRequestUser>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the identity check. Can be ACCEPTED_PENDING_RESPONSE or REJECTED_PENDING_RESPONSE.</param>
        public static BunqResponse<int> Update(int masterCardIdentityCheckChallengeRequestUserId, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), masterCardIdentityCheckChallengeRequestUserId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.ExpiryTime != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.DecisionDescription != null)
            {
                return false;
            }
    
            if (this.DecisionDescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.UrlMerchantApp != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.EventId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardIdentityCheckChallengeRequestUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardIdentityCheckChallengeRequestUser>(json);
        }
    }
}
