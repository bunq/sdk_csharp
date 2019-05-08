using System.Collections.Generic;
using System.Linq;
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
        /// Tests making a payment to another sanndbox user.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherUser()
        {
            SetUpTestCase();

            Payment.Create(new Amount(PaymentAmountEur, PaymentCurrency), GetPointerBravo(), PaymentDescription);
        }

        /// <summary>
        /// Tests making a payment to another monetary account.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestMakePaymentToOtherAccount()
        {
            SetUpTestCase();

            Payment.Create(
                new Amount(PaymentAmountEur, PaymentCurrency),
                SecondMonetaryAccountBank.Alias.First(),
                PaymentDescription
            );
        }
    }
}