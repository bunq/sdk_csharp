using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to view UserPaymentServiceProvider for session creation.
    /// </summary>
    public class UserPaymentServiceProvider : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user-payment-service-provider/{0}";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "UserPaymentServiceProvider";

        /// <summary>
        ///     The id of the user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the user object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the user object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        ///     The distinguished name from the certificate used to identify this user.
        /// </summary>
        [JsonProperty(PropertyName = "certificate_distinguished_name")]
        public string CertificateDistinguishedName { get; set; }

        /// <summary>
        ///     The aliases of the user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }

        /// <summary>
        ///     The user's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        ///     The user status. The user status. Can be: ACTIVE, BLOCKED or DENIED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     The user sub-status. Can be: NONE
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        ///     The providers's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        ///     The display name for the provider.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     The public nick name for the provider.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; set; }

        /// <summary>
        ///     The provider's language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country code,
        ///     separated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        ///     The provider's region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country code,
        ///     separated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        ///     The setting for the session timeout of the user in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "session_timeout")]
        public int? SessionTimeout { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<UserPaymentServiceProvider> Get(int userPaymentServiceProviderId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userPaymentServiceProviderId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<UserPaymentServiceProvider>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (CertificateDistinguishedName != null) return false;

            if (Alias != null) return false;

            if (Avatar != null) return false;

            if (Status != null) return false;

            if (SubStatus != null) return false;

            if (PublicUuid != null) return false;

            if (DisplayName != null) return false;

            if (PublicNickName != null) return false;

            if (Language != null) return false;

            if (Region != null) return false;

            if (SessionTimeout != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserPaymentServiceProvider CreateFromJsonString(string json)
        {
            return CreateFromJsonString<UserPaymentServiceProvider>(json);
        }
    }
}