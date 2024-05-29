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
    public class PaymentDelayed : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-delayed/{2}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentDelayed";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PaymentDelayedIncoming")]
        public PaymentDelayedIncoming PaymentDelayedIncoming { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentDelayed> Get(int paymentDelayedId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), paymentDelayedId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PaymentDelayed>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.PaymentDelayedIncoming != null)
            {
                return this.PaymentDelayedIncoming;
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentDelayed CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentDelayed>(json);
        }
    }
}
