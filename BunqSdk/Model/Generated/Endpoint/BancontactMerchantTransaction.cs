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
    /// View for requesting Bancontact transactions and polling their status.
    /// </summary>
    public class BancontactMerchantTransaction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/bancontact-merchant-transaction";

        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/bancontact-merchant-transaction/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/bancontact-merchant-transaction";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_REQUESTED = "amount_requested";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BancontactMerchantTransaction";

        /// <summary>
        /// The requested amount of money to add.
        /// </summary>
        [JsonProperty(PropertyName = "amount_requested")]
        public Amount AmountRequested { get; set; }

        /// <summary>
        /// The id of the monetary account this bancontact merchant transaction links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        /// <summary>
        /// The alias of the monetary account to add money to.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// When the transaction will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// The URL to visit complete the bancontact transaction.
        /// </summary>
        [JsonProperty(PropertyName = "url_redirect")]
        public string UrlRedirect { get; set; }

        /// <summary>
        /// The deep link to visit complete the bancontact transaction.
        /// </summary>
        [JsonProperty(PropertyName = "url_deep_link")]
        public string UrlDeepLink { get; set; }

        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// When the status was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "status_timestamp")]
        public string StatusTimestamp { get; set; }

        /// <summary>
        /// The transaction ID of the bancontact transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="amountRequested">The requested amount of money to add.</param>
        public static BunqResponse<int> Create(Amount amountRequested, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_AMOUNT_REQUESTED, amountRequested},
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
        public static BunqResponse<BancontactMerchantTransaction> Get(int bancontactMerchantTransactionId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        bancontactMerchantTransactionId), new Dictionary<string, string>(), customHeaders);

            return FromJson<BancontactMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<BancontactMerchantTransaction>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<BancontactMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.AmountRequested != null)
            {
                return false;
            }

            if (this.Expiration != null)
            {
                return false;
            }

            if (this.UrlRedirect != null)
            {
                return false;
            }

            if (this.UrlDeepLink != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.StatusTimestamp != null)
            {
                return false;
            }

            if (this.TransactionId != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BancontactMerchantTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BancontactMerchantTransaction>(json);
        }
    }
}