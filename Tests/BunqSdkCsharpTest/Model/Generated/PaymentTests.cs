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
    public class PaymentTests
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string AMOUNT_IN_EUR = "00.01";
        private const string FIELD_CURRENCY = "EUR";
        private const string FIELD_PAYMENT_DESCRIPTION = "C# test Payment";

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly Pointer COUNTER_PARTY_SELF = Config.GetCounterAliasSelf();
        private static readonly Pointer COUNTER_PARTY_OTHER = Config.GetCounterAliasOther();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = ApiContextHandler.GetApiContext();
        
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
                {Payment.FIELD_AMOUNT, new Amount(AMOUNT_IN_EUR, FIELD_CURRENCY)},
                {Payment.FIELD_DESCRIPTION, FIELD_PAYMENT_DESCRIPTION},
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
                {Payment.FIELD_AMOUNT, new Amount(AMOUNT_IN_EUR, FIELD_CURRENCY)},
                {Payment.FIELD_DESCRIPTION, FIELD_PAYMENT_DESCRIPTION},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_SELF}
            };

            Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);
        }
    }
}
