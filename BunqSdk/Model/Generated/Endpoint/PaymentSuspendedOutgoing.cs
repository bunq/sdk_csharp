using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Suspended outgoing payments.
    /// </summary>
    public class PaymentSuspendedOutgoing : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// The status of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The ID of the monetary account the payment was sent from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public string MonetaryAccountId { get; set; }
        /// <summary>
        /// The time this payment should be executed.
        /// </summary>
        [JsonProperty(PropertyName = "time_execution")]
        public string TimeExecution { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.TimeExecution != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentSuspendedOutgoing CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentSuspendedOutgoing>(json);
        }
    }
}
