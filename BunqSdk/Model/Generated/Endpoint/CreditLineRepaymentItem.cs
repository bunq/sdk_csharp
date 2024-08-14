using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Line items in a credit line repayment.
    /// </summary>
    public class CreditLineRepaymentItem : BunqModel
    {
        /// <summary>
        /// The amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Amount != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CreditLineRepaymentItem CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CreditLineRepaymentItem>(json);
        }
    }
}
