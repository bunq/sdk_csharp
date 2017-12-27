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
        private const string TAB_FIELD_DESCRIPTION = "Pay the tab for Java test please.";
        private const string FIELD_STATUS_OPEN = "OPEN";
        private const string AMOUNT_EUR = "10.00";
        private const string FIELD_CURRENCY = "EUR";
        private const string TAB_ITEM_FIELD_DESCRIPTION = "Super expensive java tea";
        private const string FIELD_STATUS_WAITING = "WAITING_FOR_PAYMENT";

        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly int CASH_REGISTER_ID = Config.GetCashRegisterId();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

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

            var updateTabMap = new Dictionary<string, object>
            {
                {TabUsageSingle.FIELD_STATUS, FIELD_STATUS_WAITING}
            };
            TabUsageSingle.Update(API_CONTEXT, updateTabMap, USER_ID, MONETARY_ACCOUNT_ID, CASH_REGISTER_ID, tabUuid);

            DeleteTab(tabUuid);
        }

        private static void DeleteTab(string tabId)
        {
            TabUsageSingle.Delete(API_CONTEXT, USER_ID, MONETARY_ACCOUNT_ID, CASH_REGISTER_ID, tabId);
        }

        private static string CreateTabAndGetUuid()
        {
            var createTabMap = new Dictionary<string, object>
            {
                {TabUsageSingle.FIELD_DESCRIPTION, TAB_FIELD_DESCRIPTION},
                {TabUsageSingle.FIELD_STATUS, FIELD_STATUS_OPEN},
                {TabUsageSingle.FIELD_AMOUNT_TOTAL, new Amount(AMOUNT_EUR, FIELD_CURRENCY)}
            };

            return TabUsageSingle.Create(API_CONTEXT, createTabMap, USER_ID, MONETARY_ACCOUNT_ID,
                CASH_REGISTER_ID).Value;
        }

        private static void AddTabItem(string tabUuid)
        {
            var tabItemMap = new Dictionary<string, object>
            {
                {TabItemShop.FIELD_AMOUNT, new Amount(AMOUNT_EUR, FIELD_CURRENCY)},
                {TabItemShop.FIELD_DESCRIPTION, TAB_ITEM_FIELD_DESCRIPTION}
            };
            TabItemShop.Create(API_CONTEXT, tabItemMap, USER_ID, MONETARY_ACCOUNT_ID, CASH_REGISTER_ID, tabUuid);
        }
    }
}
