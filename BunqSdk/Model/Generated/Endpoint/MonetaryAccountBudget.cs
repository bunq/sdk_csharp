using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint to read, list, or delete the budget for a monetary account.
    /// </summary>
    public class MonetaryAccountBudget : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ALL_CATEGORY = "all_category";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_RECURRENCE_TYPE = "recurrence_type";
        public const string FIELD_MONETARY_ACCOUNT_SOURCE_FUNDING_ID = "monetary_account_source_funding_id";
        public const string FIELD_PAYMENT_DAY_OF_MONTH = "payment_day_of_month";
    
    
        /// <summary>
        /// DEPRECATED. The list of categories on which the user wants to set the budget.
        /// </summary>
        [JsonProperty(PropertyName = "all_category")]
        public List<string> AllCategory { get; set; }
        /// <summary>
        /// DEPRECATED. The amount for the budget.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// DEPRECATED. The recurrence type for the automatic top-up.
        /// </summary>
        [JsonProperty(PropertyName = "recurrence_type")]
        public string RecurrenceType { get; set; }
        /// <summary>
        /// DEPRECATED. The monetary account's ID from/to which the missing/exceeding funds will be transferred.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_source_funding_id")]
        public int? MonetaryAccountSourceFundingId { get; set; }
        /// <summary>
        /// DEPRECATED. The day of the month for the automatic top-up.
        /// </summary>
        [JsonProperty(PropertyName = "payment_day_of_month")]
        public int? PaymentDayOfMonth { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccountBudget CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountBudget>(json);
        }
    }
}
