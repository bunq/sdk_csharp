using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Issuer : BunqModel
    {
        public Issuer(string bic)
        {
            Bic = bic;
        }

        /// <summary>
        ///     The BIC code.
        /// </summary>
        [JsonProperty(PropertyName = "bic")]
        public string Bic { get; set; }

        /// <summary>
        ///     The name of the bank.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Bic != null) return false;

            if (Name != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Issuer CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Issuer>(json);
        }
    }
}