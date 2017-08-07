using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ShareDetailReadOnly : BunqModel
    {
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

        public ShareDetailReadOnly(bool? viewBalance, bool? viewOldEvents, bool? viewNewEvents)
        {
            ViewBalance = viewBalance;
            ViewOldEvents = viewOldEvents;
            ViewNewEvents = viewNewEvents;
        }
    }
}
