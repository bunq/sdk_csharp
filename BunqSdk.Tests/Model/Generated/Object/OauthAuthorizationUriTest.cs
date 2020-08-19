using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Object
{
    public class OauthAuthorizationUriTest : BunqSdkTestBase
    {
        private const string TEST_EXPECT_URI =
            "https://oauth.sandbox.bunq.com/auth?redirect_uri=redirecturi&response_type=code&state=state";
        private const string TEST_REDIRECT_URI = "redirecturi";
        private const string TEST_STATUS = "status";
        private const string TEST_STATE = "state";

        [Fact]
        public void TestOauthAuthorizationUriCreate()
        {
            SetUpTestCase();

            string uri = OauthAuthorizationUri.Create(
                OauthResponseType.CODE, TEST_REDIRECT_URI, new OauthClient {Status = TEST_STATUS}, TEST_STATE
            ).GetAuthorizationUri();

            Assert.Equal(TEST_EXPECT_URI, uri);
        }
    }
}