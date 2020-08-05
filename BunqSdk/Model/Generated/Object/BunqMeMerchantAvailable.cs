using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqMeMerchantAvailable : BunqModel
    {
        /// <summary>
        ///     A merchant type supported by bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_type")]
        public string MerchantType { get; set; }

        /// <summary>
        ///     Whether or not the merchant is available for the user.
        /// </summary>
        [JsonProperty(PropertyName = "available")]
        public bool? Available { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (MerchantType != null) return false;

            if (Available != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static BunqMeMerchantAvailable CreateFromJsonString(string json)
        {
            return CreateFromJsonString<BunqMeMerchantAvailable>(json);
        }
    }
}