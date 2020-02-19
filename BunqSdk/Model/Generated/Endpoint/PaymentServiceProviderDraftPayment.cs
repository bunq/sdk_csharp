using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the PaymentServiceProviderDraftPayment's for a PISP.
    /// </summary>
    public class PaymentServiceProviderDraftPayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/payment-service-provider-draft-payment";

        protected const string ENDPOINT_URL_UPDATE = "user/{0}/payment-service-provider-draft-payment/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/payment-service-provider-draft-payment";
        protected const string ENDPOINT_URL_READ = "user/{0}/payment-service-provider-draft-payment/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_SENDER_IBAN = "sender_iban";

        public const string FIELD_SENDER_NAME = "sender_name";
        public const string FIELD_COUNTERPARTY_IBAN = "counterparty_iban";
        public const string FIELD_COUNTERPARTY_NAME = "counterparty_name";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentServiceProviderDraftPayment";

        /// <summary>
        /// The sender IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "sender_iban")]
        public string SenderIban { get; set; }

        /// <summary>
        /// The name of the sender.
        /// </summary>
        [JsonProperty(PropertyName = "sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// The IBAN of the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_iban")]
        public string CounterpartyIban { get; set; }

        /// <summary>
        /// The name of the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_name")]
        public string CounterpartyName { get; set; }

        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The amount of the draft payment
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        /// The status of the draft payment
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sender IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "receiver_iban")]
        public string ReceiverIban { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="senderIban">The IBAN of the sender.</param>
        /// <param name="counterpartyIban">The IBAN of the counterparty.</param>
        /// <param name="counterpartyName">The name of the counterparty.</param>
        /// <param name="description">Description of the payment.</param>
        /// <param name="amount">The Amount to transfer with the Payment. Must be bigger than 0.</param>
        /// <param name="senderName">The name of the sender.</param>
        /// <param name="status">The new status of the Draft Payment. Can only be set to REJECTED or CANCELLED by update.</param>
        public static BunqResponse<int> Create(string senderIban, string counterpartyIban, string counterpartyName,
            string description, Amount amount, string senderName = null, string status = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_SENDER_IBAN, senderIban},
                {FIELD_SENDER_NAME, senderName},
                {FIELD_COUNTERPARTY_IBAN, counterpartyIban},
                {FIELD_COUNTERPARTY_NAME, counterpartyName},
                {FIELD_DESCRIPTION, description},
                {FIELD_AMOUNT, amount},
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        /// <param name="status">The new status of the Draft Payment. Can only be set to REJECTED or CANCELLED by update.</param>
        public static BunqResponse<int> Update(int paymentServiceProviderDraftPaymentId, string status = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), paymentServiceProviderDraftPaymentId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentServiceProviderDraftPayment>> List(
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<PaymentServiceProviderDraftPayment>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentServiceProviderDraftPayment> Get(int paymentServiceProviderDraftPaymentId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), paymentServiceProviderDraftPaymentId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<PaymentServiceProviderDraftPayment>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.SenderIban != null)
            {
                return false;
            }

            if (this.ReceiverIban != null)
            {
                return false;
            }

            if (this.Amount != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PaymentServiceProviderDraftPayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentServiceProviderDraftPayment>(json);
        }
    }
}