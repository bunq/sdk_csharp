using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AllocationItem : BunqModel
    {
        /// <summary>
        /// The UUID of the RegistryMembership we are allocating money for. Can be provided instead of the "alias"
        /// field.
        /// </summary>
        [JsonProperty(PropertyName = "membership_uuid")]
        public string MembershipUuid { get; set; }
        /// <summary>
        /// The Tricount ID of the membership for backwards compatibility, to be able to handle changed made offline
        /// before the Tricount migration, but synced to the backend after the Tricount migration.
        /// </summary>
        [JsonProperty(PropertyName = "membership_tricount_id")]
        public int? MembershipTricountId { get; set; }
        /// <summary>
        /// The Alias of the party we are allocating money for.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The type of the AllocationItem.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The Amount of the AllocationItem.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The Amount of the AllocationItem in the local currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_local")]
        public Amount AmountLocal { get; set; }
        /// <summary>
        /// The share ratio of the AllocationItem.
        /// </summary>
        [JsonProperty(PropertyName = "share_ratio")]
        public int? ShareRatio { get; set; }
        /// <summary>
        /// The membership.
        /// </summary>
        [JsonProperty(PropertyName = "membership")]
        public RegistryMembership Membership { get; set; }
    
        public AllocationItem(string type)
        {
            Type = type;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Membership != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.AmountLocal != null)
            {
                return false;
            }
    
            if (this.ShareRatio != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AllocationItem CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AllocationItem>(json);
        }
    }
}
