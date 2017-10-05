using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to schedule request inquiry.
    /// </summary>
    public class ScheduleRequestInquiry : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_REQUEST_INQUIRY = "request_inquiry";
        public const string FIELD_SCHEDULE = "schedule";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ScheduleRequestInquiry";
    
        /// <summary>
        /// The request inquiry.
        /// </summary>
        [JsonProperty(PropertyName = "request_inquiry")]
        public ScheduleRequestInquiryEntry RequestInquiry { get; private set; }
    
        /// <summary>
        /// The schedule details.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public Schedule Schedule { get; private set; }
    }
}
