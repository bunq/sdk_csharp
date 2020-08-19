using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BudgetRestriction : BunqModel
    {
        /// <summary>
        /// The amount of the budget given to the invited user.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        /// The duration for a budget restriction. Valid values are DAILY, WEEKLY, MONTHLY, YEARLY.
        /// </summary>
        [JsonProperty(PropertyName = "frequency")]
        public string Frequency { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Amount != null)
            {
                return false;
            }

            if (this.Frequency != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BudgetRestriction CreateFromJsonString(string json)
        {
            return CreateFromJsonString<BudgetRestriction>(json);
        }
    }
}