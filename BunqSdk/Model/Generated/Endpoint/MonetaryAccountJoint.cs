using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// The endpoint for joint monetary accounts.
    /// </summary>
    public class MonetaryAccountJoint : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";

        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_DAILY_LIMIT = "daily_limit";
        public const string FIELD_OVERDRAFT_LIMIT = "overdraft_limit";
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_REASON = "reason";
        public const string FIELD_REASON_DESCRIPTION = "reason_description";
        public const string FIELD_ALL_CO_OWNER = "all_co_owner";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
        public const string FIELD_SETTING = "setting";


        /// <summary>
        /// The id of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountJoint's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountJoint's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The Avatar of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        /// The currency of the MonetaryAccountJoint as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The description of the MonetaryAccountJoint. Defaults to 'bunq account'.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The daily spending limit Amount of the MonetaryAccountJoint. Defaults to 1000 EUR. Currency must match the
        /// MonetaryAccountJoint's currency. Limited to 10000 EUR.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public Amount DailyLimit { get; set; }

        /// <summary>
        /// Total Amount of money spent today. Timezone aware.
        /// </summary>
        [JsonProperty(PropertyName = "daily_spent")]
        public Amount DailySpent { get; set; }

        /// <summary>
        /// The maximum Amount the MonetaryAccountJoint can be 'in the red'.
        /// </summary>
        [JsonProperty(PropertyName = "overdraft_limit")]
        public Amount OverdraftLimit { get; set; }

        /// <summary>
        /// The current balance Amount of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }

        /// <summary>
        /// The Aliases for the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }

        /// <summary>
        /// The MonetaryAccountJoint's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The status of the MonetaryAccountJoint. Can be: ACTIVE, BLOCKED, CANCELLED or PENDING_REOPEN
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sub-status of the MonetaryAccountJoint providing extra information regarding the status. Will be NONE
        /// for ACTIVE or PENDING_REOPEN, COMPLETELY or ONLY_ACCEPTING_INCOMING for BLOCKED and REDEMPTION_INVOLUNTARY,
        /// REDEMPTION_VOLUNTARY or PERMANENT for CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The reason for voluntarily cancelling (closing) the MonetaryAccountJoint, can only be OTHER.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The optional free-form reason for voluntarily cancelling (closing) the MonetaryAccountJoint. Can be any user
        /// provided message.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }

        /// <summary>
        /// The users the account will be joint with.
        /// </summary>
        [JsonProperty(PropertyName = "all_co_owner")]
        public List<CoOwner> AllCoOwner { get; set; }

        /// <summary>
        /// The id of the User who owns the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// The profile of the account.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_profile")]
        public MonetaryAccountProfile MonetaryAccountProfile { get; set; }

        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this
        /// MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; set; }

        /// <summary>
        /// The settings of the MonetaryAccountJoint.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public MonetaryAccountSetting Setting { get; set; }


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

            if (this.OverdraftLimit != null)
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

            if (this.AllCoOwner != null)
            {
                return false;
            }

            if (this.UserId != null)
            {
                return false;
            }

            if (this.MonetaryAccountProfile != null)
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
        public static MonetaryAccountJoint CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountJoint>(json);
        }
    }
}