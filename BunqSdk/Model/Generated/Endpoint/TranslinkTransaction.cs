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
    /// Used to create translink transactions.
    /// </summary>
    public class TranslinkTransaction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/translink-transaction";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/translink-transaction/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/translink-transaction";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TYPE = "type";
        public const string FIELD_REFERENCE = "reference";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_PAYMENTS = "payments";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TranslinkTransaction";
    
        /// <summary>
        /// Type of transaction, can be TRIP, REFUND, WITHDRAWAL or TOP_UP.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The request reference.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
    
        /// <summary>
        /// Description of the payment request.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The list of mutations that were made.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public PaymentBatchAnchoredPayment Payments { get; set; }
    
        /// <summary>
        /// The status of the transaction. Can be CREATED, SETTLED or FAILED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The reason why the transaction FAILED processing.
        /// </summary>
        [JsonProperty(PropertyName = "failure_reason")]
        public List<Error> FailureReason { get; set; }
    
        /// <summary>
        /// The list of entries in the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public List<TranslinkTransactionEntry> Entries { get; set; }
    
        /// <summary>
        /// The total amount of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="type">Type of transaction, can be TRIP, REFUND, WITHDRAWAL or TOP_UP.</param>
        /// <param name="reference">The request reference.</param>
        /// <param name="description">Description of the payment request.</param>
        /// <param name="payments">The list of payments we want to send in a single transaction.</param>
        public static BunqResponse<int> Create(string type, string reference, string description, List<Payment> payments, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_TYPE, type},
    {FIELD_REFERENCE, reference},
    {FIELD_DESCRIPTION, description},
    {FIELD_PAYMENTS, payments},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<TranslinkTransaction> Get(int translinkTransactionId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), translinkTransactionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<TranslinkTransaction>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<TranslinkTransaction>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<TranslinkTransaction>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.FailureReason != null)
            {
                return false;
            }
    
            if (this.Payments != null)
            {
                return false;
            }
    
            if (this.Entries != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Reference != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TranslinkTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TranslinkTransaction>(json);
        }
    }
}
