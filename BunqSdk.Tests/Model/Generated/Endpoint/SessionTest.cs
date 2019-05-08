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
        /// Config values.
        /// </summary>
        private const int SessionIdDummy = 0;

        /// <summary>
        /// Tests the deleteion of the current session.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestSessionDeletion()
        {
            SetUpTestCase();

            Session.Delete(SessionIdDummy);

            File.Delete(FilenameContextConf);
        }
    }
}