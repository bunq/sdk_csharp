using Newtonsoft.Json;

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
    }
}
