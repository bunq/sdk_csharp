using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     MonetaryAccountBank
    /// </summary>
    public class MonetaryAccountBankTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values
        /// </summary>
        private const string Status = "CANCELLED";
        private const string SubStatus = "REDEMPTION_VOLUNTARY";
        private const string Reason = "OTHER";
        private const string ReasonDescription = "Because this is a test";

        /// <summary>
        /// Tests the creation of a new monetary account. This account will then be removed afterwards.
        /// </summary>
        [Fact]
        public void TestCreationNewMonetaryAccount()
        {
            SetUpTestCase();

            var monetaryAccountToCloseId =
                MonetaryAccountBank.Create(PaymentCurrency, MonetaryAccountDescription).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            MonetaryAccountBank.Update(idToClose, status: Status, subStatus: SubStatus, reason: Reason,
                reasonDescription: ReasonDescription);
        }
    }
}