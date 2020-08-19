using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Http
{
    public class ResponseIdOnNotFoundRequestTest : BunqSdkTestBase
    {
        [Fact]
        public void TestBadRequestWithResponseId()
        {
            SetUpTestCase();

            var caughtException = Assert.Throws<NotFoundException>(
                () => Payment.Get(0)
            );

            Assert.NotNull(caughtException.ResponseId);
        }
    }
}