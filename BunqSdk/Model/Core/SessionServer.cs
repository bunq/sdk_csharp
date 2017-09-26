using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Model.Core
{
    public class SessionServer : BunqModel
    {
        /// <summary>
        /// Endpoint name.
        /// </summary>
        private const string ENDPOINT_URL_POST = "session-server";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_SECRET = "secret";

        public Id Id { get; private set; }
        public SessionToken SessionToken { get; private set; }
        public UserCompany UserCompany { get; private set; }
        public UserPerson UserPerson { get; private set; }

        public SessionServer(Id id, SessionToken sessionToken, UserCompany userCompany)
        {
            Id = id;
            SessionToken = sessionToken;
            UserCompany = userCompany;
        }

        public SessionServer(Id id, SessionToken sessionToken, UserPerson userPerson)
        {
            Id = id;
            SessionToken = sessionToken;
            UserPerson = userPerson;
        }

        /// <summary>
        /// Create a new session for a DeviceServer. Provide the Installation token
        /// in the "X-Bunq-Client-Authentication" header. And don't forget to create
        /// the "X-Bunq-Client-Signature" header. The response contains a Session
        /// token that should be used for as the "X-Bunq-Client-Authentication" header
        /// for all future API calls. The ip address making this call needs to match
        /// the ip address bound to your API key.
        /// </summary>
        public static BunqResponse<SessionServer> Create(ApiContext apiContext)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = GenerateRequestBodyBytes(apiContext.ApiKey);
            var responseRaw = apiClient.Post(ENDPOINT_URL_POST, requestBytes, new Dictionary<string, string>());

            return FromJsonArrayNested<SessionServer>(responseRaw);
        }

        private static byte[] GenerateRequestBodyBytes(string apiKey)
        {
            var sessionServerRequestBody = new Dictionary<string, object> {{FIELD_SECRET, apiKey}};

            return Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(sessionServerRequestBody));
        }
    }
}
