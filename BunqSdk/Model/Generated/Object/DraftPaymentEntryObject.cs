using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class DraftPaymentEntryObject : BunqModel
    {
        /// <summary>
        /// The amount of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public AmountObject Amount { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the
        /// DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The description for the DraftPayment. Maximum 140 characters for DraftPayments to external IBANs, 9000
        /// characters for DraftPayments to only other bunq MonetaryAccounts.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional data to be included with the Payment specific to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }
        /// <summary>
        /// The Attachments attached to the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPaymentObject> Attachment { get; set; }
        /// <summary>
        /// The id of the draft payment entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The type of the draft payment entry.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        public DraftPaymentEntryObject(AmountObject amount, MonetaryAccountReference counterpartyAlias, string description)
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
        public static DraftPaymentEntryObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<DraftPaymentEntryObject>(json);
        }
    }
}
