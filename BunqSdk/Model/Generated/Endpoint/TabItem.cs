using System.Collections.Generic;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to get items on a tab.
    /// </summary>
    public class TabItem : BunqModel
    {
        /// <summary>
        ///     The id of the tab item.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The item's brief description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     The item's EAN code.
        /// </summary>
        [JsonProperty(PropertyName = "ean_code")]
        public string EanCode { get; set; }

        /// <summary>
        ///     A struct with an AttachmentPublic UUID that used as an avatar for the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_attachment")]
        public AttachmentPublic AvatarAttachment { get; set; }

        /// <summary>
        ///     A list of AttachmentTab attached to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "tab_attachment")]
        public List<AttachmentTab> TabAttachment { get; set; }

        /// <summary>
        ///     The quantity of the item. Formatted as a number containing up to 15 digits, up to 15 decimals and using a
        ///     dot.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; set; }

        /// <summary>
        ///     The money amount of the item.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Description != null) return false;

            if (EanCode != null) return false;

            if (AvatarAttachment != null) return false;

            if (TabAttachment != null) return false;

            if (Quantity != null) return false;

            if (Amount != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static TabItem CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TabItem>(json);
        }
    }
}