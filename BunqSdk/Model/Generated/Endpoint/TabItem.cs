using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to get items on a tab.
    /// </summary>
    public class TabItem : BunqModel
    {
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabItem";
    
        /// <summary>
        /// The id of the tab item.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The item's brief description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// The item's EAN code.
        /// </summary>
        [JsonProperty(PropertyName = "ean_code")]
        public string EanCode { get; private set; }
    
        /// <summary>
        /// A struct with an AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment")]
        public AttachmentPublic AvatarAttachment { get; private set; }
    
        /// <summary>
        /// A list of AttachmentTab attached to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<AttachmentTab> TabAttachment { get; private set; }
    
        /// <summary>
        /// The quantity of the item. Formatted as a number containing up to 15 digits, up to 15 decimals and using a
        /// dot.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; private set; }
    
        /// <summary>
        /// The money amount of the item.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; private set; }
    }
}
