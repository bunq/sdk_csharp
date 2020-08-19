using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Certificate : BunqModel
    {
        /// <summary>
        /// A single certificate in the chain in .PEM format.
        /// </summary>
        [JsonProperty(PropertyName = "certificate")]
        public string CertificateString { get; set; }

        public Certificate(string certificateString)
        {
            CertificateString = certificateString;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.CertificateString != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Certificate CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Certificate>(json);
        }
    }
}