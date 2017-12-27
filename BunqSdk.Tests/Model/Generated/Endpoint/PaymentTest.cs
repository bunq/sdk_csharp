using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     Payment
    /// </summary>
    public class PaymentTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string PaymentAmountEur = "0.01";
        private const string PaymentCurrency = "EUR";
        private const string PaymentDescription = "C# test Payment";

        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly Pointer CounterPartySelf = Config.GetCounterPartyAliasSelf();
        private static readonly Pointer CounterPartyOther = Config.GetCounterPartyAliasOther();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests making a payment to another sanndbox user.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherUser()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FieldAmount, new Amount(PaymentAmountEur, PaymentCurrency)},
                {Payment.FieldDescription, PaymentDescription},
                {Payment.FieldCounterpartyAlias, CounterPartyOther}
            };

            Payment.Create(ApiContext, requestMap, UserId, MonetaryAccountId);
        }

        /// <summary>
        /// Tests making a payment to another monetary account.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherAccount()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FieldAmount, new Amount(PaymentAmountEur, PaymentCurrency)},
                {Payment.FieldDescription, PaymentDescription},
                {Payment.FieldCounterpartyAlias, CounterPartySelf}
            };

            Payment.Create(ApiContext, requestMap, UserId, MonetaryAccountId);
        }
    }
}
