using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ScheduleRequestInquiryEntry : BunqModel
    {
        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount the money was requested from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The description of the inquiry.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The attachments attached to the payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public AttachmentScheduleRequestInquiryEntry Attachment { get; set; }
    
        /// <summary>
        /// The client's custom reference that was attached to the request and the mutation.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }
    
        /// <summary>
        /// The minimum age the user accepting the RequestInquiry must have.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public int? MinimumAge { get; set; }
    
        /// <summary>
        /// Whether or not an address must be provided on accept.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not the user accepting the request should be asked if he wants to give a tip.
        /// </summary>
        [JsonProperty(PropertyName = "want_tip")]
        public bool? WantTip { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not a lower amount can be paid on accept.
        /// </summary>
        [JsonProperty(PropertyName = "allow_amount_lower")]
        public bool? AllowAmountLower { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not a higher amount can be paid on accept.
        /// </summary>
        [JsonProperty(PropertyName = "allow_amount_higher")]
        public bool? AllowAmountHigher { get; set; }
    
        /// <summary>
        /// Whether or not sending a bunq.me request is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_bunqme")]
        public bool? AllowBunqme { get; set; }
    
        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    
        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }
    
        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_revoked")]
        public LabelUser UserAliasRevoked { get; set; }
    
        public ScheduleRequestInquiryEntry(Amount amountInquired, MonetaryAccountReference counterpartyAlias, string description, bool? allowBunqme)
        {
            AmountInquired = amountInquired;
            CounterpartyAlias = counterpartyAlias;
            Description = description;
            AllowBunqme = allowBunqme;
        }
    }
}
