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
    /// List all the times a users payment was automatically allocated.
    /// </summary>
    public class PaymentAutoAllocateInstanceApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}/instance";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}/instance/{3}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentAutoAllocateInstance";
    
        /// <summary>
        /// The id of the PaymentAutoAllocateInstance.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp when the PaymentAutoAllocateInstance was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp when the PaymentAutoAllocateInstance was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The ID of the payment auto allocate this instance belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "payment_auto_allocate_id")]
        public long? PaymentAutoAllocateId { get; set; }
        /// <summary>
        /// The status of the payment auto allocate instance. SUCCEEDED or FAILED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The error message, if the payment auto allocating failed.
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public List<ErrorObject> ErrorMessage { get; set; }
        /// <summary>
        /// The payment batch allocating all the payments.
        /// </summary>
        [JsonProperty(PropertyName = "payment_batch")]
        public PaymentBatchApiObject PaymentBatch { get; set; }
        /// <summary>
        /// The ID of the payment that triggered the allocating of the payments.
        /// </summary>
        [JsonProperty(PropertyName = "payment_id")]
        public long? PaymentId { get; set; }
        /// <summary>
        /// All Ginmon transaction orders executed with this instance.
        /// </summary>
        [JsonProperty(PropertyName = "all_ginmon_transaction_order")]
        public List<GinmonTransactionApiObject> AllGinmonTransactionOrder { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentAutoAllocateInstanceApiObject>> List(long paymentAutoAllocateId, long? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentAutoAllocateId), urlParams, customHeaders);
    
            return FromJsonList<PaymentAutoAllocateInstanceApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentAutoAllocateInstanceApiObject> Get(long paymentAutoAllocateId, long paymentAutoAllocateInstanceId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentAutoAllocateId, paymentAutoAllocateInstanceId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentAutoAllocateInstanceApiObject>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.PaymentAutoAllocateId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.ErrorMessage != null)
            {
                return false;
            }
    
            if (this.PaymentBatch != null)
            {
                return false;
            }
    
            if (this.PaymentId != null)
            {
                return false;
            }
    
            if (this.AllGinmonTransactionOrder != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentAutoAllocateInstanceApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentAutoAllocateInstanceApiObject>(json);
        }
    }
}
