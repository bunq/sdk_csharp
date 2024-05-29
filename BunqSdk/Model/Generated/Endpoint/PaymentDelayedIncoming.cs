using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Payments that are not processed yet.
    /// </summary>
    public class PaymentDelayedIncoming : BunqModel
    {
        /// <summary>
        /// The status of the delayed payment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The id of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
        /// <summary>
        /// The amount of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The description of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Information about the expected arrival of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "payment_arrival_expected")]
        public PaymentArrivalExpected PaymentArrivalExpected { get; set; }
        /// <summary>
        /// The resulting payment, only when it’s successful.
        /// </summary>
        [JsonProperty(PropertyName = "payment_result")]
        public Payment PaymentResult { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.PaymentArrivalExpected != null)
            {
                return false;
            }
    
            if (this.PaymentResult != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PaymentDelayedIncoming CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentDelayedIncoming>(json);
        }
    }
}
