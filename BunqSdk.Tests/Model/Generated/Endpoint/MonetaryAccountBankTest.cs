using System.Collections.Generic;
using Bunq.Sdk.Context;
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
        private const string STATUS = "CANCELLED";

        private const string SUBS_STATUS = "REDEMPTION_VOLUNTARY";
        private const string REASON = "OTHER";
        private const string REASON_DESCRIPTION = "Because this is a test";
        private const string CURRENCY = "EUR";
        private const string MONETARY_ACCOUNT_DESCRIPTION = "Test C# monetary account";

        private static readonly int USER_ID = Config.GetUserId();

        /// <summary>
        /// API context used for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests the creation of a new monetary account. This accoult will then be removed afterwards.
        /// </summary>
        [Fact]
        public void TestCreationNewMonetaryAccount()
        {
            var monetaryAccountToCloseId = MonetaryAccountBank.Create(CURRENCY, MONETARY_ACCOUNT_DESCRIPTION).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            MonetaryAccountBank.Update(idToClose, status: STATUS, subStatus: SUBS_STATUS, reason: REASON,
                reasonDescription: REASON_DESCRIPTION);
        }
    }
}