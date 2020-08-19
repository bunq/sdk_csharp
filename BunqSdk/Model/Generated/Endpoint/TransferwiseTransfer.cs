using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to create Transferwise payments.
    /// </summary>
    public class TransferwiseTransfer : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/transferwise-quote/{1}/transferwise-transfer";
        protected const string ENDPOINT_URL_READ = "user/{0}/transferwise-quote/{1}/transferwise-transfer/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/transferwise-quote/{1}/transferwise-transfer";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_MONETARY_ACCOUNT_ID = "monetary_account_id";
        public const string FIELD_RECIPIENT_ID = "recipient_id";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwisePayment";

        /// <summary>
        /// The id of the monetary account the payment should be made from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public string MonetaryAccountId { get; set; }

        /// <summary>
        /// The id of the target account.
        /// </summary>
        [JsonProperty(PropertyName = "recipient_id")]
        public string RecipientId { get; set; }

        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        /// The status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The subStatus.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The status as Transferwise reports it.
        /// </summary>
        [JsonProperty(PropertyName = "status_transferwise")]
        public string StatusTransferwise { get; set; }

        /// <summary>
        /// A status to indicatie if Transferwise has an issue with this payment and requires more information.
        /// </summary>
        [JsonProperty(PropertyName = "status_transferwise_issue")]
        public string StatusTransferwiseIssue { get; set; }

        /// <summary>
        /// The source amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_source")]
        public Amount AmountSource { get; set; }

        /// <summary>
        /// The target amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_target")]
        public Amount AmountTarget { get; set; }

        /// <summary>
        /// The rate of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }

        /// <summary>
        /// The reference of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The Pay-In reference of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "pay_in_reference")]
        public string PayInReference { get; set; }

        /// <summary>
        /// The estimated delivery time.
        /// </summary>
        [JsonProperty(PropertyName = "time_delivery_estimate")]
        public string TimeDeliveryEstimate { get; set; }

        /// <summary>
        /// The quote details used to created the payment.
        /// </summary>
        [JsonProperty(PropertyName = "quote")]
        public TransferwiseQuote Quote { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="monetaryAccountId">The id of the monetary account the payment should be made from.</param>
        /// <param name="recipientId">The id of the target account.</param>
        public static BunqResponse<int> Create(int transferwiseQuoteId, string monetaryAccountId, string recipientId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_MONETARY_ACCOUNT_ID, monetaryAccountId},
                {FIELD_RECIPIENT_ID, recipientId},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), transferwiseQuoteId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<TransferwiseTransfer> Get(int transferwiseQuoteId, int transferwiseTransferId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), transferwiseQuoteId, transferwiseTransferId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<TransferwiseTransfer>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<TransferwiseTransfer>> List(int transferwiseQuoteId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), transferwiseQuoteId),
                urlParams, customHeaders);

            return FromJsonList<TransferwiseTransfer>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }

            if (this.CounterpartyAlias != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.StatusTransferwise != null)
            {
                return false;
            }

            if (this.StatusTransferwiseIssue != null)
            {
                return false;
            }

            if (this.AmountSource != null)
            {
                return false;
            }

            if (this.AmountTarget != null)
            {
                return false;
            }

            if (this.Rate != null)
            {
                return false;
            }

            if (this.Reference != null)
            {
                return false;
            }

            if (this.PayInReference != null)
            {
                return false;
            }

            if (this.TimeDeliveryEstimate != null)
            {
                return false;
            }

            if (this.Quote != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TransferwiseTransfer CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TransferwiseTransfer>(json);
        }
    }
}