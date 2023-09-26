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
    /// Manage user-defined categories.
    /// </summary>
    public class AdditionalTransactionInformationCategoryUserDefined : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/additional-transaction-information-category-user-defined";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CATEGORY = "category";
        public const string FIELD_STATUS = "status";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_COLOR = "color";
        public const string FIELD_ICON = "icon";
    
    
        /// <summary>
        /// The category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// Whether this category is active. Only relevant for user-defined categories.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The description of the category.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
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
        /// <param name="status">Whether this category is active. Only relevant for user-defined categories.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description of the category.</param>
        /// <param name="color">The color of the category.</param>
        /// <param name="icon">The icon of the category.</param>
        public static BunqResponse<int> Create(string status, string category = null, string description = null, string color = null, string icon = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_CATEGORY, category},
    {FIELD_STATUS, status},
    {FIELD_DESCRIPTION, description},
    {FIELD_COLOR, color},
    {FIELD_ICON, icon},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static AdditionalTransactionInformationCategoryUserDefined CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<AdditionalTransactionInformationCategoryUserDefined>(json);
        }
    }
}
