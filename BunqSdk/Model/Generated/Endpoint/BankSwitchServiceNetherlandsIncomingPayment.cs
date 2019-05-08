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
    /// An incoming payment made towards an account of an external bank and redirected to a bunq account via switch
    /// service.
    /// </summary>
    public class BankSwitchServiceNetherlandsIncomingPayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/switch-service-payment/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BankSwitchServiceNetherlandsIncomingPayment";

        /// <summary>
        /// The bank switch service details.
        /// </summary>
        [JsonProperty(PropertyName = "bank_switch_service")]
        public BankSwitchServiceNetherlandsIncoming BankSwitchService { get; set; }

        /// <summary>
        /// The payment made using bank switch service.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<BankSwitchServiceNetherlandsIncomingPayment> Get(
            int bankSwitchServiceNetherlandsIncomingPaymentId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        bankSwitchServiceNetherlandsIncomingPaymentId), new Dictionary<string, string>(),
                    customHeaders);

            return FromJson<BankSwitchServiceNetherlandsIncomingPayment>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.BankSwitchService != null)
            {
                return false;
            }

            if (this.Payment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BankSwitchServiceNetherlandsIncomingPayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BankSwitchServiceNetherlandsIncomingPayment>(json);
        }
    }
}