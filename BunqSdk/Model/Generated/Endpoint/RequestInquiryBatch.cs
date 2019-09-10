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
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry-batch";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-inquiry-batch/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_REQUEST_INQUIRIES = "request_inquiries";
        public const string FIELD_STATUS = "status";
        public const string FIELD_TOTAL_AMOUNT_INQUIRED = "total_amount_inquired";
        public const string FIELD_EVENT_ID = "event_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "RequestInquiryBatch";
    
        /// <summary>
        /// The list of requests that were made.
        /// </summary>
        [JsonProperty(PropertyName = "request_inquiries")]
        public List<RequestInquiry> RequestInquiries { get; set; }
    
        /// <summary>
        /// The status of the request.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The total amount originally inquired for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_inquired")]
        public Amount TotalAmountInquired { get; set; }
    
        /// <summary>
        /// The ID of the associated event if the request batch was made using 'split the bill'.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }
    
        /// <summary>
        /// The reference to the object used for split the bill. Can be Payment, PaymentBatch, ScheduleInstance,
        /// RequestResponse and MasterCardAction
        /// </summary>
        [JsonProperty(PropertyName = "reference_split_the_bill")]
        public RequestReferenceSplitTheBillAnchorObject ReferenceSplitTheBill { get; set; }
    
    
        /// <summary>
        /// Create a request batch by sending an array of single request objects, that will become part of the batch.
        /// </summary>
        /// <param name="requestInquiries">The list of request inquiries we want to send in 1 batch.</param>
        /// <param name="totalAmountInquired">The total amount originally inquired for this batch.</param>
        /// <param name="status">The status of the request.</param>
        /// <param name="eventId">The ID of the associated event if the request batch was made using 'split the bill'.</param>
        public static BunqResponse<int> Create(List<RequestInquiry> requestInquiries, Amount totalAmountInquired, int? monetaryAccountId= null, string status = null, int? eventId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_REQUEST_INQUIRIES, requestInquiries},
    {FIELD_STATUS, status},
    {FIELD_TOTAL_AMOUNT_INQUIRED, totalAmountInquired},
    {FIELD_EVENT_ID, eventId},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Revoke a request batch. The status of all the requests will be set to REVOKED.
        /// </summary>
        /// <param name="status">The status of the request.</param>
        public static BunqResponse<int> Update(int requestInquiryBatchId, int? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestInquiryBatchId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Return the details of a specific request batch.
        /// </summary>
        public static BunqResponse<RequestInquiryBatch> Get(int requestInquiryBatchId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestInquiryBatchId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<RequestInquiryBatch>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Return all the request batches for a monetary account.
        /// </summary>
        public static BunqResponse<List<RequestInquiryBatch>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<RequestInquiryBatch>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.ReferenceSplitTheBill != null)
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
