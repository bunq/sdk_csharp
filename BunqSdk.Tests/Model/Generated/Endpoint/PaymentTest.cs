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
        private const string PAYMENT_AMOUNT_EUR = "0.01";

        private const string PAYMENT_CURRENCY = "EUR";
        private const string PAYMENT_DESCRIPTION = "C# test Payment";

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly Pointer COUNTER_PARTY_SELF = Config.GetCounterPartyAliasSelf();
        private static readonly Pointer COUNTER_PARTY_OTHER = Config.GetCounterPartyAliasOther();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests making a payment to another sanndbox user.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherUser()
        {
            Payment.Create(new Amount(PAYMENT_AMOUNT_EUR, PAYMENT_CURRENCY), COUNTER_PARTY_OTHER, PAYMENT_DESCRIPTION);
        }

        /// <summary>
        /// Tests making a payment to another monetary account.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherAccount()
        {
            Payment.Create(new Amount(PAYMENT_AMOUNT_EUR, PAYMENT_CURRENCY), COUNTER_PARTY_SELF, PAYMENT_DESCRIPTION);
        }
    }
}