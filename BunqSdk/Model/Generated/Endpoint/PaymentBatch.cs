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
    /// Create a payment batch, or show the payment batches of a monetary account.
    /// </summary>
    public class PaymentBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment-batch";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-batch/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENTS = "payments";
        public const string FIELD_BUNQTO_STATUS = "bunqto_status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentBatch";
    
        /// <summary>
        /// The list of mutations that were made.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; private set; }
    
        /// <summary>
        /// Create a payment batch by sending an array of single payment objects, that will become part of the batch.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Revoke a bunq.to payment batch. The status of all the payments will be set to REVOKED.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int paymentBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, paymentBatchId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Return the details of a specific payment batch.
        /// </summary>
        public static BunqResponse<PaymentBatch> Get(ApiContext apiContext, int userId, int monetaryAccountId, int paymentBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, paymentBatchId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentBatch>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Return all the payment batches for a monetary account.
        /// </summary>
        public static BunqResponse<List<PaymentBatch>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<PaymentBatch>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payments != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentBatch>(json);
        }
    }
}
