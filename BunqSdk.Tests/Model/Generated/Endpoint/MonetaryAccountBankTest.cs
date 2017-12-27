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
        private const string Status = "CANCELLED";
        private const string SubsStatus = "REDEMPTION_VOLUNTARY";
        private const string Reason = "OTHER";
        private const string ReasonDescription = "Because this is a test";
        private const string Currency = "EUR";
        private const string MonetaryAccountDescription = "Test C# monetary account";

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
                {MonetaryAccountBank.FieldCurrency, Currency},
                {MonetaryAccountBank.FieldDescription, MonetaryAccountDescription}
            };
            var monetaryAccountToCloseId = MonetaryAccountBank.Create(ApiContext, requestMap, UserId).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FieldStatus, Status},
                {MonetaryAccountBank.FieldSubStatus, SubsStatus},
                {MonetaryAccountBank.FieldReason, Reason},
                {MonetaryAccountBank.FieldReasonDescription, ReasonDescription}
            };
            MonetaryAccountBank.Update(ApiContext, requestMap, UserId, idToClose);
        }
    }
}
