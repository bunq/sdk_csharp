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
    /// Create a payment batch, or show the payment batches of a monetary account.
    /// </summary>
    public class PaymentBatchApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment-batch";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENTS = "payments";
        public const string FIELD_EXECUTION_TYPE = "execution_type";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentBatch";
    
        /// <summary>
        /// The list of mutations that were made.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<PaymentApiObject> Payments { get; set; }
        /// <summary>
        /// Whether the payment batch should be executed synchronously or asynchronously.
        /// </summary>
        [JsonProperty(PropertyName = "execution_type")]
        public string ExecutionType { get; set; }
        /// <summary>
        /// The status of the payment batch.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The ID of the monetary account that this payment batch belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The label to display for the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public MonetaryAccountReference Label { get; set; }
        /// <summary>
        /// The total amount of the payment batch.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public AmountObject AmountTotal { get; set; }
        /// <summary>
        /// The total amount of the successful payments in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "amount_successful")]
        public AmountObject AmountSuccessful { get; set; }
        /// <summary>
        /// The ID of the latest event for the payment batch.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public long? EventId { get; set; }
        /// <summary>
        /// The entries that are part of this batch.
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public List<PaymentBatchEntryApiObject> Entries { get; set; }
    
        /// <summary>
        /// Create a payment batch by sending an array of single payment objects, that will become part of the batch.
        /// </summary>
        /// <param name="payments">The list of payments we want to send in a single batch.</param>
        /// <param name="executionType">Whether the payment batch should be executed synchronously or asynchronously.</param>
        /// <param name="status">The status of the payment batch, used to retry failed payments.</param>
        public static BunqResponse<long> Create(List<PaymentApiObject> payments, long? monetaryAccountId= null, string executionType = null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_PAYMENTS, payments},
    {FIELD_EXECUTION_TYPE, executionType},
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Revoke a bunq.to payment batch. The status of all the payments will be set to REVOKED.
        /// </summary>
        /// <param name="status">The status of the payment batch, used to retry failed payments.</param>
        public static BunqResponse<long> Update(long paymentBatchId, long? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentBatchId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Return the details of a specific payment batch.
        /// </summary>
        public static BunqResponse<PaymentBatchApiObject> Get(long paymentBatchId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentBatchId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentBatchApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Return all the payment batches for a monetary account.
        /// </summary>
        public static BunqResponse<List<PaymentBatchApiObject>> List(long? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<PaymentBatchApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.ExecutionType != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Label != null)
            {
                return false;
            }
    
            if (this.AmountTotal != null)
            {
                return false;
            }
    
            if (this.AmountSuccessful != null)
            {
                return false;
            }
    
            if (this.EventId != null)
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentBatchApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentBatchApiObject>(json);
        }
    }
}
