using System.Collections.Generic;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class PaymentBatchAnchoredPayment : BunqModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Payment")]
        public List<Payment> Payment { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PaymentBatchAnchoredPayment CreateFromJsonString(string json)
        {
            return CreateFromJsonString<PaymentBatchAnchoredPayment>(json);
        }
    }
}