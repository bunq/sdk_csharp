using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class InvoiceItem : BunqModel
    {
        /// <summary>
        /// The billing date of the item.
        /// </summary>
        [JsonProperty(PropertyName = "billing_date")]
        public string BillingDate { get; set; }

        /// <summary>
        /// The price description.
        /// </summary>
        [JsonProperty(PropertyName = "type_description")]
        public string TypeDescription { get; set; }

        /// <summary>
        /// The translated price description.
        /// </summary>
        [JsonProperty(PropertyName = "type_description_translated")]
        public string TypeDescriptionTranslated { get; set; }

        /// <summary>
        /// The unit item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "unit_vat_exclusive")]
        public Amount UnitVatExclusive { get; set; }

        /// <summary>
        /// The unit item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "unit_vat_inclusive")]
        public Amount UnitVatInclusive { get; set; }

        /// <summary>
        /// The VAT tax fraction.
        /// </summary>
        [JsonProperty(PropertyName = "vat")]
        public double? Vat { get; set; }

        /// <summary>
        /// The number of items priced.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; set; }

        /// <summary>
        /// The item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_exclusive")]
        public Amount TotalVatExclusive { get; set; }

        /// <summary>
        /// The item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_inclusive")]
        public Amount TotalVatInclusive { get; set; }
    }
}
