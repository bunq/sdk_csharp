using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage repayments for a credit line.
    /// </summary>
    public class CreditLineRepayment : BunqModel
    {
        /// <summary>
        /// The ID of the monetary account the repayment is made on.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_credit_line_id")]
        public int? MonetaryAccountCreditLineId { get; set; }
        /// <summary>
        /// The original balance that was due, regardless of how much has been paid or how much interest has accrued.
        /// </summary>
        [JsonProperty(PropertyName = "amount_balance_due_original")]
        public Amount AmountBalanceDueOriginal { get; set; }
        /// <summary>
        /// The total amount due.
        /// </summary>
        [JsonProperty(PropertyName = "amount_due")]
        public Amount AmountDue { get; set; }
        /// <summary>
        /// The current balance due.
        /// </summary>
        [JsonProperty(PropertyName = "amount_balance_due")]
        public Amount AmountBalanceDue { get; set; }
        /// <summary>
        /// The amount of interest due.
        /// </summary>
        [JsonProperty(PropertyName = "amount_interest_due")]
        public Amount AmountInterestDue { get; set; }
        /// <summary>
        /// The amount of the fee due.
        /// </summary>
        [JsonProperty(PropertyName = "amount_fee_due")]
        public Amount AmountFeeDue { get; set; }
        /// <summary>
        /// The status of the repayment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The items of the repayment.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<CreditLineRepaymentItem> Items { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountCreditLineId != null)
            {
                return false;
            }
    
            if (this.AmountBalanceDueOriginal != null)
            {
                return false;
            }
    
            if (this.AmountDue != null)
            {
                return false;
            }
    
            if (this.AmountBalanceDue != null)
            {
                return false;
            }
    
            if (this.AmountInterestDue != null)
            {
                return false;
            }
    
            if (this.AmountFeeDue != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Items != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CreditLineRepayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CreditLineRepayment>(json);
        }
    }
}
