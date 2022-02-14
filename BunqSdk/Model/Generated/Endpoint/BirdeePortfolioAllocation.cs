using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for viewing the allocations of the model portfolios Birdee offers.
    /// </summary>
    public class BirdeePortfolioAllocation : BunqModel
    {
        /// <summary>
        /// Currency of the instrument.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_currency")]
        public string InstrumentCurrency { get; set; }
    
        /// <summary>
        /// Asset Class of the instrument.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_asset_class")]
        public string InstrumentAssetClass { get; set; }
    
        /// <summary>
        /// Name of the asset class.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_asset_class_name")]
        public string InstrumentAssetClassName { get; set; }
    
        /// <summary>
        /// ISIN code of the instrument.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_isin")]
        public string InstrumentIsin { get; set; }
    
        /// <summary>
        /// Name of the instrument.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_name")]
        public string InstrumentName { get; set; }
    
        /// <summary>
        /// Name of the geographical region covered by the instrument
        /// </summary>
        [JsonProperty(PropertyName = "instrument_region_name")]
        public string InstrumentRegionName { get; set; }
    
        /// <summary>
        /// Key Information Document of the instrument.
        /// </summary>
        [JsonProperty(PropertyName = "instrument_key_information_document_uri")]
        public string InstrumentKeyInformationDocumentUri { get; set; }
    
        /// <summary>
        /// Weight of the financial instrument in the model portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public string Weight { get; set; }
    
        /// <summary>
        /// Quantity of the financial instrument in the portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; set; }
    
        /// <summary>
        /// Unit price of the financial instrument.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }
    
        /// <summary>
        /// Monetary amount of the financial instrument in the portfolio.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.InstrumentCurrency != null)
            {
                return false;
            }
    
            if (this.InstrumentAssetClass != null)
            {
                return false;
            }
    
            if (this.InstrumentAssetClassName != null)
            {
                return false;
            }
    
            if (this.InstrumentIsin != null)
            {
                return false;
            }
    
            if (this.InstrumentName != null)
            {
                return false;
            }
    
            if (this.InstrumentRegionName != null)
            {
                return false;
            }
    
            if (this.InstrumentKeyInformationDocumentUri != null)
            {
                return false;
            }
    
            if (this.Weight != null)
            {
                return false;
            }
    
            if (this.Quantity != null)
            {
                return false;
            }
    
            if (this.Price != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BirdeePortfolioAllocation CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BirdeePortfolioAllocation>(json);
        }
    }
}
