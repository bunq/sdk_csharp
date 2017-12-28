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
        private static readonly int UserId = Config.GetUserId();

        /// <summary>
        /// MonetaryAccount field value constatns.
        /// </summary>
        private const string ValueStatus = "CANCELLED";
        private const string ValueSubStatus = "REDEMPTION_VOLUNTARY";
        private const string ValueReason = "OTHER";
        private const string ValueReasonDescription = "Because this is a test";
        private const string ValueCurrencyEur = "EUR";
        private const string ValueDescription = "Test C# monetary account";
        
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
                {MonetaryAccountBank.FIELD_CURRENCY, ValueCurrencyEur},
                {MonetaryAccountBank.FIELD_DESCRIPTION, ValueDescription}
            };
            var monetaryAccountToCloseId = MonetaryAccountBank.Create(ApiContext, requestMap, UserId).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FIELD_STATUS, ValueStatus},
                {MonetaryAccountBank.FIELD_SUB_STATUS, ValueSubStatus},
                {MonetaryAccountBank.FIELD_REASON, ValueReason},
                {MonetaryAccountBank.FIELD_REASON_DESCRIPTION, ValueReasonDescription}
            };
            MonetaryAccountBank.Update(ApiContext, requestMap, UserId, idToClose);
        }
    }
}
