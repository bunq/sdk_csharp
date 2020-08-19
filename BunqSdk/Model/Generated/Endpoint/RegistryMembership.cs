using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

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

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistryMembership CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistryMembership>(json);
        }
    }
}