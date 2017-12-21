using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentText : BunqModel
    {
        /// <summary>
        /// The text of the message.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Text != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatMessageContentText CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageContentText>(json);
        }
    }
}
