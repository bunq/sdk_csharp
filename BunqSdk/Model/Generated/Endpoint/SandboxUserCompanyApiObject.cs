using Bunq.Sdk.Context;
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
    /// Used to create a sandbox userCompany.
    /// </summary>
    public class SandboxUserCompanyApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "sandbox-user-company";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "ApiKey";
    
        /// <summary>
        /// The API key of the newly created sandbox userCompany.
        /// </summary>
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; set; }
        /// <summary>
        /// The user company which was created.
        /// </summary>
        [JsonProperty(PropertyName = "user_company")]
        public UserCompanyApiObject UserCompany { get; set; }
        /// <summary>
        /// The director of the company which was created.
        /// </summary>
        [JsonProperty(PropertyName = "user_person")]
        public UserPersonApiObject UserPerson { get; set; }
        /// <summary>
        /// The login code which the developer can use to log into their sandbox user.
        /// </summary>
        [JsonProperty(PropertyName = "login_code")]
        public string LoginCode { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<SandboxUserCompanyApiObject> Create( IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);
    
            return FromJson<SandboxUserCompanyApiObject>(responseRaw, OBJECT_TYPE_POST);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ApiKey != null)
            {
                return false;
            }
    
            if (this.UserCompany != null)
            {
                return false;
            }
    
            if (this.UserPerson != null)
            {
                return false;
            }
    
            if (this.LoginCode != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static SandboxUserCompanyApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<SandboxUserCompanyApiObject>(json);
        }
    }
}
