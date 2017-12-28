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
    ///     PaymentChat
    ///     ChatMessageText
    /// </summary>
    public class PaymentChatTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly Pointer CounterPartyAliasSelf = Config.GetCounterPartyAliasSelf();

        /// <summary>
        /// Payment and PaymentChat field value constatns.
        /// </summary>
        private const string ValueAmountEur = "0.01";
        private const string ValueCurrencyEur = "EUR";
        private const string ValueDescription = "Payment from C# test";
        private const string ValueText = "Test message sent from C# test";
        
        /// <summary>
        /// API context used for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests sending a chat message in a newly created payment.
        /// </summary>
        [Fact]
        public void TestSendPaymentChat()
        {
            var paymentChatMap = new Dictionary<string, object>();
            var chatId = PaymentChat.Create(ApiContext, paymentChatMap, UserId, MonetaryAccountId,
                CreatePaymentAndGetId()).Value;

            var chatMessageMap = new Dictionary<string, object>
            {
                {ChatMessageText.FIELD_TEXT, ValueText}
            };
            ChatMessageText.Create(ApiContext, chatMessageMap, UserId, chatId);
        }

        private static int CreatePaymentAndGetId()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FIELD_AMOUNT, new Amount(ValueAmountEur, ValueCurrencyEur)},
                {Payment.FIELD_COUNTERPARTY_ALIAS, CounterPartyAliasSelf},
                {Payment.FIELD_DESCRIPTION, ValueDescription},
            };

            return Payment.Create(ApiContext, requestMap, UserId, MonetaryAccountId).Value;
        }
    }
}
