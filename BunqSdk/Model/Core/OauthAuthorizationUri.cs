using System;
using System.Collections.Generic;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Utils;

namespace Bunq.Sdk.Model.Core
{
    public class OauthAuthorizationUri : BunqModel
    {
      
        /// <summary>
        /// The Authorization base-URI
        /// </summary>
        protected const string AUTH_URI_BASE = "https://oauth.bunq.com/auth?";

        /// <summary>
        /// Field constants.
        /// </summary>
        protected const string FIELD_RESPONSE_TYPE = "response_type";
        protected const string FIELD_REDIRECT_URI = "redirect_uri";
        protected const string FIELD_STATE = "state";
        protected const string FIELD_CLIENT_ID = "client_id";

        protected string authorizationUri;

        /// <summary>
        /// The Authorization URI to redirect the user to.
        /// </summary>
        public string AuthorizationUri => authorizationUri;
        
        /// <summary>
        /// Create new instance of the model.
        /// </summary>
        protected OauthAuthorizationUri(string authorizationUri)
        {
            this.authorizationUri = authorizationUri;
        }

        /**
         * @param BunqEnumOauthResponseType $responseType
         * @param string $redirectUri
         * @param OauthClient $client
         * @param string|null $state
         *
         * @return OauthAuthorizationUri
         */
        public static OauthAuthorizationUri Create(
            string responseType,
            string redirectUri,
            OauthClient client,
            string state = null
        )
        {
            Dictionary<string, string> allRequestParameter = new Dictionary<string, string>()
            {
                {FIELD_REDIRECT_URI, redirectUri},
                {FIELD_RESPONSE_TYPE, responseType},
                {FIELD_CLIENT_ID, client.ClientId},
            };

            if (!String.IsNullOrEmpty(state)) {
                allRequestParameter.Add(FIELD_STATE, state);
            }
            
            return new OauthAuthorizationUri(
                AUTH_URI_BASE + HttpUtils.CreateQueryString(allRequestParameter)
            );
        }

        public override bool IsAllFieldNull()
        {
            if (!String.IsNullOrEmpty(authorizationUri))
            {
                return false;
            }

            return true;
        }
    }
}