using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Lists open banking provider banks.
    /// </summary>
    public class OpenBankingProviderBank : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// Provider's status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The name of the bank provider.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// The external identifier for this bank.
        /// </summary>
        [JsonProperty(PropertyName = "aiia_provider_id")]
        public string AiiaProviderId { get; set; }
        /// <summary>
        /// Country of provider
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// All payment methods allowed for Sepa payments.
        /// </summary>
        [JsonProperty(PropertyName = "all_payment_method_allowed_sepa")]
        public List<string> AllPaymentMethodAllowedSepa { get; set; }
        /// <summary>
        /// All payment methods allowed for Domestic payments.
        /// </summary>
        [JsonProperty(PropertyName = "all_payment_method_allowed_domestic")]
        public List<string> AllPaymentMethodAllowedDomestic { get; set; }
        /// <summary>
        /// Whether this provider supports business banking.
        /// </summary>
        [JsonProperty(PropertyName = "is_audience_business_supported")]
        public bool? IsAudienceBusinessSupported { get; set; }
        /// <summary>
        /// Whether this provider supports brivate banking.
        /// </summary>
        [JsonProperty(PropertyName = "is_audience_private_supported")]
        public bool? IsAudiencePrivateSupported { get; set; }
        /// <summary>
        /// The avatar of the bank.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.AiiaProviderId != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            if (this.AllPaymentMethodAllowedSepa != null)
            {
                return false;
            }
    
            if (this.AllPaymentMethodAllowedDomestic != null)
            {
                return false;
            }
    
            if (this.IsAudienceBusinessSupported != null)
            {
                return false;
            }
    
            if (this.IsAudiencePrivateSupported != null)
            {
                return false;
            }
    
            if (this.Avatar != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static OpenBankingProviderBank CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<OpenBankingProviderBank>(json);
        }
    }
}
