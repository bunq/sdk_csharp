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
        private static readonly Pointer CounterPartyAliasSelf = Config.GetCounterPartyAliasSelf();
        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly int SecondMonetaryAccountId = Config.GetSecondMonetaryAccountId();

        /// <summary>
        /// RequestInquiry field value constatns.
        /// </summary>
        private const string ValueAmountEur = "0.01";
        private const string ValueCurrencyEur = "EUR";
        private const string ValueDescription = "C# test payment";
        private const string ValueStatus = "ACCEPTED";
        
        /// <summary>
        /// The index of the first item in an array.
        /// </summary>
        private const int IndexFirst = 0;
        
        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests sending a request from monetary account 1 to monetary account 2 and accepting this request.
        /// </summary>
        [Fact]
        public void TestRequestInquiry()
        {
            var requestMap = new Dictionary<string, object>
            {
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(ValueAmountEur, ValueCurrencyEur)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, CounterPartyAliasSelf},
                {RequestInquiry.FIELD_DESCRIPTION, ValueDescription},
                {RequestInquiry.FIELD_ALLOW_BUNQME, false}
            };

            RequestInquiry.Create(ApiContext, requestMap, UserId, MonetaryAccountId);

            Assert.Equal(ValueStatus, AcceptRequest());
        }

        private static string AcceptRequest()
        {
            var requestResponseId = RequestResponse.List(ApiContext, UserId, SecondMonetaryAccountId).Value[IndexFirst].Id.Value;

            var requestMap = new Dictionary<string, object>
            {
                {RequestResponse.FIELD_STATUS, ValueStatus}
            };

            return RequestResponse.Update(ApiContext, requestMap, UserId, SecondMonetaryAccountId,
                requestResponseId).Value.Status;
        }
    }
}
