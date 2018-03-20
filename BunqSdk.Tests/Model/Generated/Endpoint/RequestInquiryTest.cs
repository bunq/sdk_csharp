using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     RequestInquiry
    ///     RequestResponse
    /// </summary>
    public class RequestInquiryTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string AMOUNT_EUR = "0.01";
        private const string FIELD_CURRENCY = "EUR";
        private const string PAYMENT_DESCRIPTION = "C# test Payment";
        private const string STATUS = "ACCEPTED";
        private const int INDEX_FIRST = 0;

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly int SECOND_MONETARY_ACCOUNT_ID = Config.GetSecondMonetaryAccountId();
        private static readonly Pointer COUNTER_PARTY_SELF = Config.GetCounterPartyAliasSelf();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests sending a request from monetary account 1 to monetary account 2 and accepting this request.
        /// </summary>
        [Fact]
        public void TestRequestInquiry()
        {
            RequestInquiry.Create(new Amount(AMOUNT_EUR, FIELD_CURRENCY), COUNTER_PARTY_SELF, PAYMENT_DESCRIPTION, false);

            Assert.Equal(STATUS, AcceptRequest());
        }

        private static string AcceptRequest()
        {
            var requestResponseId = RequestResponse.List().Value[INDEX_FIRST].Id.Value;

            return RequestResponse.Update(requestResponseId, status: STATUS).Value.Status;
        }
    }
}
