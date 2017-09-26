using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Tests
{
    /// <summary>
    /// Base class for all the Bunq SDK tests.
    /// </summary>
    public class BunqSdkTestBase
    {
        /// <summary>
        /// Name of the context configuration file.
        /// </summary>
        private const string FILENAME_CONTEXT_CONF = "../../../bunq-test.conf";

        /// <summary>
        /// Device description used for tests.
        /// </summary>
        private const string DEVICE_DESCRIPTION_TEST = "Csharp unit test";

        /// <summary>
        /// Configuration items.
        /// </summary>
        private static readonly string API_KEY = Config.GetApiKey();
        private static readonly string[] FIELD_PERMITTED_IPS = Config.GetPermittedIps();

        /// <summary>
        /// Gets an Api Context, re-creates if needed and returns it.
        /// </summary>
        protected static ApiContext GetApiContext()
        {
            ApiContext apiContext;

            try
            {
                apiContext = ApiContext.Restore(FILENAME_CONTEXT_CONF);
                User.List(apiContext);
            }
            catch (BunqException)
            {
                apiContext = CreateApiContext();
            }
            catch (ApiException)
            {
                apiContext = CreateApiContext();
            }

            apiContext.Save(FILENAME_CONTEXT_CONF);

            return apiContext;
        }

        private static ApiContext CreateApiContext()
        {
            return ApiContext.Create(ApiEnvironmentType.SANDBOX, API_KEY, DEVICE_DESCRIPTION_TEST,
                new List<string>(FIELD_PERMITTED_IPS));
        }
    }
}
