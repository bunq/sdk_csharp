using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class RegistryEntryAttachment : BunqModel
    {
        public RegistryEntryAttachment(int? id)
        {
            Id = id;
        }

        /// <summary>
        ///     The id of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The id of the monetary account to which the attachment belongs.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (MonetaryAccountId != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistryEntryAttachment CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistryEntryAttachment>(json);
        }
    }
}