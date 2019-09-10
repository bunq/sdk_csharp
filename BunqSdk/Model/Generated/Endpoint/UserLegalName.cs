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
    /// Endpoint for getting available legal names that can be used by the user.
    /// </summary>
    public class UserLegalName : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/legal-name";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "UserLegalNameArray";

        /// <summary>
        /// All legal names that can be used by the user
        /// </summary>
        [JsonProperty(PropertyName = "legal_names")]
        public List<string> LegalNames { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<UserLegalName>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<UserLegalName>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.LegalNames != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserLegalName CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserLegalName>(json);
        }
    }
}