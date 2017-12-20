using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;

namespace Bunq.Sdk.Model.Core
{
    public class Installation : BunqModel
    {
        /// <summary>
        /// Endpoint name.
        /// </summary>
        private const string ENDPOINT_URL_POST = "installation";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_CLIENT_PUBLIC_KEY = "client_public_key";

        public SessionToken SessionToken { get; private set; }
        private readonly Id id;
        private readonly PublicKeyServer publicKeyServer;

        public Installation(Id id, SessionToken sessionToken, PublicKeyServer publicKeyServer)
        {
            this.id = id;
            SessionToken = sessionToken;
            this.publicKeyServer = publicKeyServer;
        }

        /// <summary>
        /// This is the only API call that does not require you to use the
        /// "X-Bunq-Client-Authentication" and "X-Bunq-Client-Signature" headers. You
        /// provide the server with the public part of the key pair that you are going
        /// to use to create the value of the signature header for all future API
        /// calls. The server creates an installation for you. Store the Installation
        /// Token and ServerPublicKey from the response. This token is used in the
        /// "X-Bunq-Client-Authentication" header for the creation of a DeviceServer
        /// and SessionServer.
        /// </summary>
        public static BunqResponse<Installation> Create(ApiContext apiContext, string publicKeyClientString)
        {
            var requestBytes = GenerateRequestBodyBytes(publicKeyClientString);
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Post(ENDPOINT_URL_POST, requestBytes, new Dictionary<string, string>());

            return FromJsonArrayNested<Installation>(responseRaw);
        }

        private static byte[] GenerateRequestBodyBytes(string publicKeyClientString)
        {
            var installationRequestBody =
                new Dictionary<string, object> {{FIELD_CLIENT_PUBLIC_KEY, publicKeyClientString}};

            return Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(installationRequestBody));
        }

        public int GetIdInt()
        {
            return id.IdInt;
        }

        public string GetPublicKeyServerString()
        {
            return publicKeyServer.ServerPublicKey;
        }

        public override bool IsAllFieldNull()
        {
            if (this.SessionToken != null)
            {
                return false;
            }           
            
            if (this.id != null)
            {
                return false;
            }
            
            if (this.publicKeyServer != null)
            {
                return false;
            }

            return true;
        }
    }
}
