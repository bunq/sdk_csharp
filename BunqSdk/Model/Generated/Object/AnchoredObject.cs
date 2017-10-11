using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AnchoredObject : BunqModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CardDebit")]
        public CardDebit CardDebit { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CardPinChange")]
        public CardPinChange CardPinChange { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CardResult")]
        public CardResult CardResult { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DraftPayment")]
        public DraftPayment DraftPayment { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IdealMerchantTransaction")]
        public IdealMerchantTransaction IdealMerchantTransaction { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Invoice")]
        public Invoice Invoice { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Payment")]
        public Payment Payment { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PaymentBatch")]
        public PaymentBatch PaymentBatch { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PromotionDisplay")]
        public PromotionDisplay PromotionDisplay { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RequestInquiryBatch")]
        public RequestInquiryBatch RequestInquiryBatch { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RequestInquiry")]
        public RequestInquiry RequestInquiry { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RequestResponse")]
        public RequestResponse RequestResponse { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledPaymentBatch")]
        public SchedulePaymentBatch ScheduledPaymentBatch { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledPayment")]
        public SchedulePayment ScheduledPayment { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledInstance")]
        public ScheduleInstance ScheduledInstance { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankInquiry")]
        public ShareInviteBankInquiry ShareInviteBankInquiry { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankResponse")]
        public ShareInviteBankResponse ShareInviteBankResponse { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCredentialPasswordIp")]
        public UserCredentialPasswordIp UserCredentialPasswordIp { get; set; }
    }
}
