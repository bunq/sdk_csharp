using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class DraftShareInviteEntry : BunqModel
    {
        public DraftShareInviteEntry(ShareDetail shareDetail)
        {
            ShareDetail = shareDetail;
        }

        /// <summary>
        ///     The share details. Only one of these objects is returned.
        /// </summary>
        [JsonProperty(PropertyName = "share_detail")]
        public ShareDetail ShareDetail { get; set; }

        /// <summary>
        ///     The start date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }

        /// <summary>
        ///     The expiration date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (ShareDetail != null) return false;

            if (StartDate != null) return false;

            if (EndDate != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static DraftShareInviteEntry CreateFromJsonString(string json)
        {
            return CreateFromJsonString<DraftShareInviteEntry>(json);
        }
    }
}