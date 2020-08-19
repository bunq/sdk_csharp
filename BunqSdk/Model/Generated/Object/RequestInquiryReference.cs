using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RequestInquiryReference : BunqModel
    {
        /// <summary>
        /// The type of request inquiry. Can be RequestInquiry or RequestInquiryBatch.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The id of the request inquiry (batch).
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }

            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static RequestInquiryReference CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RequestInquiryReference>(json);
        }
    }
}