using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to share a monetary account with another bunq user, as in the 'Connect' feature in the bunq app. Allow the
    /// creation of share inquiries that, in the same way as request inquiries, can be revoked by the user creating them
    /// or accepted/rejected by the other party.
    /// </summary>
    public class ShareInviteBankInquiryBatch : BunqModel
    {
        /// <summary>
        /// The list of share invite bank inquiries that were made.
        /// </summary>
        [JsonProperty(PropertyName = "share_invite_bank_inquiries")]
        public List<ShareInviteBankInquiry> ShareInviteBankInquiries { get; set; }

        /// <summary>
        /// The LabelMonetaryAccount containing the public information of this share invite inquiry batch.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ShareInviteBankInquiries != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ShareInviteBankInquiryBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareInviteBankInquiryBatch>(json);
        }
    }
}