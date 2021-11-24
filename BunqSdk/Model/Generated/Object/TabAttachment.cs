using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TabAttachment : BunqModel
    {
        /// <summary>
        /// The ID of the AttachmentTab you want to attach to the TabItem.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        public TabAttachment(int? id)
        {
            Id = id;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static TabAttachment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabAttachment>(json);
        }
    }
}
