using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to schedule request inquiry batches.
    /// </summary>
    public class ScheduleRequestInquiryBatch : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_REQUEST_INQUIRIES = "request_inquiries";
        public const string FIELD_SCHEDULE = "schedule";
        public const string FIELD_TOTAL_AMOUNT_INQUIRED = "total_amount_inquired";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ScheduleRequestInquiryBatch";
    
        /// <summary>
        /// The request batch details.
        /// </summary>
        [JsonProperty(PropertyName = "request_inquiries")]
        public List<ScheduleRequestInquiryEntry> RequestInquiries { get; private set; }
    
        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public Schedule Schedule { get; private set; }
    
        /// <summary>
        /// The total amount originally inquired for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_inquired")]
        public Amount TotalAmountInquired { get; private set; }
    }
}
