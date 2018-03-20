using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Amount : BunqModel
    {
        /// <summary>
        /// The amount formatted to two decimal places.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The currency of the amount. It is an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        public Amount(string value, string currency)
        {
            Value = value;
            Currency = currency;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Value != null)
            {
                return false;
            }

            if (this.Currency != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Amount CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Amount>(json);
        }
    }
}