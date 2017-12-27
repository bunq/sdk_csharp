using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Represents conversation references.
    /// </summary>
    public class ChatConversationReference : BunqModel
    {
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "SupportConversationReference";
    
        /// <summary>
        /// The id of this conversation.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp the conversation reference was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp the conversation reference was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ChatConversationReference CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatConversationReference>(json);
        }
    }
}
