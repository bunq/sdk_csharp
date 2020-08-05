using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class UserApiKeyAnchoredUser : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        ///     Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";


        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPerson")]
        public UserPerson UserPerson { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCompany")]
        public UserCompany UserCompany { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPaymentServiceProvider")]
        public UserPaymentServiceProvider UserPaymentServiceProvider { get; set; }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (UserPerson != null) return UserPerson;

            if (UserCompany != null) return UserCompany;

            if (UserPaymentServiceProvider != null) return UserPaymentServiceProvider;

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (UserPerson != null) return false;

            if (UserCompany != null) return false;

            if (UserPaymentServiceProvider != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserApiKeyAnchoredUser CreateFromJsonString(string json)
        {
            return CreateFromJsonString<UserApiKeyAnchoredUser>(json);
        }
    }
}