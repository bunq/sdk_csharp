using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardMagStripePermission : BunqModel
    {
        /// <summary>
        /// Expiry time of this rule.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ExpiryTime != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardMagStripePermission CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardMagStripePermission>(json);
        }
    }
}