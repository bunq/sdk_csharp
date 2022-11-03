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
    /// Endpoint for managing currency conversions.
    /// </summary>
    public class CurrencyCloudPaymentQuote : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/currency-cloud-payment-quote";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_POINTERS = "pointers";
    
    
        /// <summary>
        /// The points we want to know the fees for.
        /// </summary>
        [JsonProperty(PropertyName = "pointers")]
        public List<Pointer> Pointers { get; set; }
    
        /// <summary>
        /// The amount that we'll charge the user with.
        /// </summary>
        [JsonProperty(PropertyName = "amount_fee")]
        public Amount AmountFee { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="pointers">The points we want to know the fees for.</param>
        public static BunqResponse<int> Create(List<Pointer> pointers, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_POINTERS, pointers},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AmountFee != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CurrencyCloudPaymentQuote CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CurrencyCloudPaymentQuote>(json);
        }
    }
}
