using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// View for RegistryMembership.
    /// </summary>
    public class RegistryMembership : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ALIAS = "alias";
        public const string FIELD_STATUS = "status";
        public const string FIELD_AUTO_ADD_CARD_TRANSACTION = "auto_add_card_transaction";
    
    
        /// <summary>
        /// The LabelMonetaryAccount of the user who belongs to this RegistryMembership.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The status of the RegistryMembership.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The setting for for adding automatically card transactions to the registry.
        /// </summary>
        [JsonProperty(PropertyName = "auto_add_card_transaction")]
        public string AutoAddCardTransaction { get; set; }
    
        /// <summary>
        /// The balance of this RegistryMembership.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Amount Balance { get; set; }
    
        /// <summary>
        /// The total amount spent of this RegistryMembership.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_spent")]
        public Amount TotalAmountSpent { get; set; }
    
        /// <summary>
        /// The status of the settlement of the Registry. Can be PENDING or SETTLED.
        /// </summary>
        [JsonProperty(PropertyName = "status_settlement")]
        public string StatusSettlement { get; set; }
    
        /// <summary>
        /// The registry id.
        /// </summary>
        [JsonProperty(PropertyName = "registry_id")]
        public int? RegistryId { get; set; }
    
        /// <summary>
        /// The registry title.
        /// </summary>
        [JsonProperty(PropertyName = "registry_title")]
        public string RegistryTitle { get; set; }
    
        /// <summary>
        /// The label of the user that sent the invite.
        /// </summary>
        [JsonProperty(PropertyName = "invitor")]
        public MonetaryAccountReference Invitor { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Balance != null)
            {
                return false;
            }
    
            if (this.TotalAmountSpent != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.StatusSettlement != null)
            {
                return false;
            }
    
            if (this.AutoAddCardTransaction != null)
            {
                return false;
            }
    
            if (this.RegistryId != null)
            {
                return false;
            }
    
            if (this.RegistryTitle != null)
            {
                return false;
            }
    
            if (this.Invitor != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistryMembership CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistryMembership>(json);
        }
    }
}
