using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Cashback payout item details.
    /// </summary>
    public class CashbackPayoutItem : BunqModel
    {
        /// <summary>
        /// The status of the cashback payout item.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The amount of cashback earned.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The cashback rate.
        /// </summary>
        [JsonProperty(PropertyName = "rate_applied")]
        public string RateApplied { get; set; }
    
        /// <summary>
        /// The transaction category that this cashback is for.
        /// </summary>
        [JsonProperty(PropertyName = "transaction_category")]
        public AdditionalTransactionInformationCategory TransactionCategory { get; set; }
    
        /// <summary>
        /// The ID of the event of the mastercard action that triggered this cashback.
        /// </summary>
        [JsonProperty(PropertyName = "mastercard_action_event_id")]
        public int? MastercardActionEventId { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.RateApplied != null)
            {
                return false;
            }
    
            if (this.TransactionCategory != null)
            {
                return false;
            }
    
            if (this.MastercardActionEventId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CashbackPayoutItem CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CashbackPayoutItem>(json);
        }
    }
}
