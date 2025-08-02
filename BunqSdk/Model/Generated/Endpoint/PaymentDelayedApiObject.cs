using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Payments that are not processed yet.
    /// </summary>
    public class PaymentDelayedApiObject : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-delayed/{2}";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-delayed/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-delayed";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentDelayed";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PaymentDelayedIncoming")]
        public PaymentDelayedIncomingApiObject PaymentDelayedIncoming { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PaymentDelayedOutgoing")]
        public PaymentDelayedOutgoingApiObject PaymentDelayedOutgoing { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<long> Update(long paymentDelayedId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentDelayedId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentDelayedApiObject> Get(long paymentDelayedId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentDelayedId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentDelayedApiObject>(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentDelayedApiObject>> List(long? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<PaymentDelayedApiObject>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.PaymentDelayedIncoming != null)
            {
                return this.PaymentDelayedIncoming;
            }
    
            if (this.PaymentDelayedOutgoing != null)
            {
                return this.PaymentDelayedOutgoing;
            }
    
            throw new BunqException(ERROR_NULL_FIELDS);
        }
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.PaymentDelayedIncoming != null)
            {
                return false;
            }
    
            if (this.PaymentDelayedOutgoing != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentDelayedApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentDelayedApiObject>(json);
        }
    }
}
