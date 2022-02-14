using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for interacting with the birdee investment portfolio balance..
    /// </summary>
    public class BirdeeInvestmentPortfolioBalance : BunqModel
    {
        /// <summary>
        /// The current valuation of the portfolio, minus any amount pending withdrawal.
        /// </summary>
        [JsonProperty(PropertyName = "amount_available")]
        public Amount AmountAvailable { get; set; }
    
        /// <summary>
        /// The total amount deposited.
        /// </summary>
        [JsonProperty(PropertyName = "amount_deposit_total")]
        public Amount AmountDepositTotal { get; set; }
    
        /// <summary>
        /// The total amount withdrawn.
        /// </summary>
        [JsonProperty(PropertyName = "amount_withdrawal_total")]
        public Amount AmountWithdrawalTotal { get; set; }
    
        /// <summary>
        /// The total fee amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_fee_total")]
        public Amount AmountFeeTotal { get; set; }
    
        /// <summary>
        /// The difference between the netto deposited amount and the current valuation.
        /// </summary>
        [JsonProperty(PropertyName = "amount_profit")]
        public Amount AmountProfit { get; set; }
    
        /// <summary>
        /// The amount that's sent to Birdee, but pending investment on the portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "amount_deposit_pending")]
        public Amount AmountDepositPending { get; set; }
    
        /// <summary>
        /// The amount that's sent to Birdee, but pending withdrawal.
        /// </summary>
        [JsonProperty(PropertyName = "amount_withdrawal_pending")]
        public Amount AmountWithdrawalPending { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AmountAvailable != null)
            {
                return false;
            }
    
            if (this.AmountDepositTotal != null)
            {
                return false;
            }
    
            if (this.AmountWithdrawalTotal != null)
            {
                return false;
            }
    
            if (this.AmountFeeTotal != null)
            {
                return false;
            }
    
            if (this.AmountProfit != null)
            {
                return false;
            }
    
            if (this.AmountDepositPending != null)
            {
                return false;
            }
    
            if (this.AmountWithdrawalPending != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BirdeeInvestmentPortfolioBalance CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BirdeeInvestmentPortfolioBalance>(json);
        }
    }
}
