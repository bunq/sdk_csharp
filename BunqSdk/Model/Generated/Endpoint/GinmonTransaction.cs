using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for reading Ginmon transactions.
    /// </summary>
    public class GinmonTransaction : BunqModel
    {
        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status_description")]
        public string StatusDescription { get; set; }
        /// <summary>
        /// The translated status of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status_description_translated")]
        public string StatusDescriptionTranslated { get; set; }
        /// <summary>
        /// The final amount the user will pay or receive.
        /// </summary>
        [JsonProperty(PropertyName = "amount_billing")]
        public Amount AmountBilling { get; set; }
        /// <summary>
        /// The estimated amount the user will pay or receive.
        /// </summary>
        [JsonProperty(PropertyName = "amount_billing_original")]
        public Amount AmountBillingOriginal { get; set; }
        /// <summary>
        /// The ISIN of the security.
        /// </summary>
        [JsonProperty(PropertyName = "isin")]
        public string Isin { get; set; }
        /// <summary>
        /// External identifier of this order at Ginmon.
        /// </summary>
        [JsonProperty(PropertyName = "external_identifier")]
        public string ExternalIdentifier { get; set; }
        /// <summary>
        /// The label of the user.
        /// </summary>
        [JsonProperty(PropertyName = "label_user")]
        public MonetaryAccountReference LabelUser { get; set; }
        /// <summary>
        /// The label of the monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "label_monetary_account")]
        public MonetaryAccountReference LabelMonetaryAccount { get; set; }
        /// <summary>
        /// The label of the counter monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "counter_label_monetary_account")]
        public MonetaryAccountReference CounterLabelMonetaryAccount { get; set; }
        /// <summary>
        /// The id of the event of transaction.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.StatusDescription != null)
            {
                return false;
            }
    
            if (this.StatusDescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.AmountBilling != null)
            {
                return false;
            }
    
            if (this.AmountBillingOriginal != null)
            {
                return false;
            }
    
            if (this.Isin != null)
            {
                return false;
            }
    
            if (this.ExternalIdentifier != null)
            {
                return false;
            }
    
            if (this.LabelUser != null)
            {
                return false;
            }
    
            if (this.LabelMonetaryAccount != null)
            {
                return false;
            }
    
            if (this.CounterLabelMonetaryAccount != null)
            {
                return false;
            }
    
            if (this.EventId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static GinmonTransaction CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<GinmonTransaction>(json);
        }
    }
}
