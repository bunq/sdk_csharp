using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ShareDetail : BunqModel
    {
        /// <summary>
        /// The share details for a payment share. In the response 'payment' is replaced by 'ShareDetailPayment'.
        /// </summary>
        [JsonProperty(PropertyName = "ShareDetailPayment")]
        public ShareDetailPayment Payment { get; set; }

        /// <summary>
        /// The share details for viewing a share. In the response 'read_only' is replaced by 'ShareDetailReadOnly'.
        /// </summary>
        [JsonProperty(PropertyName = "ShareDetailReadOnly")]
        public ShareDetailReadOnly ReadOnly { get; set; }

        /// <summary>
        /// The share details for a draft payment share. Remember to replace 'draft_payment' with
        /// 'ShareDetailDraftPayment' before sending a request.
        /// </summary>
        [JsonProperty(PropertyName = "ShareDetailDraftPayment")]
        public ShareDetailDraftPayment DraftPayment { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }

            if (this.ReadOnly != null)
            {
                return false;
            }

            if (this.DraftPayment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ShareDetail CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareDetail>(json);
        }
    }
}