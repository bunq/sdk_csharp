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
        private const string AmountEur = "0.01";
        private const string FieldCurrency = "EUR";
        private const string FieldPaymentDescription = "C# test Payment";
        private const string FieldStatus = "ACCEPTED";
        private const int IndexFirst = 0;

        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly int SecondMonetaryAccountId = Config.GetSecondMonetaryAccountId();
        private static readonly Pointer CounterPartySelf = Config.GetCounterPartyAliasSelf();

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
                {RequestInquiry.FieldAmountInquired, new Amount(AmountEur, FieldCurrency)},
                {RequestInquiry.FieldCounterpartyAlias, CounterPartySelf},
                {RequestInquiry.FieldDescription, FieldPaymentDescription},
                {RequestInquiry.FieldAllowBunqme, false}
            };

            RequestInquiry.Create(ApiContext, requestMap, UserId, MonetaryAccountId);

            Assert.Equal(FieldStatus, AcceptRequest());
        }

        private static string AcceptRequest()
        {
            var requestResponseId = RequestResponse
                .List(ApiContext, UserId, SecondMonetaryAccountId).Value[IndexFirst].Id.Value;

            var requestMap = new Dictionary<string, object>
            {
                {RequestResponse.FieldStatus, FieldStatus}
            };

            return RequestResponse.Update(ApiContext, requestMap, UserId, SecondMonetaryAccountId,
                requestResponseId).Value.Status;
        }
    }
}
