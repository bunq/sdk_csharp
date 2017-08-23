using Bunq.Sdk.Context;
using Xunit;

namespace Bunq.Sdk.Tests.Context
{
    /// <summary>
    /// Tests:
    ///     ApiContext
    /// </summary>
    public class ApiContextTest : BunqSdkTestBase, IClassFixture<ApiContextTest>
    {
        /// <summary>
        /// Path to a temporary context file.
        /// </summary>
        private const string CONTEXT_FILENAME_TEST = "context-save-restore-test.conf";

        private static ApiContext apiContext;

        public ApiContextTest()
        {
            if (apiContext == null) apiContext = GetApiContext();
        }

        /// <summary>
        /// Tests serialization and de-serialization of the API context.
        /// </summary>
        [Fact]
        public void TestApiContextSerializeDeserialize()
        {
            var apiContextJson = apiContext.ToJson();
            var apiContextDeSerialised = ApiContext.FromJson(apiContextJson);

            Assert.Equal(apiContextJson, apiContextDeSerialised.ToJson());
        }

        /// <summary>
        /// Tests saving and restoring of the API context.
        /// </summary>
        [Fact]
        public void TestApiContextSaveRestore()
        {
            var apiContextJson = apiContext.ToJson();
            apiContext.Save(CONTEXT_FILENAME_TEST);
            var apiContextRestored = ApiContext.Restore(CONTEXT_FILENAME_TEST);

            Assert.Equal(apiContextJson, apiContextRestored.ToJson());
        }
    }
}
