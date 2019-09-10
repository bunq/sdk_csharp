using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class LabelMonetaryAccount : BunqModel
    {
        /// <summary>
        /// The IBAN of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "iban")]
        public string Iban { get; set; }

        /// <summary>
        /// The name to display with this monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The avatar of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        /// The user this monetary account belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "label_user")]
        public LabelUser LabelUser { get; set; }

        /// <summary>
        /// The country of the user. Formatted as a ISO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Bunq.me pointer with type and value.
        /// </summary>
        [JsonProperty(PropertyName = "bunq_me")]
        public MonetaryAccountReference BunqMe { get; set; }

        /// <summary>
        /// Whether or not the monetary account is light.
        /// </summary>
        [JsonProperty(PropertyName = "is_light")]
        public bool? IsLight { get; set; }

        /// <summary>
        /// The BIC used for a SWIFT payment.
        /// </summary>
        [JsonProperty(PropertyName = "swift_bic")]
        public string SwiftBic { get; set; }

        /// <summary>
        /// The account number used for a SWIFT payment. May or may not be an IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "swift_account_number")]
        public string SwiftAccountNumber { get; set; }

        /// <summary>
        /// The account number used for a Transferwise payment. May or may not be an IBAN.
        /// </summary>
        [JsonProperty(PropertyName = "transferwise_account_number")]
        public string TransferwiseAccountNumber { get; set; }

        /// <summary>
        /// The bank code used for a Transferwise payment. May or may not be a BIC.
        /// </summary>
        [JsonProperty(PropertyName = "transferwise_bank_code")]
        public string TransferwiseBankCode { get; set; }

        /// <summary>
        /// The merchant category code.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_category_code")]
        public string MerchantCategoryCode { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Iban != null)
            {
                return false;
            }

            if (this.DisplayName != null)
            {
                return false;
            }

            if (this.Avatar != null)
            {
                return false;
            }

            if (this.LabelUser != null)
            {
                return false;
            }

            if (this.Country != null)
            {
                return false;
            }

            if (this.BunqMe != null)
            {
                return false;
            }

            if (this.IsLight != null)
            {
                return false;
            }

            if (this.SwiftBic != null)
            {
                return false;
            }

            if (this.SwiftAccountNumber != null)
            {
                return false;
            }

            if (this.TransferwiseAccountNumber != null)
            {
                return false;
            }

            if (this.TransferwiseBankCode != null)
            {
                return false;
            }

            if (this.MerchantCategoryCode != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static LabelMonetaryAccount CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<LabelMonetaryAccount>(json);
        }
    }
}