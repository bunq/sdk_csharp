using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Create new messages holding file attachments.
    /// </summary>
    public class ChatMessageAttachment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/chat-conversation/{1}/message-attachment";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ATTACHMENT = "attachment";


        /// <summary>
        /// The id of the newly created chat message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Create a new message holding a file attachment to a specific conversation.
        /// </summary>
        /// <param name="attachment">The attachment contained in this message.</param>
        public static BunqResponse<int> Create(int chatConversationId, BunqId attachment,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_ATTACHMENT, attachment},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), chatConversationId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessageAttachment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageAttachment>(json);
        }
    }
}