using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Http
{
    public class ResponseIdOnBadRequestTest : BunqSdkTestBase
    {
        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();
        
        /// <summary>
        /// Invalid user id to trigger BadRequestException
        /// </summary>
        private const int INVALID_USER_PERSON_ID = 0;

        [Fact]
        public void TestBadRequestWithResponseId()
        {
            var caughtException = Assert.Throws<BadRequestException>(
                () => UserPerson.Get(API_CONTEXT, INVALID_USER_PERSON_ID)
            );
            
            Assert.NotNull(caughtException.ResponseId);
        }
    }
}