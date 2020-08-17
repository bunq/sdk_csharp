using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Amount : BunqModel
    {
        public Amount(string value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        /// <summary>
        ///     The amount formatted to two decimal places.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        ///     The currency of the amount. It is an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Value != null) return false;

            if (Currency != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Amount CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Amount>(json);
        }
    }
}