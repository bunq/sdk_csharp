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
        private const string ContextFilenameTest = "context-save-restore-test.conf";

        private static ApiContext _apiContext;

        public ApiContextTest()
        {
            if (_apiContext == null) _apiContext = GetApiContext();
        }

        /// <summary>
        /// Tests serialization and de-serialization of the API context.
        /// </summary>
        [Fact]
        public void TestApiContextSerializeDeserialize()
        {
            var apiContextJson = _apiContext.ToJson();
            var apiContextDeSerialised = ApiContext.FromJson(apiContextJson);

            Assert.Equal(apiContextJson, apiContextDeSerialised.ToJson());
        }

        /// <summary>
        /// Tests saving and restoring of the API context.
        /// </summary>
        [Fact]
        public void TestApiContextSaveRestore()
        {
            var apiContextJson = _apiContext.ToJson();
            _apiContext.Save(ContextFilenameTest);
            var apiContextRestored = ApiContext.Restore(ContextFilenameTest);

            Assert.Equal(apiContextJson, apiContextRestored.ToJson());
        }
    }
}
