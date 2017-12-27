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
        private const string AmountEur = "0.01";
        private const string Currency = "EUR";
        private const string PaymentDescription = "Payment From C# Test";
        private const string MessageText = "test msg send from C# test";

        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetartyAccountId = Config.GetMonetarytAccountId();
        private static readonly Pointer CounterPartyAlias = Config.GetCounterPartyAliasSelf();

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
            var chatId = PaymentChat.Create(ApiContext, paymentChatMap, UserId, MonetartyAccountId,
                CreatePaymentAndGetId()).Value;

            var chatMessageMap = new Dictionary<string, object>
            {
                {ChatMessageText.FieldText, MessageText}
            };
            ChatMessageText.Create(ApiContext, chatMessageMap, UserId, chatId);
        }

        private static int CreatePaymentAndGetId()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FieldAmount, new Amount(AmountEur, Currency)},
                {Payment.FieldCounterpartyAlias, CounterPartyAlias},
                {Payment.FieldDescription, PaymentDescription},
            };

            return Payment.Create(ApiContext, requestMap, UserId, MonetartyAccountId).Value;
        }
    }
}
