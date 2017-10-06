using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentScheduleRequestInquiryEntry : BunqModel
    {
        /// <summary>
        /// The id of the attached Attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        public AttachmentScheduleRequestInquiryEntry(int? id)
        {
            Id = id;
        }
    }
}
