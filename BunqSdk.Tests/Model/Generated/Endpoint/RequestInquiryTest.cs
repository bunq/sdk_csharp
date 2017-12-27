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
        private const string Amount = "0.01";
        private const string Currency = "EUR";
        private const string Description = "C# test Payment";
        private const string Status = "ACCEPTED";
        private const int IndexFirst = 0;

        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly int SecondMonetaryAccountId = Config.GetSecondMonetaryAccountId();
        private static readonly Pointer CounterSelfParty = Config.GetCounterPartyAliasSelf();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        /// <summary>
        /// Tests sending a request from monetary account 1 to monetary account 2 and accepting this request.
        /// </summary>
        [Fact]
        public void TestRequestInquiry()
        {
            var requestMap = new Dictionary<string, object>
            {
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(Amount, Currency)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, CounterSelfParty},
                {RequestInquiry.FIELD_DESCRIPTION, Description},
                {RequestInquiry.FIELD_ALLOW_BUNQME, false}
            };

            RequestInquiry.Create(API_CONTEXT, requestMap, UserId, MonetaryAccountId);

            Assert.Equal(Status, AcceptRequest());
        }

        private static string AcceptRequest()
        {
            var requestResponseId = RequestResponse
                .List(API_CONTEXT, UserId, SecondMonetaryAccountId).Value[IndexFirst].Id.Value;

            var requestMap = new Dictionary<string, object>
            {
                {RequestResponse.FIELD_STATUS, Status}
            };

            return RequestResponse.Update(API_CONTEXT, requestMap, UserId, SecondMonetaryAccountId,
                requestResponseId).Value.Status;
        }
    }
}
