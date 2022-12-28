using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TranslinkTransactionEntry : BunqModel
    {
        /// <summary>
        /// The amount of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The description for the payment. Maximum 140 characters for payments to external IBANs, 9000 characters for
        /// payments to only other bunq MonetaryAccounts.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// Optional data to be included with the Payment specific to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }
    
        /// <summary>
        /// The Attachments attached to the payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPayment> Attachment { get; set; }
    
        /// <summary>
        /// The id of the payment entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The type of the payment entry.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
    
        public TranslinkTransactionEntry(Amount amount, MonetaryAccountReference counterpartyAlias, string description)
        {
            Amount = amount;
            CounterpartyAlias = counterpartyAlias;
            Description = description;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.MerchantReference != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TranslinkTransactionEntry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TranslinkTransactionEntry>(json);
        }
    }
}
