using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Using this call you can retrieve information of the user you are logged in as. This includes your user id, which
    /// is referred to in endpoints.
    /// </summary>
    public class User : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}";
        protected const string ENDPOINT_URL_LISTING = "user";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "User";
    
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
        [JsonProperty(PropertyName = "UserApiKey")]
        public UserApiKey UserApiKey { get; set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPaymentServiceProvider")]
        public UserPaymentServiceProvider UserPaymentServiceProvider { get; set; }
    
    
        /// <summary>
        /// Get a specific user.
        /// </summary>
        public static BunqResponse<User> Get( IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId()), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<User>(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of all available users.
        /// </summary>
        public static BunqResponse<List<User>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(ENDPOINT_URL_LISTING, urlParams, customHeaders);
    
            return FromJsonList<User>(responseRaw);
        }
    
    
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
    
            if (this.UserApiKey != null)
            {
                return this.UserApiKey;
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
    
            if (this.UserApiKey != null)
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
        public static User CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<User>(json);
        }
    }
}
