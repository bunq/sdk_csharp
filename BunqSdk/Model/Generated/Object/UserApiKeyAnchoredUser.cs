using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class UserApiKeyAnchoredUser : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
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
            if (this.UserPerson != null)
            {
                return this.UserPerson;
            }

            if (this.UserCompany != null)
            {
                return this.UserCompany;
            }

            if (this.UserPaymentServiceProvider != null)
            {
                return this.UserPaymentServiceProvider;
            }

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserPerson != null)
            {
                return false;
            }

            if (this.UserCompany != null)
            {
                return false;
            }

            if (this.UserPaymentServiceProvider != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserApiKeyAnchoredUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserApiKeyAnchoredUser>(json);
        }
    }
}