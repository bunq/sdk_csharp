using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     TabItemShop
    ///     TabUsageSingle
    /// </summary>
    public class TabUsageSingleTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values
        /// </summary>
        private const string TAB_DESCRIPTION = "Pay the tab for Java test please.";

        private const string STATUS_OPEN = "OPEN";
        private const string AMOUNT_EUR = "10.00";
        private const string FIELD_CURRENCY = "EUR";
        private const string TAB_ITEM_DESCRIPTION = "Super expensive java tea";
        private const string STATUS_WAITING = "WAITING_FOR_PAYMENT";

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly int CASH_REGISTER_ID = Config.GetCashRegisterId();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests opening a new tab, adding a tab item to it and update this tab to awaiting payment.
        /// This tab will be deleted after it has been updated.
        ///
        /// This test has no asserion as it is testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestCreateTabAndUpdate()
        {
            var tabUuid = CreateTabAndGetUuid();
            AddTabItem(tabUuid);

            TabUsageSingle.Update(CASH_REGISTER_ID, tabUuid, status: STATUS_WAITING);

            DeleteTab(tabUuid);
        }

        private static void DeleteTab(string tabUuid)
        {
            TabUsageSingle.Delete(CASH_REGISTER_ID, tabUuid);
        }

        private static string CreateTabAndGetUuid()
        {
            return TabUsageSingle.Create(CASH_REGISTER_ID, TAB_DESCRIPTION, STATUS_OPEN,
                new Amount(AMOUNT_EUR, FIELD_CURRENCY)).Value;
        }

        private static void AddTabItem(string tabUuid)
        {
            TabItemShop.Create(CASH_REGISTER_ID, tabUuid, TAB_ITEM_DESCRIPTION);
        }
    }
}