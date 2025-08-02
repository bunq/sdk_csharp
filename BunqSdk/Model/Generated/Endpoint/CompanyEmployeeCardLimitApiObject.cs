using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the card limit for company employees.
    /// </summary>
    public class CompanyEmployeeCardLimitApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_LIMIT_MONTHLY = "amount_limit_monthly";
    
    
        /// <summary>
        /// The monthly spending limit for this employee on the card.
        /// </summary>
        [JsonProperty(PropertyName = "amount_limit_monthly")]
        public AmountObject AmountLimitMonthly { get; set; }
        /// <summary>
        /// Company item id.
        /// </summary>
        [JsonProperty(PropertyName = "user_company_id")]
        public long? UserCompanyId { get; set; }
        /// <summary>
        /// Company employee item id.
        /// </summary>
        [JsonProperty(PropertyName = "user_employee_id")]
        public long? UserEmployeeId { get; set; }
        /// <summary>
        /// The monthly spend for this employee on the card.
        /// </summary>
        [JsonProperty(PropertyName = "amount_spent_monthly")]
        public AmountObject AmountSpentMonthly { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserCompanyId != null)
            {
                return false;
            }
    
            if (this.UserEmployeeId != null)
            {
                return false;
            }
    
            if (this.AmountLimitMonthly != null)
            {
                return false;
            }
    
            if (this.AmountSpentMonthly != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CompanyEmployeeCardLimitApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CompanyEmployeeCardLimitApiObject>(json);
        }
    }
}
