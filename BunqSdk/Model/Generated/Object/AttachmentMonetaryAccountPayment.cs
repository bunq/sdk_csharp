using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AttachmentMonetaryAccountPayment : BunqModel
    {
        /// <summary>
        /// The id of the attached Attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The id of the MonetaryAccount this Attachment is attached from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        public AttachmentMonetaryAccountPayment(int? id)
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

            if (this.MonetaryAccountId != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static AttachmentMonetaryAccountPayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AttachmentMonetaryAccountPayment>(json);
        }
    }
}