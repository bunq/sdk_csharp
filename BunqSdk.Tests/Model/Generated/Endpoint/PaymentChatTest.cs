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
        private const string MessageText = "test msg send from C# test";

        /// <summary>
        /// Tests sending a chat message in a newly created payment.
        /// </summary>
        [Fact]
        public void TestSendPaymentChat()
        {
            SetUpTestCase();

            var chatId = PaymentChat.Create(CreatePaymentAndGetId()).Value;

            ChatMessageText.Create(chatId, MessageText);
        }

        private static int CreatePaymentAndGetId()
        {
            return Payment.Create(
                new Amount(PaymentAmountEur, PaymentCurrency),
                GetPointerBravo(),
                PaymentDescription
                ).Value;
        }
    }
}
