using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view bunq.me TabResultInquiry objects belonging to a tab. A TabResultInquiry is an object that holds
    /// details on both the tab and a single payment made for that tab.
    /// </summary>
    public class BunqMeTabResultInquiry : BunqModel
    {
        /// <summary>
        /// The payment made for the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }
    
        /// <summary>
        /// The Id of the bunq.me tab that this BunqMeTabResultInquiry belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "bunq_me_tab_id")]
        public int? BunqMeTabId { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }
    
            if (this.BunqMeTabId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BunqMeTabResultInquiry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeTabResultInquiry>(json);
        }
    }
}
