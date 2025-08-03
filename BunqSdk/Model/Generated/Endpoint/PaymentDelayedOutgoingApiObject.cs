using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Payments that are not processed yet.
    /// </summary>
    public class PaymentDelayedOutgoingApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// The status of the delayed payment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The id of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The amount of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public AmountObject Amount { get; set; }
        /// <summary>
        /// The pointer to which the payment should be sent.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_pointer")]
        public MonetaryAccountReference CounterpartyPointer { get; set; }
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
        /// The reason for the payment being delayed.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
        /// <summary>
        /// The time this payment should be executed.
        /// </summary>
        [JsonProperty(PropertyName = "time_execution")]
        public string TimeExecution { get; set; }
        /// <summary>
        /// Information about the expected arrival of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "payment_arrival_expected")]
        public PaymentArrivalExpectedObject PaymentArrivalExpected { get; set; }
        /// <summary>
        /// The reason why the payment failed.
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public List<ErrorObject> ErrorMessage { get; set; }
        /// <summary>
        /// The resulting payment, only when it’s successful.
        /// </summary>
        [JsonProperty(PropertyName = "payment_result")]
        public PaymentApiObject PaymentResult { get; set; }
    
    
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
    
            if (this.CounterpartyPointer != null)
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
    
            if (this.Reason != null)
            {
                return false;
            }
    
            if (this.TimeExecution != null)
            {
                return false;
            }
    
            if (this.PaymentArrivalExpected != null)
            {
                return false;
            }
    
            if (this.ErrorMessage != null)
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
        public static PaymentDelayedOutgoingApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentDelayedOutgoingApiObject>(json);
        }
    }
}
