using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for retrieving the messages that are part of a conversation.
    /// </summary>
    public class ChatMessage : BunqModel
    {
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessage CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessage>(json);
        }
    }
}