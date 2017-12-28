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
        private const string MonetaryAccountBankStatus = "CANCELLED";
        private const string MonetaryAccountBankSubStatus = "REDEMPTION_VOLUNTARY";
        private const string MonetaryAccountBankReason = "OTHER";
        private const string MonetaryAccountBankReasonDescription = "Because this is a test";
        private const string MonetaryAccountBankCurrencyEur = "EUR";
        private const string MonetaryAccountBankDescription = "Test C# monetary account";

        private static readonly int UserId = Config.GetUserId();

        /// <summary>
        /// API context used for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests the creation of a new monetary account. This accoult will then be removed afterwards.
        /// </summary>
        [Fact]
        public void TestCreationNewMonetaryAccount()
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FIELD_CURRENCY, MonetaryAccountBankCurrencyEur},
                {MonetaryAccountBank.FIELD_DESCRIPTION, MonetaryAccountBankDescription}
            };
            var monetaryAccountToCloseId = MonetaryAccountBank.Create(ApiContext, requestMap, UserId).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FIELD_STATUS, MonetaryAccountBankStatus},
                {MonetaryAccountBank.FIELD_SUB_STATUS, MonetaryAccountBankSubStatus},
                {MonetaryAccountBank.FIELD_REASON, MonetaryAccountBankReason},
                {MonetaryAccountBank.FIELD_REASON_DESCRIPTION, MonetaryAccountBankReasonDescription}
            };
            MonetaryAccountBank.Update(ApiContext, requestMap, UserId, idToClose);
        }
    }
}
