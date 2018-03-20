using System;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;
using Xunit.Sdk;

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
        private const string FILENAME_CONTEXT_CONF = "../../../bunq-test.conf";
        
        /// <summary>
        /// Config values.
        /// </summary>
        private const int SESSION_ID_DUMMY = 0;

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests the deleteion of the current session.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestSessionDeletion()
        {
            Session.Delete(SESSION_ID_DUMMY);

            File.Delete(FILENAME_CONTEXT_CONF);
        }
    }
}
