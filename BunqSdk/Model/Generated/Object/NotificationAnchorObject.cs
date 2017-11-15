using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationAnchorObject : BunqModel
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTab")]
        public BunqMeTab BunqMeTab { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTabResultInquiry")]
        public BunqMeTabResultInquiry BunqMeTabResultInquiry { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTabResultResponse")]
        public BunqMeTabResultResponse BunqMeTabResultResponse { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageStatus")]
        public ChatMessageStatus ChatMessageStatus { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageUser")]
        public ChatMessageUser ChatMessageUser { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChatMessageAnnouncement")]
        public ChatMessageAnnouncement ChatMessageAnnouncement { get; set; }
    
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
        [JsonProperty(PropertyName = "MasterCardAction")]
        public MasterCardAction MasterCardAction { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountBank")]
        public MonetaryAccountBank MonetaryAccountBank { get; set; }
    
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
        [JsonProperty(PropertyName = "RequestInquiry")]
        public RequestInquiry RequestInquiry { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RequestInquiryBatch")]
        public RequestInquiryBatch RequestInquiryBatch { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RequestResponse")]
        public RequestResponse RequestResponse { get; set; }
    
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
        [JsonProperty(PropertyName = "ScheduledPayment")]
        public SchedulePayment ScheduledPayment { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledInstance")]
        public ScheduleInstance ScheduledInstance { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabResultInquiry")]
        public TabResultInquiry TabResultInquiry { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabResultResponse")]
        public TabResultResponse TabResultResponse { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPerson")]
        public UserPerson UserPerson { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCompany")]
        public UserCompany UserCompany { get; set; }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.BunqMeTab != null)
            {
                return this.BunqMeTab;
            }
    
            if (this.BunqMeTabResultInquiry != null)
            {
                return this.BunqMeTabResultInquiry;
            }
    
            if (this.BunqMeTabResultResponse != null)
            {
                return this.BunqMeTabResultResponse;
            }
    
            if (this.ChatMessageStatus != null)
            {
                return this.ChatMessageStatus;
            }
    
            if (this.ChatMessageUser != null)
            {
                return this.ChatMessageUser;
            }
    
            if (this.ChatMessageAnnouncement != null)
            {
                return this.ChatMessageAnnouncement;
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
    
            if (this.MasterCardAction != null)
            {
                return this.MasterCardAction;
            }
    
            if (this.MonetaryAccountBank != null)
            {
                return this.MonetaryAccountBank;
            }
    
            if (this.Payment != null)
            {
                return this.Payment;
            }
    
            if (this.PaymentBatch != null)
            {
                return this.PaymentBatch;
            }
    
            if (this.RequestInquiry != null)
            {
                return this.RequestInquiry;
            }
    
            if (this.RequestInquiryBatch != null)
            {
                return this.RequestInquiryBatch;
            }
    
            if (this.RequestResponse != null)
            {
                return this.RequestResponse;
            }
    
            if (this.ShareInviteBankInquiry != null)
            {
                return this.ShareInviteBankInquiry;
            }
    
            if (this.ShareInviteBankResponse != null)
            {
                return this.ShareInviteBankResponse;
            }
    
            if (this.ScheduledPayment != null)
            {
                return this.ScheduledPayment;
            }
    
            if (this.ScheduledInstance != null)
            {
                return this.ScheduledInstance;
            }
    
            if (this.TabResultInquiry != null)
            {
                return this.TabResultInquiry;
            }
    
            if (this.TabResultResponse != null)
            {
                return this.TabResultResponse;
            }
    
            if (this.UserPerson != null)
            {
                return this.UserPerson;
            }
    
            if (this.UserCompany != null)
            {
                return this.UserCompany;
            }
    
            throw new BunqException(ERROR_NULL_FIELDS);
        }
    }
}
