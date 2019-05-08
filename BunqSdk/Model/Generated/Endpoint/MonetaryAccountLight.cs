using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// With MonetaryAccountLight is a monetary account for bunq light users. Through this endpoint you can retrieve
    /// information regarding your existing MonetaryAccountLights and update specific fields of an existing
    /// MonetaryAccountLight. Examples of fields that can be updated are the description, the daily limit and the avatar
    /// of the account.
    /// </summary>
    public class MonetaryAccountLight : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";

        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
        public const string FIELD_SETTING = "setting";

        /// <summary>
        /// The currency of the MonetaryAccountLight as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The description of the MonetaryAccountLight. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountLight. Defaults to 1000 EUR. Currency must match the
        /// MonetaryAccountLight's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public Amount DailyLimit { get; set; }

        /// <summary>
        /// The UUID of the Avatar of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }

        /// <summary>
        /// The status of the MonetaryAccountLight. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sub-status of the MonetaryAccountLight providing extra information regarding the status. Will be NONE
        /// for ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccountBank, can only be OTHER.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountBank. Can be any user
        /// provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }

        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this
        /// MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; set; }

        /// <summary>
        /// The settings of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; set; }

        /// <summary>
        /// The id of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountLight's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountLight's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The Avatar of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        /// Total Amount of money spent today. Timezone aware.
        /// </summary>
        [JsonProperty(PropertyName = "daily_spent")]
        public Amount DailySpent { get; set; }

        /// <summary>
        /// The current balance Amount of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }

        /// <summary>
        /// The Aliases for the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }

        /// <summary>
        /// The MonetaryAccountLight's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The id of the User who owns the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// The maximum balance Amount of the MonetaryAccountLight.
        /// </summary>
        [JsonProperty(PropertyName = "balance_maximum")]
        public Amount BalanceMaximum { get; set; }

        /// <summary>
        /// The amount of the monthly budget used.
        /// </summary>
        [JsonProperty(PropertyName = "budget_month_used")]
        public Amount BudgetMonthUsed { get; set; }

        /// <summary>
        /// The total amount of the monthly budget.
        /// </summary>
        [JsonProperty(PropertyName = "budget_month_maximum")]
        public Amount BudgetMonthMaximum { get; set; }

        /// <summary>
        /// The amount of the yearly budget used.
        /// </summary>
        [JsonProperty(PropertyName = "budget_year_used")]
        public Amount BudgetYearUsed { get; set; }

        /// <summary>
        /// The total amount of the yearly budget.
        /// </summary>
        [JsonProperty(PropertyName = "budget_year_maximum")]
        public Amount BudgetYearMaximum { get; set; }

        /// <summary>
        /// The amount of the yearly withdrawal budget used.
        /// </summary>
        [JsonProperty(PropertyName = "budget_withdrawal_year_used")]
        public Amount BudgetWithdrawalYearUsed { get; set; }

        /// <summary>
        /// The total amount of the yearly withdrawal budget.
        /// </summary>
        [JsonProperty(PropertyName = "budget_withdrawal_year_maximum")]
        public Amount BudgetWithdrawalYearMaximum { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.Created != null)
            {
                return false;
            }

            if (this.Updated != null)
            {
                return false;
            }

            if (this.Avatar != null)
            {
                return false;
            }

            if (this.Currency != null)
            {
                return false;
            }

            if (this.Description != null)
            {
                return false;
            }

            if (this.DailyLimit != null)
            {
                return false;
            }

            if (this.DailySpent != null)
            {
                return false;
            }

            if (this.Balance != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.PublicUuid != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.Reason != null)
            {
                return false;
            }

            if (this.ReasonDescription != null)
            {
                return false;
            }

            if (this.UserId != null)
            {
                return false;
            }

            if (this.BalanceMaximum != null)
            {
                return false;
            }

            if (this.BudgetMonthUsed != null)
            {
                return false;
            }

            if (this.BudgetMonthMaximum != null)
            {
                return false;
            }

            if (this.BudgetYearUsed != null)
            {
                return false;
            }

            if (this.BudgetYearMaximum != null)
            {
                return false;
            }

            if (this.BudgetWithdrawalYearUsed != null)
            {
                return false;
            }

            if (this.BudgetWithdrawalYearMaximum != null)
            {
                return false;
            }

            if (this.NotificationFilters != null)
            {
                return false;
            }

            if (this.Setting != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static MonetaryAccountLight CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountLight>(json);
        }
    }
}