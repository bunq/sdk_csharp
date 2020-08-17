using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class EventObject : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        ///     Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";


        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTab")]
        public BunqMeTab BunqMeTab { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTabResultResponse")]
        public BunqMeTabResultResponse BunqMeTabResultResponse { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeFundraiserResult")]
        public BunqMeFundraiserResult BunqMeFundraiserResult { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Card")]
        public Card Card { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CardDebit")]
        public CardDebit CardDebit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DraftPayment")]
        public DraftPayment DraftPayment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FeatureAnnouncement")]
        public FeatureAnnouncement FeatureAnnouncement { get; set; }

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
        [JsonProperty(PropertyName = "ScheduledPayment")]
        public SchedulePayment ScheduledPayment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledPaymentBatch")]
        public SchedulePaymentBatch ScheduledPaymentBatch { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledInstance")]
        public ScheduleInstance ScheduledInstance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MasterCardAction")]
        public MasterCardAction MasterCardAction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BankSwitchServiceNetherlandsIncomingPayment")]
        public BankSwitchServiceNetherlandsIncomingPayment BankSwitchServiceNetherlandsIncomingPayment { get; set; }

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
        [JsonProperty(PropertyName = "RewardRecipient")]
        public RewardRecipient RewardRecipient { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RewardSender")]
        public RewardSender RewardSender { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankInquiryBatch")]
        public ShareInviteBankInquiryBatch ShareInviteBankInquiryBatch { get; set; }

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
        [JsonProperty(PropertyName = "SofortMerchantTransaction")]
        public SofortMerchantTransaction SofortMerchantTransaction { get; set; }

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
        [JsonProperty(PropertyName = "TransferwisePayment")]
        public TransferwiseTransfer TransferwisePayment { get; set; }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (BunqMeTab != null) return BunqMeTab;

            if (BunqMeTabResultResponse != null) return BunqMeTabResultResponse;

            if (BunqMeFundraiserResult != null) return BunqMeFundraiserResult;

            if (Card != null) return Card;

            if (CardDebit != null) return CardDebit;

            if (DraftPayment != null) return DraftPayment;

            if (FeatureAnnouncement != null) return FeatureAnnouncement;

            if (IdealMerchantTransaction != null) return IdealMerchantTransaction;

            if (Invoice != null) return Invoice;

            if (ScheduledPayment != null) return ScheduledPayment;

            if (ScheduledPaymentBatch != null) return ScheduledPaymentBatch;

            if (ScheduledInstance != null) return ScheduledInstance;

            if (MasterCardAction != null) return MasterCardAction;

            if (BankSwitchServiceNetherlandsIncomingPayment != null) return BankSwitchServiceNetherlandsIncomingPayment;

            if (Payment != null) return Payment;

            if (PaymentBatch != null) return PaymentBatch;

            if (RequestInquiryBatch != null) return RequestInquiryBatch;

            if (RequestInquiry != null) return RequestInquiry;

            if (RequestResponse != null) return RequestResponse;

            if (RewardRecipient != null) return RewardRecipient;

            if (RewardSender != null) return RewardSender;

            if (ShareInviteBankInquiryBatch != null) return ShareInviteBankInquiryBatch;

            if (ShareInviteBankInquiry != null) return ShareInviteBankInquiry;

            if (ShareInviteBankResponse != null) return ShareInviteBankResponse;

            if (SofortMerchantTransaction != null) return SofortMerchantTransaction;

            if (TabResultInquiry != null) return TabResultInquiry;

            if (TabResultResponse != null) return TabResultResponse;

            if (TransferwisePayment != null) return TransferwisePayment;

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (BunqMeTab != null) return false;

            if (BunqMeTabResultResponse != null) return false;

            if (BunqMeFundraiserResult != null) return false;

            if (Card != null) return false;

            if (CardDebit != null) return false;

            if (DraftPayment != null) return false;

            if (FeatureAnnouncement != null) return false;

            if (IdealMerchantTransaction != null) return false;

            if (Invoice != null) return false;

            if (ScheduledPayment != null) return false;

            if (ScheduledPaymentBatch != null) return false;

            if (ScheduledInstance != null) return false;

            if (MasterCardAction != null) return false;

            if (BankSwitchServiceNetherlandsIncomingPayment != null) return false;

            if (Payment != null) return false;

            if (PaymentBatch != null) return false;

            if (RequestInquiryBatch != null) return false;

            if (RequestInquiry != null) return false;

            if (RequestResponse != null) return false;

            if (RewardRecipient != null) return false;

            if (RewardSender != null) return false;

            if (ShareInviteBankInquiryBatch != null) return false;

            if (ShareInviteBankInquiry != null) return false;

            if (ShareInviteBankResponse != null) return false;

            if (SofortMerchantTransaction != null) return false;

            if (TabResultInquiry != null) return false;

            if (TabResultResponse != null) return false;

            if (TransferwisePayment != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static EventObject CreateFromJsonString(string json)
        {
            return CreateFromJsonString<EventObject>(json);
        }
    }
}