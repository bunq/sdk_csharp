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
    /// The endpoint for payment service provider issuer transactions
    /// </summary>
    public class PaymentServiceProviderIssuerTransaction : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/payment-service-provider-issuer-transaction";
        protected const string ENDPOINT_URL_READ = "user/{0}/payment-service-provider-issuer-transaction/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/payment-service-provider-issuer-transaction/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/payment-service-provider-issuer-transaction";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_URL_REDIRECT = "url_redirect";
        public const string FIELD_TIME_EXPIRY = "time_expiry";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentServiceProviderIssuerTransaction";
    
        /// <summary>
        /// The counter party this transaction should be sent to.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The money amount of this transaction
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The description of this transaction, to be shown to the user and to the counter party.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The url to which the user should be redirected once the transaction is accepted or rejected.
        /// </summary>
        [JsonProperty(PropertyName = "url_redirect")]
        public string UrlRedirect { get; set; }
    
        /// <summary>
        /// The (optional) expiration time of the transaction. Defaults to 10 minutes.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
    
        /// <summary>
        /// The status of the transaction. Can only be used for cancelling the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The id of this transaction.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The time this transaction was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The time this transaction was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The public uuid used to identify this transaction.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="counterpartyAlias">The counter party this transaction should be sent to.</param>
        /// <param name="amount">The money amount of this transaction</param>
        /// <param name="description">The description of this transaction, to be shown to the user and to the counter party.</param>
        /// <param name="urlRedirect">The url to which the user should be redirected once the transaction is accepted or rejected.</param>
        /// <param name="timeExpiry">The (optional) expiration time of the transaction. Defaults to 10 minutes.</param>
        /// <param name="status">The status of the transaction. Can only be used for cancelling the transaction.</param>
        public static BunqResponse<int> Create(Pointer counterpartyAlias, Amount amount, string description, string urlRedirect, string timeExpiry = null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_COUNTERPARTY_ALIAS, counterpartyAlias},
    {FIELD_AMOUNT, amount},
    {FIELD_DESCRIPTION, description},
    {FIELD_URL_REDIRECT, urlRedirect},
    {FIELD_TIME_EXPIRY, timeExpiry},
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentServiceProviderIssuerTransaction> Get(int paymentServiceProviderIssuerTransactionId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), paymentServiceProviderIssuerTransactionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentServiceProviderIssuerTransaction>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        /// <param name="status">The status of the transaction. Can only be used for cancelling the transaction.</param>
        public static BunqResponse<int> Update(int paymentServiceProviderIssuerTransactionId, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), paymentServiceProviderIssuerTransactionId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentServiceProviderIssuerTransaction>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<PaymentServiceProviderIssuerTransaction>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.PublicUuid != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.UrlRedirect != null)
            {
                return false;
            }
    
            if (this.TimeExpiry != null)
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
        public static PaymentServiceProviderIssuerTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentServiceProviderIssuerTransaction>(json);
        }
    }
}
