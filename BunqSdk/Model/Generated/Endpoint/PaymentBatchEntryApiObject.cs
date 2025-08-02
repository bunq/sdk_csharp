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
    /// Manage entries inside of a payment batch.
    /// </summary>
    public class PaymentBatchEntryApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-batch/{2}/entry/{3}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-batch/{2}/entry/{3}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentBatchEntry";
    
        /// <summary>
        /// The status of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The ID of the monetary account from which the payment was made.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The ID of the Payment Batch Entry.
        /// </summary>
        [JsonProperty(PropertyName = "payment_batch_id")]
        public long? PaymentBatchId { get; set; }
        /// <summary>
        /// The amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public AmountObject Amount { get; set; }
        /// <summary>
        /// The pointer to the party where the payment should be made to.
        /// </summary>
        [JsonProperty(PropertyName = "counter_pointer")]
        public MonetaryAccountReference CounterPointer { get; set; }
        /// <summary>
        /// The description for the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The payment, if it was made.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public PaymentApiObject Payment { get; set; }
        /// <summary>
        /// The errors encountered while executing the payment.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public List<ErrorObject> Errors { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentBatchEntryApiObject> Get(long paymentBatchId, long paymentBatchEntryId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentBatchId, paymentBatchEntryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentBatchEntryApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the payment batch, used to retry.</param>
        public static BunqResponse<long> Update(long paymentBatchId, long paymentBatchEntryId, long? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentBatchId, paymentBatchEntryId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.PaymentBatchId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.CounterPointer != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Payment != null)
            {
                return false;
            }
    
            if (this.Errors != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentBatchEntryApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentBatchEntryApiObject>(json);
        }
    }
}
