using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     Session
    /// </summary>
    public class SessionTest : BunqSdkTestBase
    {
        /// <summary>
        /// Name of the context configuration file.
        /// </summary>
        private const string FilenameContextConf = "../../../bunq-test.conf";
        
        /// <summary>
        /// Config values.
        /// </summary>
        private const int SessionIdDummy = 0;

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests the deleteion of the current session.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestSessionDeletion()
        {
            Session.Delete(ApiContext, SessionIdDummy);

            File.Delete(FilenameContextConf);
        }
    }
}
