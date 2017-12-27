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
        private const string TabFieldDescription = "Pay the tab for Java test please.";
        private const string FieldStatusOpen = "OPEN";
        private const string AmountEur = "10.00";
        private const string FieldCurrency = "EUR";
        private const string TabItemFieldDescription = "Super expensive java tea";
        private const string FieldStatusWaiting = "WAITING_FOR_PAYMENT";

        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly int CashRegisterId = Config.GetCashRegisterId();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

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
                {TabUsageSingle.FieldStatus, FieldStatusWaiting}
            };
            TabUsageSingle.Update(ApiContext, updateTabMap, UserId, MonetaryAccountId, CashRegisterId, tabUuid);

            DeleteTab(tabUuid);
        }

        private static void DeleteTab(string tabId)
        {
            TabUsageSingle.Delete(ApiContext, UserId, MonetaryAccountId, CashRegisterId, tabId);
        }

        private static string CreateTabAndGetUuid()
        {
            var createTabMap = new Dictionary<string, object>
            {
                {TabUsageSingle.FieldDescription, TabFieldDescription},
                {TabUsageSingle.FieldStatus, FieldStatusOpen},
                {TabUsageSingle.FieldAmountTotal, new Amount(AmountEur, FieldCurrency)}
            };

            return TabUsageSingle.Create(ApiContext, createTabMap, UserId, MonetaryAccountId,
                CashRegisterId).Value;
        }

        private static void AddTabItem(string tabUuid)
        {
            var tabItemMap = new Dictionary<string, object>
            {
                {TabItemShop.FieldAmount, new Amount(AmountEur, FieldCurrency)},
                {TabItemShop.FieldDescription, TabItemFieldDescription}
            };
            TabItemShop.Create(ApiContext, tabItemMap, UserId, MonetaryAccountId, CashRegisterId, tabUuid);
        }
    }
}
