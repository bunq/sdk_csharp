using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated
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
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        /// <summary>
        /// Tests the creation of a new monetary account. This accoult will then be removed afterwards.
        /// </summary>
        [Fact]
        public void TestCreationNewMonetaryAccount()
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FIELD_CURRENCY, CURRENCY},
                {MonetaryAccountBank.FIELD_DESCRIPTION, MONETARY_ACCOUNT_DESCRIPTION}
            };
            var monetaryAccountToCloseId = MonetaryAccountBank.Create(API_CONTEXT, requestMap, USER_ID).Value;

            DeleteMonetaryAccount(monetaryAccountToCloseId);
        }

        private static void DeleteMonetaryAccount(int idToClose)
        {
            var requestMap = new Dictionary<string, object>
            {
                {MonetaryAccountBank.FIELD_STATUS, STATUS},
                {MonetaryAccountBank.FIELD_SUB_STATUS, SUBS_STATUS},
                {MonetaryAccountBank.FIELD_REASON, REASON},
                {MonetaryAccountBank.FIELD_REASON_DESCRIPTION, REASON_DESCRIPTION}
            };
            MonetaryAccountBank.Update(API_CONTEXT, requestMap, USER_ID, idToClose);
        }
    }
}
