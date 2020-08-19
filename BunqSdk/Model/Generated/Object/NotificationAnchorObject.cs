using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class NotificationAnchorObject : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";


        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeFundraiserResult")]
        public BunqMeFundraiserResult BunqMeFundraiserResult { get; set; }

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
        [JsonProperty(PropertyName = "ChatMessage")]
        public ChatMessage ChatMessage { get; set; }

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
        [JsonProperty(PropertyName = "MonetaryAccount")]
        public MonetaryAccount MonetaryAccount { get; set; }

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
        public ShareInviteMonetaryAccountInquiry ShareInviteBankInquiry { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankResponse")]
        public ShareInviteMonetaryAccountResponse ShareInviteBankResponse { get; set; }

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
        [JsonProperty(PropertyName = "User")]
        public User User { get; set; }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.BunqMeFundraiserResult != null)
            {
                return this.BunqMeFundraiserResult;
            }

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

            if (this.ChatMessage != null)
            {
                return this.ChatMessage;
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

            if (this.MonetaryAccount != null)
            {
                return this.MonetaryAccount;
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

            if (this.User != null)
            {
                return this.User;
            }

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.BunqMeFundraiserResult != null)
            {
                return false;
            }

            if (this.BunqMeTab != null)
            {
                return false;
            }

            if (this.BunqMeTabResultInquiry != null)
            {
                return false;
            }

            if (this.BunqMeTabResultResponse != null)
            {
                return false;
            }

            if (this.ChatMessage != null)
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

            if (this.MasterCardAction != null)
            {
                return false;
            }

            if (this.MonetaryAccount != null)
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

            if (this.RequestInquiry != null)
            {
                return false;
            }

            if (this.RequestInquiryBatch != null)
            {
                return false;
            }

            if (this.RequestResponse != null)
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

            if (this.ScheduledPayment != null)
            {
                return false;
            }

            if (this.ScheduledInstance != null)
            {
                return false;
            }

            if (this.TabResultInquiry != null)
            {
                return false;
            }

            if (this.TabResultResponse != null)
            {
                return false;
            }

            if (this.User != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static NotificationAnchorObject CreateFromJsonString(string json)
        {
            return CreateFromJsonString<NotificationAnchorObject>(json);
        }
    }
}