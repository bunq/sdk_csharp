using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class AllocationItem : BunqModel
    {
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
        /// The share ratio of the AllocationItem.
        /// </summary>
        [JsonProperty(PropertyName = "share_ratio")]
        public int? ShareRatio { get; set; }

        /// <summary>
        /// The membership.
        /// </summary>
        [JsonProperty(PropertyName = "membership")]
        public RegistryMembership Membership { get; set; }


        public AllocationItem(MonetaryAccountReference alias, string type, Amount amount)
        {
            Alias = alias;
            Type = type;
            Amount = amount;
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
            return CreateFromJsonString<AllocationItem>(json);
        }
    }
}