using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated
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
        private static readonly ApiContext API_CONTEXT = GetApiContext();

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
                {Payment.FIELD_AMOUNT, new Amount(PAYMENT_AMOUNT_EUR, PAYMENT_CURRENCY)},
                {Payment.FIELD_DESCRIPTION, PAYMENT_DESCRIPTION},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_OTHER}
            };

            Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);
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
                {Payment.FIELD_AMOUNT, new Amount(PAYMENT_AMOUNT_EUR, PAYMENT_CURRENCY)},
                {Payment.FIELD_DESCRIPTION, PAYMENT_DESCRIPTION},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_SELF}
            };

            Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);
        }
    }
}
