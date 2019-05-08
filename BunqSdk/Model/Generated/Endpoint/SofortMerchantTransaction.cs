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
    /// View for requesting Sofort transactions and polling their status.
    /// </summary>
    public class SofortMerchantTransaction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/sofort-merchant-transaction/{2}";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/sofort-merchant-transaction";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_REQUESTED = "amount_requested";

        public const string FIELD_ISSUER = "issuer";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "SofortMerchantTransaction";

        /// <summary>
        /// The requested amount of money to add.
        /// </summary>
        [JsonProperty(PropertyName = "amount_requested")]
        public Amount AmountRequested { get; set; }

        /// <summary>
        /// The BIC of the issuer.
        /// </summary>
        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// The id of the monetary account this sofort merchant transaction links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        /// <summary>
        /// The alias of the monetary account to add money to.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// The alias of the monetary account the money comes from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        /// In case of a successful transaction, the amount of money that will be transferred.
        /// </summary>
        [JsonProperty(PropertyName = "amount_guaranteed")]
        public Amount AmountGuaranteed { get; set; }

        /// <summary>
        /// The URL to visit to 
        /// </summary>
        [JsonProperty(PropertyName = "issuer_authentication_url")]
        public string IssuerAuthenticationUrl { get; set; }

        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The error message of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public List<Error> ErrorMessage { get; set; }

        /// <summary>
        /// The 'transaction ID' of the Sofort transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transaction_identifier")]
        public string TransactionIdentifier { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<SofortMerchantTransaction> Get(int sofortMerchantTransactionId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        sofortMerchantTransactionId), new Dictionary<string, string>(), customHeaders);

            return FromJson<SofortMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<SofortMerchantTransaction>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<SofortMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.CounterpartyAlias != null)
            {
                return false;
            }

            if (this.AmountGuaranteed != null)
            {
                return false;
            }

            if (this.AmountRequested != null)
            {
                return false;
            }

            if (this.Issuer != null)
            {
                return false;
            }

            if (this.IssuerAuthenticationUrl != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.ErrorMessage != null)
            {
                return false;
            }

            if (this.TransactionIdentifier != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static SofortMerchantTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SofortMerchantTransaction>(json);
        }
    }
}