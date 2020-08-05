using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CoOwner : BunqModel
    {
        /// <summary>
        ///     The Alias of the co-owner.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public LabelUser Alias { get; set; }

        /// <summary>
        ///     Can be: ACCEPTED, REJECTED, PENDING or REVOKED
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Alias != null) return false;

            if (Status != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static CoOwner CreateFromJsonString(string json)
        {
            return CreateFromJsonString<CoOwner>(json);
        }
    }
}