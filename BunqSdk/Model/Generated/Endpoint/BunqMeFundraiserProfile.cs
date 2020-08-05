using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     bunq.me public profile of the user.
    /// </summary>
    public class BunqMeFundraiserProfile : BunqModel
    {
        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_POINTER = "pointer";


        /// <summary>
        ///     The pointer (url) which will be used to access the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "pointer")]
        public MonetaryAccountReference Pointer { get; set; }

        /// <summary>
        ///     The color chosen for the bunq.me fundraiser profile in hexadecimal format.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        /// <summary>
        ///     The LabelMonetaryAccount with the public information of the User and the MonetaryAccount that created the
        ///     bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        ///     The description of the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     The attachment attached to the fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public AttachmentPublic Attachment { get; set; }

        /// <summary>
        ///     The status of the bunq.me fundraiser profile, can be ACTIVE or DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     The URL which the user is sent to when a payment is completed.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        ///     Provided if the user has enabled their invite link.
        /// </summary>
        [JsonProperty(PropertyName = "invite_profile_name")]
        public string InviteProfileName { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Color != null) return false;

            if (Alias != null) return false;

            if (Description != null) return false;

            if (Attachment != null) return false;

            if (Pointer != null) return false;

            if (Status != null) return false;

            if (RedirectUrl != null) return false;

            if (InviteProfileName != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static BunqMeFundraiserProfile CreateFromJsonString(string json)
        {
            return CreateFromJsonString<BunqMeFundraiserProfile>(json);
        }
    }
}