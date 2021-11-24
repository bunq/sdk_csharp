using Bunq.Sdk.Context;
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
    /// MasterCard transaction view.
    /// </summary>
    public class MasterCardPayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/mastercard-action/{2}/payment";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Payment";
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<MasterCardPayment>> List(int mastercardActionId, int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), mastercardActionId), urlParams, customHeaders);
    
            return FromJsonList<MasterCardPayment>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardPayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardPayment>(json);
        }
    }
}
