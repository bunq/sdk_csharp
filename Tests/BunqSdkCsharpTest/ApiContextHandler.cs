using System;
using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Generated;

namespace Bunq.Sdk.Tests
{
    /// <summary>
    /// Will check fi the current session token is still valid.
    /// </summary>
    public class ApiContextHandler
    {
        private const string FILENAME_CONTEXT_CONF = "../../../bunq-test.conf";
        private const string DEVICE_DESCRIPTION = "Csharp unit test";
        private static readonly string API_KEY = Config.GetApiKey();
        private static readonly string FIELD_PERMITTED_IP = Config.GetPermittedIp();

        /// <summary>
        /// Calls IsSessionActive to check if the session token is still active and returns the ApiContext.
        /// </summary>
        public static ApiContext GetApiContext()
        {
            if (IsSessionActive()) return ApiContext.Restore(FILENAME_CONTEXT_CONF);

            var permittedIp = new List<string> {FIELD_PERMITTED_IP};
            var apiContext = new ApiContext(ApiEnvironmentType.SANDBOX, API_KEY);
            apiContext.Initialize(DEVICE_DESCRIPTION, permittedIp);
            apiContext.Save(FILENAME_CONTEXT_CONF);

            return apiContext;
        }

        /// <summary>
        /// Catches BunqEception if the conf file does not exist.
        /// Catches ApiExceptoin if the session is inactive.
        /// </summary>
        /// <returns>True, if the restores ApiContext can be used, otherwise false.</returns>
        private static bool IsSessionActive()
        {
            try
            {
                var apiContext = ApiContext.Restore(FILENAME_CONTEXT_CONF);
                if (apiContext == null)
                    return false;

                User.List(apiContext);
                
                return true;
            }
            catch (BunqException)
            {
                return false;
            }
            catch (ApiException)
            {
                return false;
            }
        }
    }
}
