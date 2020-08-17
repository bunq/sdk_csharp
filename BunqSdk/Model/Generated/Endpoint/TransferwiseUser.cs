using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to manage Transferwise users.
    /// </summary>
    public class TransferwiseUser : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/transferwise-user";

        protected const string ENDPOINT_URL_LISTING = "user/{0}/transferwise-user";

        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_OAUTH_CODE = "oauth_code";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwiseUser";

        /// <summary>
        ///     The OAuth code returned by Transferwise we should be using to gain access to the user's Transferwise
        ///     account.
        /// </summary>
        [JsonProperty(PropertyName = "oauth_code")]
        public string OauthCode { get; set; }

        /// <summary>
        ///     The id of the TransferwiseUser.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the TransferwiseUser's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the TransferwiseUser's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        ///     The name the user is registered with at TransferWise.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     The email the user is registered with at TransferWise.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="oauthCode">
        ///     The OAuth code returned by Transferwise we should be using to gain access to the user's
        ///     Transferwise account.
        /// </param>
        public static BunqResponse<int> Create(string oauthCode = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_OAUTH_CODE, oauthCode}
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<TransferwiseUser>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<TransferwiseUser>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (Name != null) return false;

            if (Email != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static TransferwiseUser CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TransferwiseUser>(json);
        }
    }
}