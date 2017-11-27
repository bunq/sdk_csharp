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
    /// A DraftPayment is like a regular Payment, but it needs to be accepted by the sending party before the actual
    /// Payment is done.
    /// </summary>
    public class DraftPayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/draft-payment";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/draft-payment/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/draft-payment";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/draft-payment/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_ENTRIES = "entries";
        public const string FIELD_PREVIOUS_UPDATED_TIMESTAMP = "previous_updated_timestamp";
        public const string FIELD_NUMBER_OF_REQUIRED_ACCEPTS = "number_of_required_accepts";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "DraftPayment";
    
        /// <summary>
        /// The id of the created DrafPayment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The id of the MonetaryAccount the DraftPayment applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The label of the User who created the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; private set; }
    
        /// <summary>
        /// All responses to this draft payment.
        /// </summary>
        [JsonProperty(PropertyName = "responses")]
        public List<DraftPaymentResponse> Responses { get; private set; }
    
        /// <summary>
        /// The status of the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The type of the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }
    
        /// <summary>
        /// The entries in the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public List<DraftPaymentEntry> Entries { get; private set; }
    
        /// <summary>
        /// The Payment or PaymentBatch. This will only be present after the DraftPayment has been accepted.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public DraftPaymentAnchorObject Object { get; private set; }
    
        /// <summary>
        /// Create a new DraftPayment.
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
        /// Update a DraftPayment.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int draftPaymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, draftPaymentId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get a listing of all DraftPayments from a given MonetaryAccount.
        /// </summary>
        public static BunqResponse<List<DraftPayment>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<DraftPayment>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get a specific DraftPayment.
        /// </summary>
        public static BunqResponse<DraftPayment> Get(ApiContext apiContext, int userId, int monetaryAccountId, int draftPaymentId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, draftPaymentId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<DraftPayment>(responseRaw, OBJECT_TYPE);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.UserAliasCreated != null)
            {
                return false;
            }
    
            if (this.Responses != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Entries != null)
            {
                return false;
            }
    
            if (this.Object != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
