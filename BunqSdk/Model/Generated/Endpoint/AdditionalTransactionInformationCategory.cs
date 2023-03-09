using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Get the available categories.
    /// </summary>
    public class AdditionalTransactionInformationCategory : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/additional-transaction-information-category";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "AdditionalTransactionInformationCategory";
    
        /// <summary>
        /// The category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// Who created this category.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// Whether this category is active. Only relevant for user-defined categories.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The sort order of the category.
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public int? Order { get; set; }
    
        /// <summary>
        /// The description of the category.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The translation of the description of the category.
        /// </summary>
        [JsonProperty(PropertyName = "description_translated")]
        public string DescriptionTranslated { get; set; }
    
        /// <summary>
        /// The color of the category.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    
        /// <summary>
        /// The icon of the category.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<AdditionalTransactionInformationCategory>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<AdditionalTransactionInformationCategory>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Order != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.DescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.Color != null)
            {
                return false;
            }
    
            if (this.Icon != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AdditionalTransactionInformationCategory CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AdditionalTransactionInformationCategory>(json);
        }
    }
}
