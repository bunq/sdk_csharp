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
        ///     Error constants.
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
            if (BunqMeFundraiserResult != null) return BunqMeFundraiserResult;

            if (BunqMeTab != null) return BunqMeTab;

            if (BunqMeTabResultInquiry != null) return BunqMeTabResultInquiry;

            if (BunqMeTabResultResponse != null) return BunqMeTabResultResponse;

            if (ChatMessage != null) return ChatMessage;

            if (DraftPayment != null) return DraftPayment;

            if (IdealMerchantTransaction != null) return IdealMerchantTransaction;

            if (Invoice != null) return Invoice;

            if (MasterCardAction != null) return MasterCardAction;

            if (MonetaryAccount != null) return MonetaryAccount;

            if (Payment != null) return Payment;

            if (PaymentBatch != null) return PaymentBatch;

            if (RequestInquiry != null) return RequestInquiry;

            if (RequestInquiryBatch != null) return RequestInquiryBatch;

            if (RequestResponse != null) return RequestResponse;

            if (ShareInviteBankInquiry != null) return ShareInviteBankInquiry;

            if (ShareInviteBankResponse != null) return ShareInviteBankResponse;

            if (ScheduledPayment != null) return ScheduledPayment;

            if (ScheduledInstance != null) return ScheduledInstance;

            if (TabResultInquiry != null) return TabResultInquiry;

            if (TabResultResponse != null) return TabResultResponse;

            if (User != null) return User;

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (BunqMeFundraiserResult != null) return false;

            if (BunqMeTab != null) return false;

            if (BunqMeTabResultInquiry != null) return false;

            if (BunqMeTabResultResponse != null) return false;

            if (ChatMessage != null) return false;

            if (DraftPayment != null) return false;

            if (IdealMerchantTransaction != null) return false;

            if (Invoice != null) return false;

            if (MasterCardAction != null) return false;

            if (MonetaryAccount != null) return false;

            if (Payment != null) return false;

            if (PaymentBatch != null) return false;

            if (RequestInquiry != null) return false;

            if (RequestInquiryBatch != null) return false;

            if (RequestResponse != null) return false;

            if (ShareInviteBankInquiry != null) return false;

            if (ShareInviteBankResponse != null) return false;

            if (ScheduledPayment != null) return false;

            if (ScheduledInstance != null) return false;

            if (TabResultInquiry != null) return false;

            if (TabResultResponse != null) return false;

            if (User != null) return false;

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