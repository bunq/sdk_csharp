using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage credit lines for a user.
    /// </summary>
    public class CreditLine : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CREDIT_LINE_OFFER_ID = "credit_line_offer_id";
        public const string FIELD_MONETARY_ACCOUNT_REPAYMENT_ID = "monetary_account_repayment_id";
    
    
        /// <summary>
        /// The ID of the pending credit line offer extended to the user.
        /// </summary>
        [JsonProperty(PropertyName = "credit_line_offer_id")]
        public int? CreditLineOfferId { get; set; }
        /// <summary>
        /// The ID of the monetary account this credit line repays from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_repayment_id")]
        public int? MonetaryAccountRepaymentId { get; set; }
        /// <summary>
        /// The ID of the user this credit line belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }
        /// <summary>
        /// The ID of the monetary account this credit line withdraws credit from.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
        /// <summary>
        /// The status of the credit line.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The amount of the credit line.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The interest rate on overdue repayments of the credit line.
        /// </summary>
        [JsonProperty(PropertyName = "interest_rate")]
        public string InterestRate { get; set; }
        /// <summary>
        /// The next time a repayment will be made.
        /// </summary>
        [JsonProperty(PropertyName = "time_repayment_next")]
        public string TimeRepaymentNext { get; set; }
        /// <summary>
        /// The pending repayments for this credit line.
        /// </summary>
        [JsonProperty(PropertyName = "pending_repayments")]
        public List<CreditLineRepayment> PendingRepayments { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserId != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountRepaymentId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.InterestRate != null)
            {
                return false;
            }
    
            if (this.TimeRepaymentNext != null)
            {
                return false;
            }
    
            if (this.PendingRepayments != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CreditLine CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CreditLine>(json);
        }
    }
}
