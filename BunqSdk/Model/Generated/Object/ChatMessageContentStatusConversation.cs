using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class ChatMessageContentStatusConversation : BunqModel
    {
        /// <summary>
        /// Action which occurred over a conversation. Always CONVERSATION_CREATED
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Action != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessageContentStatusConversation CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageContentStatusConversation>(json);
        }
    }
}