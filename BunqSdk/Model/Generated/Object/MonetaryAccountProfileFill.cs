using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class MonetaryAccountProfileFill : BunqModel
    {
        public MonetaryAccountProfileFill(string status, Amount balancePreferred, Amount balanceThresholdLow,
            string methodFill)
        {
            Status = status;
            BalancePreferred = balancePreferred;
            BalanceThresholdLow = balanceThresholdLow;
            MethodFill = methodFill;
        }

        /// <summary>
        ///     The status of the profile.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     The goal balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance_preferred")]
        public Amount BalancePreferred { get; set; }

        /// <summary>
        ///     The low threshold balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance_threshold_low")]
        public Amount BalanceThresholdLow { get; set; }

        /// <summary>
        ///     The method used to fill the monetary account. Currently only iDEAL is supported, and it is the default one.
        /// </summary>
        [JsonProperty(PropertyName = "method_fill")]
        public string MethodFill { get; set; }

        /// <summary>
        ///     The bank the fill is supposed to happen from, with BIC and bank name.
        /// </summary>
        [JsonProperty(PropertyName = "issuer")]
        public Issuer Issuer { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Status != null) return false;

            if (BalancePreferred != null) return false;

            if (BalanceThresholdLow != null) return false;

            if (MethodFill != null) return false;

            if (Issuer != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static MonetaryAccountProfileFill CreateFromJsonString(string json)
        {
            return CreateFromJsonString<MonetaryAccountProfileFill>(json);
        }
    }
}