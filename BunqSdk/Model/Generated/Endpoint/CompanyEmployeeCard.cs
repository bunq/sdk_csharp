using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage cards for company employees.
    /// </summary>
    public class CompanyEmployeeCard : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_TYPE = "type";
        public const string FIELD_PRODUCT_TYPE = "product_type";
        public const string FIELD_COMPANY_NAME_ON_CARD = "company_name_on_card";
        public const string FIELD_EMPLOYEE_NAME_ON_CARD = "employee_name_on_card";
        public const string FIELD_EMPLOYEE_PREFERRED_NAME_ON_CARD = "employee_preferred_name_on_card";
        public const string FIELD_AMOUNT_LIMIT_MONTHLY = "amount_limit_monthly";
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// The pointer to the monetary account that will be connected at first with the card.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The type of card to order.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The product type of the card to order.
        /// </summary>
        [JsonProperty(PropertyName = "product_type")]
        public string ProductType { get; set; }
        /// <summary>
        /// The name of the company that should be displayed on the card.
        /// </summary>
        [JsonProperty(PropertyName = "company_name_on_card")]
        public string CompanyNameOnCard { get; set; }
        /// <summary>
        /// The name of the employee that should be displayed on the card.
        /// </summary>
        [JsonProperty(PropertyName = "employee_name_on_card")]
        public string EmployeeNameOnCard { get; set; }
        /// <summary>
        /// The user's preferred name as it will be on the card.
        /// </summary>
        [JsonProperty(PropertyName = "employee_preferred_name_on_card")]
        public string EmployeePreferredNameOnCard { get; set; }
        /// <summary>
        /// The monthly spending limit for this employee on the card.
        /// </summary>
        [JsonProperty(PropertyName = "amount_limit_monthly")]
        public Amount AmountLimitMonthly { get; set; }
        /// <summary>
        /// The status of the employee card.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The actual card.
        /// </summary>
        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }
        /// <summary>
        /// The id of the relation user.
        /// </summary>
        [JsonProperty(PropertyName = "relation_user_id")]
        public int? RelationUserId { get; set; }
        /// <summary>
        /// The monthly spend for this employee on the card.
        /// </summary>
        [JsonProperty(PropertyName = "amount_spent_monthly")]
        public Amount AmountSpentMonthly { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Card != null)
            {
                return false;
            }
    
            if (this.RelationUserId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.CompanyNameOnCard != null)
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
        public static CompanyEmployeeCard CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CompanyEmployeeCard>(json);
        }
    }
}
