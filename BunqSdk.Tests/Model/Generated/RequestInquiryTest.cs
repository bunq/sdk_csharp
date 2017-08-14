using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated
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
        private const string AMOUNT_IN_EUR = "0.01";
        private const string FIELD_CURRENCY = "EUR";
        private const string FIELD_PAYMENT_DESCRIPTION = "C# test Payment";
        private const string FIELD_STATUS = "ACCEPTED";
        private const int INDEX_FIRST = 0;

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly int SECOND_MONETARY_ACCOUNT_ID = Config.GetSecondMonetaryAccountId();
        private static readonly Pointer COUNTER_PARTY_SELF = Config.GetCounterAliasSelf();

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
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(AMOUNT_IN_EUR, FIELD_CURRENCY)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_SELF},
                {RequestInquiry.FIELD_DESCRIPTION, FIELD_PAYMENT_DESCRIPTION},
                {RequestInquiry.FIELD_ALLOW_BUNQME, false}
            };

            RequestInquiry.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);

            Assert.Equal(FIELD_STATUS, AcceptRequest());
        }

        private static string AcceptRequest()
        {
            var requestResponseId = RequestResponse
                .List(API_CONTEXT, USER_ID, SECOND_MONETARY_ACCOUNT_ID).Value[INDEX_FIRST].Id.Value;

            var requestMap = new Dictionary<string, object>
            {
                {RequestResponse.FIELD_STATUS, FIELD_STATUS}
            };

            return RequestResponse.Update(API_CONTEXT, requestMap, USER_ID, SECOND_MONETARY_ACCOUNT_ID,
                requestResponseId).Value.Status;
        }
    }
}
