using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class InvoiceItemGroup : BunqModel
    {
        /// <summary>
        /// The type of the invoice item group.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The description of the type of the invoice item group.
        /// </summary>
        [JsonProperty(PropertyName = "type_description")]
        public string TypeDescription { get; set; }
    
        /// <summary>
        /// The translated description of the type of the invoice item group.
        /// </summary>
        [JsonProperty(PropertyName = "type_description_translated")]
        public string TypeDescriptionTranslated { get; set; }
    
        /// <summary>
        /// The identifier of the invoice item group.
        /// </summary>
        [JsonProperty(PropertyName = "instance_description")]
        public string InstanceDescription { get; set; }
    
        /// <summary>
        /// The unit item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "product_vat_exclusive")]
        public Amount ProductVatExclusive { get; set; }
    
        /// <summary>
        /// The unit item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "product_vat_inclusive")]
        public Amount ProductVatInclusive { get; set; }
    
        /// <summary>
        /// The invoice items in the group.
        /// </summary>
        [JsonProperty(PropertyName = "item")]
        public InvoiceItem Item { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.TypeDescription != null)
            {
                return false;
            }
    
            if (this.TypeDescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.InstanceDescription != null)
            {
                return false;
            }
    
            if (this.ProductVatExclusive != null)
            {
                return false;
            }
    
            if (this.ProductVatInclusive != null)
            {
                return false;
            }
    
            if (this.Item != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
