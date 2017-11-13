using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// bunq.me tabs allows you to create a payment request and share the link through e-mail, chat, etc. Multiple
    /// persons are able to respond to the payment request and pay through bunq, iDeal or SOFORT.
    /// </summary>
    public class BunqMeTabEntry : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_INQUIRED = "amount_inquired";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_REDIRECT_URL = "redirect_url";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "BunqMeTabEntry";
    
        /// <summary>
        /// The uuid of the bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; private set; }
    
        /// <summary>
        /// The requested Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; private set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the User and the MonetaryAccount that created the
        /// bunq.me link.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The description for the bunq.me. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The status of the bunq.me. Can be WAITING_FOR_PAYMENT, CANCELLED or EXPIRED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The URL which the user is sent to when a payment is completed.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }
    
        /// <summary>
        /// List of available merchants.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_available")]
        public List<BunqMeMerchantAvailable> MerchantAvailable { get; private set; }
    }
}
