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
    /// Endpoint for getting all the known (trade) names for a user company. This is needed for updating the user name,
    /// as we only accept legal or trade names.
    /// </summary>
    public class UserCompanyName : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user-company/{0}/name";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "UserCompanyNameArray";

        /// <summary>
        /// All known (trade) names for a user company.
        /// </summary>
        [JsonProperty(PropertyName = "name_array")]
        public List<string> NameArray { get; set; }

        /// <summary>
        /// Return all the known (trade) names for a specific user company.
        /// </summary>
        public static BunqResponse<List<UserCompanyName>> List(int userCompanyId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<UserCompanyName>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NameArray != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserCompanyName CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserCompanyName>(json);
        }
    }
}