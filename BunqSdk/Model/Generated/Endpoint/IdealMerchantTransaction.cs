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
    /// View for requesting iDEAL transactions and polling their status.
    /// </summary>
    public class IdealMerchantTransaction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/ideal-merchant-transaction";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/ideal-merchant-transaction/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/ideal-merchant-transaction";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_REQUESTED = "amount_requested";
        public const string FIELD_ISSUER = "issuer";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "IdealMerchantTransaction";
    
        /// <summary>
        /// The id of the monetary account this ideal merchant transaction links to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The alias of the monetary account to add money to.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The alias of the monetary account the money comes from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }
    
        /// <summary>
        /// In case of a successful transaction, the amount of money that will be transferred.
        /// </summary>
        [JsonProperty(PropertyName = "amount_guaranteed")]
        public Amount AmountGuaranteed { get; private set; }
    
        /// <summary>
        /// The requested amount of money to add.
        /// </summary>
        [JsonProperty(PropertyName = "amount_requested")]
        public Amount AmountRequested { get; private set; }
    
        /// <summary>
        /// When the transaction will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; private set; }
    
        /// <summary>
        /// The BIC of the issuer.
        /// </summary>
        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; private set; }
    
        /// <summary>
        /// The Name of the issuer.
        /// </summary>
        [JsonProperty(PropertyName = "issuer_name")]
        public string IssuerName { get; private set; }
    
        /// <summary>
        /// The URL to visit to 
        /// </summary>
        [JsonProperty(PropertyName = "issuer_authentication_url")]
        public string IssuerAuthenticationUrl { get; private set; }
    
        /// <summary>
        /// The 'purchase ID' of the iDEAL transaction.
        /// </summary>
        [JsonProperty(PropertyName = "purchase_identifier")]
        public string PurchaseIdentifier { get; private set; }
    
        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// When the status was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "status_timestamp")]
        public string StatusTimestamp { get; private set; }
    
        /// <summary>
        /// The 'transaction ID' of the iDEAL transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transaction_identifier")]
        public string TransactionIdentifier { get; private set; }
    
        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<IdealMerchantTransaction> Get(ApiContext apiContext, int userId, int monetaryAccountId, int idealMerchantTransactionId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, idealMerchantTransactionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<IdealMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<IdealMerchantTransaction>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<IdealMerchantTransaction>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.Expiration != null)
            {
                return false;
            }
    
            if (this.Issuer != null)
            {
                return false;
            }
    
            if (this.IssuerName != null)
            {
                return false;
            }
    
            if (this.IssuerAuthenticationUrl != null)
            {
                return false;
            }
    
            if (this.PurchaseIdentifier != null)
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
    
            if (this.TransactionIdentifier != null)
            {
                return false;
            }
    
            if (this.AllowChat != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static IdealMerchantTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<IdealMerchantTransaction>(json);
        }
    }
}
