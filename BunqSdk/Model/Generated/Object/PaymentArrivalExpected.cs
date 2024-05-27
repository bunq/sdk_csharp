using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class PaymentArrivalExpected : BunqModel
    {
        /// <summary>
        /// Indicates when we expect the payment to arrive.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The time when the payment is expected to arrive.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Time != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentArrivalExpected CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentArrivalExpected>(json);
        }
    }
}
