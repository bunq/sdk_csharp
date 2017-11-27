using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ShareDetailPayment : BunqModel
    {
        /// <summary>
        /// If set to true, the invited user will be able to make payments from the shared account.
        /// </summary>
        [JsonProperty(PropertyName = "make_payments")]
        public bool? MakePayments { get; set; }
    
        /// <summary>
        /// If set to true, the invited user will be able to make draft payments from the shared account.
        /// </summary>
        [JsonProperty(PropertyName = "make_draft_payments")]
        public bool? MakeDraftPayments { get; set; }
    
        /// <summary>
        /// If set to true, the invited user will be able to view the account balance.
        /// </summary>
        [JsonProperty(PropertyName = "view_balance")]
        public bool? ViewBalance { get; set; }
    
        /// <summary>
        /// If set to true, the invited user will be able to view events from before the share was active.
        /// </summary>
        [JsonProperty(PropertyName = "view_old_events")]
        public bool? ViewOldEvents { get; set; }
    
        /// <summary>
        /// If set to true, the invited user will be able to view events starting from the time the share became active.
        /// </summary>
        [JsonProperty(PropertyName = "view_new_events")]
        public bool? ViewNewEvents { get; set; }
    
        /// <summary>
        /// The budget restriction.
        /// </summary>
        [JsonProperty(PropertyName = "budget")]
        public BudgetRestriction Budget { get; set; }
    
        public ShareDetailPayment(bool? makePayments, bool? viewBalance, bool? viewOldEvents, bool? viewNewEvents)
        {
            MakePayments = makePayments;
            ViewBalance = viewBalance;
            ViewOldEvents = viewOldEvents;
            ViewNewEvents = viewNewEvents;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.MakePayments != null)
            {
                return false;
            }
    
            if (this.MakeDraftPayments != null)
            {
                return false;
            }
    
            if (this.ViewBalance != null)
            {
                return false;
            }
    
            if (this.ViewOldEvents != null)
            {
                return false;
            }
    
            if (this.ViewNewEvents != null)
            {
                return false;
            }
    
            if (this.Budget != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
