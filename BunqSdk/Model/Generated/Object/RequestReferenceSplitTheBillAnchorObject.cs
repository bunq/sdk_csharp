using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RequestReferenceSplitTheBillAnchorObject : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        ///     Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";


        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BillingInvoice")]
        public Invoice BillingInvoice { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DraftPayment")]
        public DraftPayment DraftPayment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MasterCardAction")]
        public MasterCardAction MasterCardAction { get; set; }

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
        [JsonProperty(PropertyName = "RequestResponse")]
        public RequestResponse RequestResponse { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduleInstance")]
        public ScheduleInstance ScheduleInstance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TabResultResponse")]
        public TabResultResponse TabResultResponse { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WhitelistResult")]
        public WhitelistResult WhitelistResult { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TransferwisePayment")]
        public TransferwiseTransfer TransferwisePayment { get; set; }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (BillingInvoice != null) return BillingInvoice;

            if (DraftPayment != null) return DraftPayment;

            if (MasterCardAction != null) return MasterCardAction;

            if (Payment != null) return Payment;

            if (PaymentBatch != null) return PaymentBatch;

            if (RequestResponse != null) return RequestResponse;

            if (ScheduleInstance != null) return ScheduleInstance;

            if (TabResultResponse != null) return TabResultResponse;

            if (WhitelistResult != null) return WhitelistResult;

            if (TransferwisePayment != null) return TransferwisePayment;

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (BillingInvoice != null) return false;

            if (DraftPayment != null) return false;

            if (MasterCardAction != null) return false;

            if (Payment != null) return false;

            if (PaymentBatch != null) return false;

            if (RequestResponse != null) return false;

            if (ScheduleInstance != null) return false;

            if (TabResultResponse != null) return false;

            if (WhitelistResult != null) return false;

            if (TransferwisePayment != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static RequestReferenceSplitTheBillAnchorObject CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RequestReferenceSplitTheBillAnchorObject>(json);
        }
    }
}