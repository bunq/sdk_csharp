using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentMasterCardActionRefund : BunqModel
    {
        /// <summary>
        /// The id of the attached Attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        public AttachmentMasterCardActionRefund(int? id)
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
        public static AttachmentMasterCardActionRefund CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentMasterCardActionRefund>(json);
        }
    }
}
