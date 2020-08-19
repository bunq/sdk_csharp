using System;
using Bunq.Sdk.Context;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FieldSessionContext = "session_context";
        private const string FieldExpiryTime = "expiry_time";

        private static ApiContext apiContext;

        public ApiContextTest()
        {
            if (apiContext == null) apiContext = SetUpApiContext();
        }

        /// <summary>
        /// Tests serialization and de-serialization of the API context.
        /// </summary>
        [Fact]
        public void TestApiContextSerializeDeserialize()
        {
            var apiContextJson = BunqContext.ApiContext.ToJson();
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
            apiContext.Save(ContextFilenameTest);
            var apiContextRestored = ApiContext.Restore(ContextFilenameTest);

            Assert.Equal(apiContextJson, apiContextRestored.ToJson());
        }

        [Fact]
        public void TestAutoApiContextReLoad()
        {
            var contextJson = JObject.Parse(apiContext.ToJson());
            var expiredTime = DateTime.Now.Subtract(TimeSpan.FromDays(20));
            contextJson.SelectToken(FieldSessionContext)[FieldExpiryTime] = expiredTime.ToString();

            var expiredApiContext = ApiContext.FromJson(contextJson.ToString());

            Assert.NotEqual(apiContext, expiredApiContext);

            BunqContext.UpdateApiContext(expiredApiContext);

            Assert.Equal(expiredApiContext, BunqContext.ApiContext);

            BunqContext.UserContext.RefreshUserContext();

            Assert.True(BunqContext.ApiContext.IsSessionActive());
        }
    }
}