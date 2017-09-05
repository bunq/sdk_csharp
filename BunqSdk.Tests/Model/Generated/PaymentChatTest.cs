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
    ///     PaymentChat
    ///     ChatMessageText
    /// </summary>
    public class PaymentChatTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string AMOUNT_EUR = "0.01";
        private const string CURRENCY = "EUR";
        private const string PAYMENT_DESCRIPTION = "Payment From C# Test";
        private const string MESSAGE_TEXT = "test msg send from C# test";

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARTY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly Pointer COUNTER_PARTY_ALIAS = Config.GetCounterAliasSelf();

        /// <summary>
        /// API context used for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        /// <summary>
        /// Tests sending a chat message in a newly created payment.
        /// </summary>
        [Fact]
        public void TestSendPaymentChat()
        {
            var paymentChatMap = new Dictionary<string, object>();
            var chatId = PaymentChat.Create(API_CONTEXT, paymentChatMap, USER_ID, MONETARTY_ACCOUNT_ID,
                CreatePaymentAndGetId()).Value;

            var chatMessageMap = new Dictionary<string, object>
            {
                {ChatMessageText.FIELD_TEXT, MESSAGE_TEXT}
            };
            ChatMessageText.Create(API_CONTEXT, chatMessageMap, USER_ID, chatId);
        }

        private static int CreatePaymentAndGetId()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FIELD_AMOUNT, new Amount(AMOUNT_EUR, CURRENCY)},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_ALIAS},
                {Payment.FIELD_DESCRIPTION, PAYMENT_DESCRIPTION},
            };

            return Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARTY_ACCOUNT_ID).Value;
        }
    }
}
