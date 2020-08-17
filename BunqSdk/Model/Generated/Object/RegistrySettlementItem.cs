using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RegistrySettlementItem : BunqModel
    {
        /// <summary>
        ///     The amount of the RegistrySettlementItem.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        ///     The membership of the user that has to pay.
        /// </summary>
        [JsonProperty(PropertyName = "membership_paying")]
        public RegistryMembership MembershipPaying { get; set; }

        /// <summary>
        ///     The membership of the user that will receive money.
        /// </summary>
        [JsonProperty(PropertyName = "membership_receiving")]
        public RegistryMembership MembershipReceiving { get; set; }

        /// <summary>
        ///     The LabelMonetaryAccount of the user that has to pay the request.
        /// </summary>
        [JsonProperty(PropertyName = "paying_user_alias")]
        public MonetaryAccountReference PayingUserAlias { get; set; }

        /// <summary>
        ///     The LabelMonetaryAccount of the user that will receive the amount.
        /// </summary>
        [JsonProperty(PropertyName = "receiving_user_alias")]
        public MonetaryAccountReference ReceivingUserAlias { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Amount != null) return false;

            if (MembershipPaying != null) return false;

            if (MembershipReceiving != null) return false;

            if (PayingUserAlias != null) return false;

            if (ReceivingUserAlias != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistrySettlementItem CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistrySettlementItem>(json);
        }
    }
}