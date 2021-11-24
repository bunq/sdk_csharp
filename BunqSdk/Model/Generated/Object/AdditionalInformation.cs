using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AdditionalInformation : BunqModel
    {
        /// <summary>
        /// The category of the refund, required for chargeback.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// The reason to refund, required for chargeback.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// Comment about the refund.
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
    
        /// <summary>
        /// The Attachments to attach to the refund request.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMasterCardActionRefund> Attachment { get; set; }
    
        /// <summary>
        /// Proof that the user acknowledged the terms and conditions for chargebacks.
        /// </summary>
        [JsonProperty(PropertyName = "terms_and_conditions")]
        public string TermsAndConditions { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.Reason != null)
            {
                return false;
            }
    
            if (this.Comment != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.TermsAndConditions != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AdditionalInformation CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AdditionalInformation>(json);
        }
    }
}
