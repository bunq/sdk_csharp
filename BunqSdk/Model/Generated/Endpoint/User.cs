using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        private const string ErrorNullFields = "All fields of an extended model or object are null.";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}";
        private const string EndpointUrlListing = "user";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "User";
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserLight")]
        public UserLight UserLight { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPerson")]
        public UserPerson UserPerson { get; private set; }
    
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCompany")]
        public UserCompany UserCompany { get; private set; }
    
        /// <summary>
        /// Get a specific user.
        /// </summary>
        public static BunqResponse<User> Get(ApiContext apiContext, int userId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<User>(responseRaw);
        }
    
        /// <summary>
        /// Get a collection of all available users.
        /// </summary>
        public static BunqResponse<List<User>> List(ApiContext apiContext, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(EndpointUrlListing, urlParams, customHeaders);
    
            return FromJsonList<User>(responseRaw);
        }
    
    
        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.UserLight != null)
            {
                return this.UserLight;
            }
    
            if (this.UserPerson != null)
            {
                return this.UserPerson;
            }
    
            if (this.UserCompany != null)
            {
                return this.UserCompany;
            }
    
            throw new BunqException(ErrorNullFields);
        }
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserLight != null)
            {
                return false;
            }
    
            if (this.UserPerson != null)
            {
                return false;
            }
    
            if (this.UserCompany != null)
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
