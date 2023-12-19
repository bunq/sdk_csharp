using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RegistryMembershipSetting : BunqModel
    {
        /// <summary>
        /// The setting for for adding automatically card transactions to the registry.
        /// </summary>
        [JsonProperty(PropertyName = "auto_add_card_transaction")]
        public string AutoAddCardTransaction { get; set; }
        /// <summary>
        /// The time when auto add card gets active
        /// </summary>
        [JsonProperty(PropertyName = "time_auto_add_card_transaction_start")]
        public string TimeAutoAddCardTransactionStart { get; set; }
        /// <summary>
        /// The time when auto add card gets inactive
        /// </summary>
        [JsonProperty(PropertyName = "time_auto_add_card_transaction_end")]
        public string TimeAutoAddCardTransactionEnd { get; set; }
        /// <summary>
        /// The ids of the cards that have been added to registry membership setting.
        /// </summary>
        [JsonProperty(PropertyName = "card_ids")]
        public List<string> CardIds { get; set; }
        /// <summary>
        /// The cards of which payments will be automatically added to this Registry.
        /// </summary>
        [JsonProperty(PropertyName = "card_labels")]
        public List<LabelCard> CardLabels { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AutoAddCardTransaction != null)
            {
                return false;
            }
    
            if (this.TimeAutoAddCardTransactionStart != null)
            {
                return false;
            }
    
            if (this.TimeAutoAddCardTransactionEnd != null)
            {
                return false;
            }
    
            if (this.CardIds != null)
            {
                return false;
            }
    
            if (this.CardLabels != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistryMembershipSetting CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistryMembershipSetting>(json);
        }
    }
}
