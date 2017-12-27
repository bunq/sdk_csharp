using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AnchoredObject : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
    
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
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.CardDebit != null)
            {
                return this.CardDebit;
            }
    
            if (this.CardPinChange != null)
            {
                return this.CardPinChange;
            }
    
            if (this.CardResult != null)
            {
                return this.CardResult;
            }
    
            if (this.DraftPayment != null)
            {
                return this.DraftPayment;
            }
    
            if (this.IdealMerchantTransaction != null)
            {
                return this.IdealMerchantTransaction;
            }
    
            if (this.Invoice != null)
            {
                return this.Invoice;
            }
    
            if (this.Payment != null)
            {
                return this.Payment;
            }
    
            if (this.PaymentBatch != null)
            {
                return this.PaymentBatch;
            }
    
            if (this.PromotionDisplay != null)
            {
                return this.PromotionDisplay;
            }
    
            if (this.RequestInquiryBatch != null)
            {
                return this.RequestInquiryBatch;
            }
    
            if (this.RequestInquiry != null)
            {
                return this.RequestInquiry;
            }
    
            if (this.RequestResponse != null)
            {
                return this.RequestResponse;
            }
    
            if (this.ScheduledPaymentBatch != null)
            {
                return this.ScheduledPaymentBatch;
            }
    
            if (this.ScheduledPayment != null)
            {
                return this.ScheduledPayment;
            }
    
            if (this.ScheduledInstance != null)
            {
                return this.ScheduledInstance;
            }
    
            if (this.ShareInviteBankInquiry != null)
            {
                return this.ShareInviteBankInquiry;
            }
    
            if (this.ShareInviteBankResponse != null)
            {
                return this.ShareInviteBankResponse;
            }
    
            if (this.UserCredentialPasswordIp != null)
            {
                return this.UserCredentialPasswordIp;
            }
    
            throw new BunqException(ERROR_NULL_FIELDS);
        }
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.CardDebit != null)
            {
                return false;
            }
    
            if (this.CardPinChange != null)
            {
                return false;
            }
    
            if (this.CardResult != null)
            {
                return false;
            }
    
            if (this.DraftPayment != null)
            {
                return false;
            }
    
            if (this.IdealMerchantTransaction != null)
            {
                return false;
            }
    
            if (this.Invoice != null)
            {
                return false;
            }
    
            if (this.Payment != null)
            {
                return false;
            }
    
            if (this.PaymentBatch != null)
            {
                return false;
            }
    
            if (this.PromotionDisplay != null)
            {
                return false;
            }
    
            if (this.RequestInquiryBatch != null)
            {
                return false;
            }
    
            if (this.RequestInquiry != null)
            {
                return false;
            }
    
            if (this.RequestResponse != null)
            {
                return false;
            }
    
            if (this.ScheduledPaymentBatch != null)
            {
                return false;
            }
    
            if (this.ScheduledPayment != null)
            {
                return false;
            }
    
            if (this.ScheduledInstance != null)
            {
                return false;
            }
    
            if (this.ShareInviteBankInquiry != null)
            {
                return false;
            }
    
            if (this.ShareInviteBankResponse != null)
            {
                return false;
            }
    
            if (this.UserCredentialPasswordIp != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AnchoredObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AnchoredObject>(json);
        }
    }
}
