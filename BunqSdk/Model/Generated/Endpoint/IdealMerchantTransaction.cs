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
    ///     View for requesting iDEAL transactions and polling their status.
    /// </summary>
    public class IdealMerchantTransaction : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/ideal-merchant-transaction";

        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/ideal-merchant-transaction/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/ideal-merchant-transaction";

        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_REQUESTED = "amount_requested";

        public const string FIELD_ISSUER = "issuer";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "IdealMerchantTransaction";

        /// <summary>
        ///     The requested amount of money to add.
        /// </summary>
        [JsonProperty(PropertyName = "amount_requested")]
        public Amount AmountRequested { get; set; }

        /// <summary>
        ///     The BIC of the issuer.
        /// </summary>
        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; set; }

        /// <summary>
        ///     The id of the monetary account this ideal merchant transaction links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        /// <summary>
        ///     The alias of the monetary account to add money to.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        ///     The alias of the monetary account the money comes from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        ///     In case of a successful transaction, the amount of money that will be transferred.
        /// </summary>
        [JsonProperty(PropertyName = "amount_guaranteed")]
        public Amount AmountGuaranteed { get; set; }

        /// <summary>
        ///     When the transaction will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        ///     The Name of the issuer.
        /// </summary>
        [JsonProperty(PropertyName = "issuer_name")]
        public string IssuerName { get; set; }

        /// <summary>
        ///     The URL to visit to
        /// </summary>
        [JsonProperty(PropertyName = "issuer_authentication_url")]
        public string IssuerAuthenticationUrl { get; set; }

        /// <summary>
        ///     The 'purchase ID' of the iDEAL transaction.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_identifier")]
        public string PurchaseIdentifier { get; set; }

        /// <summary>
        ///     The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     When the status was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "status_timestamp")]
        public string StatusTimestamp { get; set; }

        /// <summary>
        ///     The 'transaction ID' of the iDEAL transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transaction_identifier")]
        public string TransactionIdentifier { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="amountRequested">The requested amount of money to add.</param>
        /// <param name="issuer">The BIC of the issuing bank to ask for money.</param>
        public static BunqResponse<int> Create(Amount amountRequested, string issuer, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_AMOUNT_REQUESTED, amountRequested},
                {FIELD_ISSUER, issuer}
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<IdealMerchantTransaction> Get(int idealMerchantTransactionId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        idealMerchantTransactionId), new Dictionary<string, string>(), customHeaders);

            return FromJson<IdealMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<IdealMerchantTransaction>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<IdealMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (MonetaryAccountId != null) return false;

            if (Alias != null) return false;

            if (CounterpartyAlias != null) return false;

            if (AmountGuaranteed != null) return false;

            if (AmountRequested != null) return false;

            if (Expiration != null) return false;

            if (Issuer != null) return false;

            if (IssuerName != null) return false;

            if (IssuerAuthenticationUrl != null) return false;

            if (PurchaseIdentifier != null) return false;

            if (Status != null) return false;

            if (StatusTimestamp != null) return false;

            if (TransactionIdentifier != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static IdealMerchantTransaction CreateFromJsonString(string json)
        {
            return CreateFromJsonString<IdealMerchantTransaction>(json);
        }
    }
}