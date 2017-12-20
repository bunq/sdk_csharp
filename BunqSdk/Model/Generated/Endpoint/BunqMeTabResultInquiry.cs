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
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "BunqMeTabResultInquiry";
    
        /// <summary>
        /// The payment made for the Tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; private set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
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
