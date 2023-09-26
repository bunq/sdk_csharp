using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BirdeeInvestmentPortfolioGoal : BunqModel
    {
        /// <summary>
        /// The investment goal amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_target")]
        public Amount AmountTarget { get; set; }
        /// <summary>
        /// The investment goal end time.
        /// </summary>
        [JsonProperty(PropertyName = "time_end")]
        public string TimeEnd { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AmountTarget != null)
            {
                return false;
            }
    
            if (this.TimeEnd != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BirdeeInvestmentPortfolioGoal CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BirdeeInvestmentPortfolioGoal>(json);
        }
    }
}
