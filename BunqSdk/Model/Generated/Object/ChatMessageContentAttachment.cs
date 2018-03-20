using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentAttachment : BunqModel
    {
        /// <summary>
        /// An attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Attachment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessageContentAttachment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageContentAttachment>(json);
        }
    }
}