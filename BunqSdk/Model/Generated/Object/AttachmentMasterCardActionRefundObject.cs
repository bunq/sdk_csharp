using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentMasterCardActionRefundObject : BunqModel
    {
        /// <summary>
        /// The id of the attached Attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
    
        public AttachmentMasterCardActionRefundObject(long? id)
        {
            Id = id;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AttachmentMasterCardActionRefundObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentMasterCardActionRefundObject>(json);
        }
    }
}
