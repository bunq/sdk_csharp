using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace BunqSdk.Examples
{
    class CreatePsd2OauthClient
    {

        /// <summary>
        /// API constants.
        /// </summary>
        private const String API_DEVICE_DESCRIPTION = "##### YOUR DEVICE DESCRIPTION #####";
        private const String API_OAUTH_REDIRECT_URL = "https://localhost/oauth/redirect";

        protected static ApiEnvironmentType API_ENVIRONMENT_TYPE => ApiEnvironmentType.SANDBOX;

        /// <summary>
        /// Password constants.
        /// </summary>
        private const String PASSWORD_PSD2_CREDENTIALS = "secret";

        /// <summary>
        /// The absolute path to your file storage (data) directory.
        /// </summary>
        private const String FILE_STORAGE_PATH = "/users/nick/bunq-src/bunq_public_api/sdk_csharp/BunqSdk.Examples/data/";
        
        /// <summary>
        /// File constants.
        /// </summary>
        private const String FILE_PSD2_CREDENTIALS = "{0}/credentials.pfx";
        private const String FILE_PSD2_CERTIFICATE_CHAIN = "{0}/chain.cert";

        private const String FILE_PSD2_CONFIGURATION = "{0}/psd2.conf";
        private const String FILE_OAUTH_CONFIGURATION = "{0}/oauth.conf";

        /// <summary>
        /// Helpers to check for existing configurations.
        /// </summary>
        protected static bool HasContextConfiguration => File.Exists(GetRelativePath(FILE_PSD2_CONFIGURATION));
        protected static bool HasOauthClientConfiguration => File.Exists(GetRelativePath(FILE_OAUTH_CONFIGURATION));        
        
        /**
         * Set-up a PSD2 OAuth client for communication with the bunq API.
         */
        static void Main(string[] args)
        {

            // Get the context
            ApiContext apiContext = DetermineApiContext();

            // Initialize the BunqContext
            BunqContext.LoadApiContext(apiContext);

            // Get the oauth client.
            OauthClient oauthClient = DetermineOauthClient();
            
            // Display the authorization url
            OauthAuthorizationUri authorizationUri = OauthAuthorizationUri.Create(
                "code",
                API_OAUTH_REDIRECT_URL,
                oauthClient
            );
            
            Console.WriteLine("Redirect your user to " + authorizationUri.AuthorizationUri + " to obtain an Authorization code.");
            Console.WriteLine("Wait for the user to be redirected, copy the code from the URL, paste it here and press enter.");

            Console.Write("Token: ");
            
            String authCode = Console.ReadLine();
            OauthAccessToken accessToken = GetAuthCodeByToken(authCode, oauthClient);

            // Initialize the user api context
            apiContext = ApiContext.Create(
                API_ENVIRONMENT_TYPE,
                accessToken.Token,
                API_DEVICE_DESCRIPTION
            );
            
            // Load new context
            BunqContext.LoadApiContext(apiContext);
            
            // You can now perform actions for the authenticated user. For example list his/her monitary accounts.
            List<MonetaryAccount> allMonetaryAccount = MonetaryAccount.List().Value;
            foreach (MonetaryAccount monetaryAccount in allMonetaryAccount)
            {
                Console.WriteLine(
                    $"Account found with balance of {monetaryAccount.MonetaryAccountBank.Balance.Value} {monetaryAccount.MonetaryAccountBank.Balance.Currency}."
                );
            }
            
        }

        /// <summary>
        /// Exhange auth code for access token.
        /// </summary>
        protected static OauthAccessToken GetAuthCodeByToken(String authCode, OauthClient client)
        {
            return OauthAccessToken.Create(
                "authorization_code",
                authCode,
                API_OAUTH_REDIRECT_URL,
                client
            );
        }
            
        /// <summary>
        /// Determine what ApiContext should be used.
        /// </summary>
        protected static ApiContext DetermineApiContext()
        {
            if (HasContextConfiguration)
            {
                return ApiContext.Restore(GetRelativePath(FILE_PSD2_CONFIGURATION));
            }
            else
            {
                return CreateNewPsd2Context();
            }
        }

        /// <summary>
        /// Determine the oauth client that should be used.
        /// </summary>
        protected static OauthClient DetermineOauthClient()
        {
            if (HasOauthClientConfiguration)
            {
                String oauthClientString = File.ReadAllText(GetRelativePath(FILE_OAUTH_CONFIGURATION));
                return OauthClient.CreateFromJsonString(oauthClientString);
            }
            else
            {
                return CreateNewOauthClient();
            }
        }

        /// <summary>
        /// Create a new oauth client.
        /// </summary>
        protected static OauthClient CreateNewOauthClient()
        {
            int oauthClientId = OauthClient.Create().Value;
            
            OauthCallbackUrl.Create(
                oauthClientId,
                API_OAUTH_REDIRECT_URL
            );

            OauthClient oauthClient = OauthClient.Get(oauthClientId).Value;

            File.WriteAllText(
                GetRelativePath(FILE_OAUTH_CONFIGURATION),
                BunqJsonConvert.SerializeObject(oauthClient)
            );

            return oauthClient;
        }

        /// <summary>
        /// Create a new PSD2 Api Context
        /// </summary>
        protected static ApiContext CreateNewPsd2Context()
        {
            
            // Create the certificate chain
            X509CertificateCollection certificateChain = new X509CertificateCollection();
            certificateChain.Add(
                X509Certificate.CreateFromCertFile(GetRelativePath(FILE_PSD2_CERTIFICATE_CHAIN))
            );

            // Load the public certificate
            X509Certificate2 publicCertificate = new X509Certificate2(GetRelativePath(FILE_PSD2_CREDENTIALS), PASSWORD_PSD2_CREDENTIALS);
            
            // Setup the API context.
            ApiContext apiContext = ApiContext.CreateForPsd2(
                API_ENVIRONMENT_TYPE,
                publicCertificate,
                certificateChain,
                API_DEVICE_DESCRIPTION,
                new List<String>()
            );
            
            // Store the context
            apiContext.Save(GetRelativePath(FILE_PSD2_CONFIGURATION));

            return apiContext;
        }

        /// <summary>
        /// Transform path constant into relative path.
        /// </summary>
        protected static string GetRelativePath(String path)
        {
            return String.Format(path, FILE_STORAGE_PATH);
        }
    }
}