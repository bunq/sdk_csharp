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
    /// Create a batch of requests for payment, or show the request batches of a monetary account.
    /// </summary>
    public class RequestInquiryBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry-batch";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_REQUEST_INQUIRIES = "request_inquiries";
        public const string FIELD_STATUS = "status";
        public const string FIELD_TOTAL_AMOUNT_INQUIRED = "total_amount_inquired";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestInquiryBatch";
    
        /// <summary>
        /// The list of requests that were made.
        /// </summary>
        [JsonProperty(PropertyName = "request_inquiries")]
        public List<RequestInquiry> RequestInquiries { get; private set; }
    
        /// <summary>
        /// The total amount originally inquired for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_inquired")]
        public Amount TotalAmountInquired { get; private set; }
    
        /// <summary>
        /// Create a request batch by sending an array of single request objects, that will become part of the batch.
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
        /// Revoke a request batch. The status of all the requests will be set to REVOKED.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int requestInquiryBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestInquiryBatchId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Return the details of a specific request batch.
        /// </summary>
        public static BunqResponse<RequestInquiryBatch> Get(ApiContext apiContext, int userId, int monetaryAccountId, int requestInquiryBatchId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, requestInquiryBatchId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<RequestInquiryBatch>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Return all the request batches for a monetary account.
        /// </summary>
        public static BunqResponse<List<RequestInquiryBatch>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<RequestInquiryBatch>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.RequestInquiries != null)
            {
                return false;
            }
    
            if (this.TotalAmountInquired != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RequestInquiryBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RequestInquiryBatch>(json);
        }
    }
}
