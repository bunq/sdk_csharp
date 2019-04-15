using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    public class EventObject : BunqModel
    {
        /// <summary>

        /// The BunqMeTab of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTab")]
        public BunqMeTab BunqMeTab { get; set; }

        /// <summary>
        /// The BunqMeTabResultResponse of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeTabResultResponse")]
        public BunqMeTabResultResponse BunqMeTabResultResponse { get; set; }

        /// <summary>
        /// The BunqMeFundraiserResult of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "BunqMeFundraiserResult")]
        public BunqMeFundraiserResult BunqMeFundraiserResult { get; set; }

        /// <summary>
        /// The Card of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "Card")]
        public Card Card { get; set; }

        /// <summary>
        /// The CardDebit of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "CardDebit")]
        public CardDebit CardDebit { get; set; }

        /// <summary>
        /// The DraftPayment of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "DraftPayment")]
        public DraftPayment DraftPayment { get; set; }

        ///// <summary>
        ///// The FeatureAnnouncement of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "FeatureAnnouncement")]
        //public FeatureAnnouncement FeatureAnnouncement { get; set; }

        /// <summary>
        /// The IdealMerchantTransaction of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "IdealMerchantTransaction")]
        public IdealMerchantTransaction IdealMerchantTransaction { get; set; }

        /// <summary>
        /// The Invoice of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "Invoice")]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// The ScheduledPayment of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledPayment")]
        public SchedulePayment ScheduledPayment { get; set; }

        /// <summary>
        /// The ScheduledPaymentBatch of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledPaymentBatch")]
        public SchedulePaymentBatch ScheduledPaymentBatch { get; set; }

        /// <summary>
        /// The ScheduledInstance of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "ScheduledInstance")]
        public ScheduleInstance ScheduledInstance { get; set; }

        /// <summary>
        /// The MasterCardAction of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "MasterCardAction")]
        public MasterCardAction MasterCardAction { get; set; }

        ///// <summary>
        ///// The BankSwitchServiceNetherlandsIncomingPayment of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "BankSwitchServiceNetherlandsIncomingPayment")]
        //public BankSwitchServiceNetherlandsIncomingPayment BankSwitchServiceNetherlandsIncomingPayment { get; set; }

        /// <summary>
        /// The Payment of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "Payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// The PaymentBatch of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "PaymentBatch")]
        public PaymentBatch PaymentBatch { get; set; }

        /// <summary>
        /// The RequestInquiryBatch of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "RequestInquiryBatch")]
        public RequestInquiryBatch RequestInquiryBatch { get; set; }

        /// <summary>
        /// The RequestInquiry of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "RequestInquiry")]
        public RequestInquiry RequestInquiry { get; set; }

        /// <summary>
        /// The RequestResponse of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "RequestResponse")]
        public RequestResponse RequestResponse { get; set; }

        ///// <summary>
        ///// The RewardRecipient of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "RewardRecipient")]
        //public RewardRecipient RewardRecipient { get; set; }

        ///// <summary>
        ///// The RewardSender of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "RewardSender")]
        //public RewardSender RewardSender { get; set; }

        ///// <summary>
        ///// The ShareInviteBankInquiryBatch of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "ShareInviteBankInquiryBatch")]
        //public ShareInviteBankInquiryBatch ShareInviteBankInquiryBatch { get; set; }

        /// <summary>
        /// The ShareInviteBankInquiry of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankInquiry")]
        public ShareInviteBankInquiry ShareInviteBankInquiry { get; set; }

        /// <summary>
        /// The ShareInviteBankResponse of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "ShareInviteBankResponse")]
        public ShareInviteBankResponse ShareInviteBankResponse { get; set; }

        ///// <summary>
        ///// The SofortMerchantTransaction of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "SofortMerchantTransaction")]
        //public SofortMerchantTransaction SofortMerchantTransaction { get; set; }

        /// <summary>
        /// The TabResultInquiry of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "TabResultInquiry")]
        public TabResultInquiry TabResultInquiry { get; set; }

        /// <summary>
        /// The TabResultResponse of the event's object
        /// </summary>
        [JsonProperty(PropertyName = "TabResultResponse")]
        public TabResultResponse TabResultResponse { get; set; }

        ///// <summary>
        ///// The TransferwiseTransfer of the event's object
        ///// </summary>
        //[JsonProperty(PropertyName = "TransferwiseTransfer")]
        //public TransferwiseTransfer TransferwiseTransfer { get; set; }


        /// <summary>
        /// </summary>
        public static Event CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Event>(json);
        }

        public override bool IsAllFieldNull()
        {
            throw new System.NotImplementedException();
        }
    }
}
