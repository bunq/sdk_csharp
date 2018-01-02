using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;

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
        private const string FilenameContextConf = "../../../bunq-test.conf";

        /// <summary>
        /// Device description used for tests.
        /// </summary>
        private const string DeviceDescriptionTest = "Csharp unit test";

        /// <summary>
        /// Configuration items.
        /// </summary>
        private static readonly string ApiKey = Config.GetApiKey();
        private static readonly string[] FieldAllPermittedIp = Config.GetAllPermittedIp();

        /// <summary>
        /// Gets an Api Context, re-creates if needed and returns it.
        /// </summary>
        protected static ApiContext GetApiContext()
        {
            ApiContext apiContext;

            try
            {
                apiContext = ApiContext.Restore(FilenameContextConf);
            }
            catch (BunqException)
            {
                apiContext = CreateApiContext();
            }

            apiContext.EnsureSessionActive();
            apiContext.Save(FilenameContextConf);

            return apiContext;
        }

        private static ApiContext CreateApiContext()
        {
            return ApiContext.Create(ApiEnvironmentType.Sandbox, ApiKey, DeviceDescriptionTest,
                new List<string>(FieldAllPermittedIp));
        }
    }
}
