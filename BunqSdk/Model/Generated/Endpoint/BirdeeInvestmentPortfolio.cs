using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for interacting with the investment portfolio opened at Birdee.
    /// </summary>
    public class BirdeeInvestmentPortfolio : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_RISK_PROFILE_TYPE = "risk_profile_type";
        public const string FIELD_INVESTMENT_THEME = "investment_theme";
        public const string FIELD_NAME = "name";
        public const string FIELD_GOAL = "goal";
    
    
        /// <summary>
        /// The type of risk profile associated with the portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "risk_profile_type")]
        public string RiskProfileType { get; set; }
    
        /// <summary>
        /// The investment theme.
        /// </summary>
        [JsonProperty(PropertyName = "investment_theme")]
        public string InvestmentTheme { get; set; }
    
        /// <summary>
        /// The name associated with the investment portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        /// <summary>
        /// The investment goal.
        /// </summary>
        [JsonProperty(PropertyName = "goal")]
        public BirdeeInvestmentPortfolioGoal Goal { get; set; }
    
        /// <summary>
        /// Status of the portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// Maximum number of strategy changes in a year.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_strategy_change_annual_maximum")]
        public int? NumberOfStrategyChangeAnnualMaximum { get; set; }
    
        /// <summary>
        /// Maximum number of strategy changes used.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_strategy_change_annual_used")]
        public int? NumberOfStrategyChangeAnnualUsed { get; set; }
    
        /// <summary>
        /// The investment portfolio balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public BirdeeInvestmentPortfolioBalance Balance { get; set; }
    
        /// <summary>
        /// The allocations of the investment portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "allocations")]
        public List<BirdeePortfolioAllocation> Allocations { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.RiskProfileType != null)
            {
                return false;
            }
    
            if (this.InvestmentTheme != null)
            {
                return false;
            }
    
            if (this.NumberOfStrategyChangeAnnualMaximum != null)
            {
                return false;
            }
    
            if (this.NumberOfStrategyChangeAnnualUsed != null)
            {
                return false;
            }
    
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.Goal != null)
            {
                return false;
            }
    
            if (this.Balance != null)
            {
                return false;
            }
    
            if (this.Allocations != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BirdeeInvestmentPortfolio CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BirdeeInvestmentPortfolio>(json);
        }
    }
}
