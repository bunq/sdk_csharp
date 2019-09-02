using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Utils;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Core
{
    public class OauthAccessToken : BunqModel
    {
        
        /// <summary>
        /// Field constants.
        /// </summary>
        protected const String FIELD_GRANT_TYPE = "grant_type";
        protected const String FIELD_CODE = "code";
        protected const String FIELD_REDIRECT_URI = "redirect_uri";
        protected const String FIELD_CLIENT_ID = "client_id";
        protected const String FIELD_CLIENT_SECRET = "client_secret";

        /// <summary>
        /// Token constants.
        /// </summary>
        protected const String TOKEN_URI_BASE = "https://api.oauth.bunq.com/v1/token?";
        
        [JsonProperty(PropertyName = "access_token")]
        protected string token;
        
        [JsonProperty(PropertyName = "token_type")]
        protected string type; 
        
        [JsonProperty(PropertyName = "state")]
        protected string state;

        /// <summary>
        /// Token value
        /// </summary>
        public string Token => token;
        
        /**
         * OauthAccessToken constructor.
         *
         * @param string $accessToken
         * @param string $tokenType
         * @param string $state
         */
        protected OauthAccessToken(
            string token,
            string type,
            string state = null
        ) {
            this.token = token;
            this.type = type;
            this.state = state;
        }

        [JsonConstructor]
        public OauthAccessToken() {}
        
        /// <summary>
        /// Create access token
        /// </summary>
        public static OauthAccessToken Create(
            string grantType,
            string authCode,
            string redirectUri,
            OauthClient client
        )
        {
            HttpClient apiClient = new HttpClient();
            HttpResponseMessage responseRaw = apiClient.PostAsync(
                CreateTokenUri(grantType, authCode, redirectUri, client),
                null
            ).Result;
            
            return BunqJsonConvert.DeserializeObject<OauthAccessToken>(responseRaw.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Create token URI string.
        /// </summary>
        protected static string CreateTokenUri(
            string grantType,
            string authCode,
            string redirectUri,
            OauthClient client
        ) {
            Dictionary<string, string> allTokenParameter = new Dictionary<string, string>()
            {
                { FIELD_GRANT_TYPE, grantType },
                { FIELD_CODE, authCode },
                { FIELD_REDIRECT_URI, redirectUri },
                { FIELD_CLIENT_ID, client.ClientId },
                { FIELD_CLIENT_SECRET, client.Secret },
            };
            
            return TOKEN_URI_BASE + HttpUtils.CreateQueryString(allTokenParameter);
        }

        public override bool IsAllFieldNull()
        {
            if (!String.IsNullOrEmpty(token))
            {
                return false;
            } 
            else if (!String.IsNullOrEmpty(type))
            {
                return false;
            }
            else if (!String.IsNullOrEmpty(state))
            {
                return false;
            }

            return true;
        }
    }
}