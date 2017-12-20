using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentAnchorEvent : BunqModel
    {
        /// <summary>
        /// An anchored object. Can be one of: CardDebit, CardPinChange, CardResult, DraftPayment,
        /// IdealMerchantTransaction, Invoice, Payment, PaymentBatch, PromotionDisplay, RequestInquiryBatch,
        /// RequestInquiry, RequestResponse, ScheduledPaymentBatch, ScheduledPayment, ScheduledRequestInquiryBatch,
        /// ScheduledRequestInquiry, ScheduledInstance, ShareInviteBankInquiry, ShareInviteBankResponse,
        /// UserCredentialPasswordIp
        /// </summary>
        [JsonProperty(PropertyName = "anchored_object")]
        public AnchoredObject AnchoredObject { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AnchoredObject != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatMessageContentAnchorEvent CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageContentAnchorEvent>(json);
        }
    }
}
