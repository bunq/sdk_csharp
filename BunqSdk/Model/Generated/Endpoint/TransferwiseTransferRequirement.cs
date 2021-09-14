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
    /// Used to determine the account requirements for Transferwise transfers.
    /// </summary>
    public class TransferwiseTransferRequirement : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/transferwise-quote/{1}/transferwise-transfer-requirement";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_RECIPIENT_ID = "recipient_id";
        public const string FIELD_DETAIL = "detail";
    
    
        /// <summary>
        /// The id of the target account.
        /// </summary>
        [JsonProperty(PropertyName = "recipient_id")]
        public string RecipientId { get; set; }
    
        /// <summary>
        /// The fields which were specified as "required" and have since been filled by the user. Always provide the
        /// full list.
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public List<TransferwiseRequirementField> Detail { get; set; }
    
        /// <summary>
        /// A possible transfer type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The label of the possible transfer type to show to the user.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    
        /// <summary>
        /// The fields which the user needs to fill.
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public List<TransferwiseRequirementField> Fields { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="recipientId">The id of the target account.</param>
        /// <param name="detail">The fields which were specified as "required" and have since been filled by the user. Always provide the full list.</param>
        public static BunqResponse<int> Create(int transferwiseQuoteId, string recipientId, List<TransferwiseRequirementField> detail = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_RECIPIENT_ID, recipientId},
    {FIELD_DETAIL, detail},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), transferwiseQuoteId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Label != null)
            {
                return false;
            }
    
            if (this.Fields != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TransferwiseTransferRequirement CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TransferwiseTransferRequirement>(json);
        }
    }
}
