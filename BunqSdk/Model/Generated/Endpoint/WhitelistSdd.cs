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
    /// Whitelist an SDD so that when one comes in, it is automatically accepted.
    /// </summary>
    public class WhitelistSdd : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/whitelist-sdd/{1}";

        protected const string ENDPOINT_URL_CREATE = "user/{0}/whitelist-sdd";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/whitelist-sdd/{1}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/whitelist-sdd/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/whitelist-sdd";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_MONETARY_ACCOUNT_PAYING_ID = "monetary_account_paying_id";

        public const string FIELD_REQUEST_ID = "request_id";
        public const string FIELD_MAXIMUM_AMOUNT_PER_MONTH = "maximum_amount_per_month";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "WhitelistSdd";

        /// <summary>
        /// The account from which payments will be deducted when a transaction is matched with this whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_paying_id")]
        public int? MonetaryAccountPayingId { get; set; }

        /// <summary>
        /// ID of the request for which you want to whitelist the originating SDD.
        /// </summary>
        [JsonProperty(PropertyName = "request_id")]
        public int? RequestId { get; set; }

        /// <summary>
        /// The monthly maximum amount that can be deducted from the target account.
        /// </summary>
        [JsonProperty(PropertyName = "maximum_amount_per_month")]
        public Amount MaximumAmountPerMonth { get; set; }

        /// <summary>
        /// The ID of the whitelist entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The account to which payments will come in before possibly being 'redirected' by the whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_incoming_id")]
        public int? MonetaryAccountIncomingId { get; set; }

        /// <summary>
        /// The type of the SDD whitelist, can be CORE or B2B.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The status of the whitelist.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The credit scheme ID provided by the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "credit_scheme_identifier")]
        public string CreditSchemeIdentifier { get; set; }

        /// <summary>
        /// The mandate ID provided by the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "mandate_identifier")]
        public string MandateIdentifier { get; set; }

        /// <summary>
        /// The account to which payments will be paid.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        /// The user who created the whitelist entry.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }


        /// <summary>
        /// Get a specific SDD whitelist entry.
        /// </summary>
        public static BunqResponse<WhitelistSdd> Get(int whitelistSddId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), whitelistSddId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<WhitelistSdd>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Create a new SDD whitelist entry.
        /// </summary>
        /// <param name="monetaryAccountPayingId">ID of the monetary account of which you want to pay from.</param>
        /// <param name="requestId">ID of the request for which you want to whitelist the originating SDD.</param>
        /// <param name="maximumAmountPerMonth">The maximum amount of money that is allowed to be deducted based on the whitelist.</param>
        public static BunqResponse<int> Create(int? monetaryAccountPayingId, int? requestId,
            Amount maximumAmountPerMonth, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_MONETARY_ACCOUNT_PAYING_ID, monetaryAccountPayingId},
                {FIELD_REQUEST_ID, requestId},
                {FIELD_MAXIMUM_AMOUNT_PER_MONTH, maximumAmountPerMonth},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        /// <param name="monetaryAccountPayingId">ID of the monetary account of which you want to pay from.</param>
        /// <param name="maximumAmountPerMonth">The maximum amount of money that is allowed to be deducted based on the whitelist.</param>
        public static BunqResponse<int> Update(int whitelistSddId, int? monetaryAccountPayingId = null,
            Amount maximumAmountPerMonth = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_MONETARY_ACCOUNT_PAYING_ID, monetaryAccountPayingId},
                {FIELD_MAXIMUM_AMOUNT_PER_MONTH, maximumAmountPerMonth},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), whitelistSddId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int whitelistSddId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), whitelistSddId),
                customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// Get a listing of all SDD whitelist entries for a target monetary account.
        /// </summary>
        public static BunqResponse<List<WhitelistSdd>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<WhitelistSdd>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.MonetaryAccountIncomingId != null)
            {
                return false;
            }

            if (this.MonetaryAccountPayingId != null)
            {
                return false;
            }

            if (this.Type != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.CreditSchemeIdentifier != null)
            {
                return false;
            }

            if (this.MandateIdentifier != null)
            {
                return false;
            }

            if (this.CounterpartyAlias != null)
            {
                return false;
            }

            if (this.MaximumAmountPerMonth != null)
            {
                return false;
            }

            if (this.UserAliasCreated != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static WhitelistSdd CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<WhitelistSdd>(json);
        }
    }
}