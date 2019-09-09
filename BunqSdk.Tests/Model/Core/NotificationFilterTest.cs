using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Core
{
    /// <summary>
    /// Tests:
    ///     NotificationFilterUrlMonetaryAccountInternal
    ///     NotificationFilterUrlUserInternal
    ///     NotificationFilterPushUserInternal
    /// </summary>
    public class NotificationFilterTest: BunqSdkTestBase, IClassFixture<NotificationFilterTest>
    {
        /// <summary>
        /// Filter constants.
        /// </summary>
        private const string FILTER_CATEGORY_MUTATION = "MUTATION";
        private const string FILTER_CALLBACK_URL = "https://test.com/callback";

        /// <summary>
        /// Test NotificationFilterUrlMonetaryAccount creation.
        /// </summary>
        [Fact]
        public void TestNotificationFilterUrlMonetaryAccount()
        {
            SetUpApiContext();
            
            NotificationFilterUrl notificationFilter = GetNotificationFilterUrl();
            List<NotificationFilterUrl> allCreatedNotificationFilter = NotificationFilterUrlMonetaryAccountInternal.CreateWithListResponse(
                GetPrimaryMonetaryAccount().Id.Value,
                new List<NotificationFilterUrl>() {notificationFilter}
            ).Value;

            Assert.True(allCreatedNotificationFilter.Count == 1);
        }

        /// <summary>
        /// Test NotificationFilterUrlUser creation.
        /// </summary>
        [Fact]
        public void TestNotificationFilterUrlUser()
        {
            SetUpApiContext();

            NotificationFilterUrl notificationFilter = GetNotificationFilterUrl();
            List<NotificationFilterUrl> allCreatedNotificationFilter = NotificationFilterUrlUserInternal.CreateWithListResponse(
                new List<NotificationFilterUrl>() {notificationFilter}
            ).Value;

            Assert.True(allCreatedNotificationFilter.Count == 1);
        }
        /// <summary>
        /// Test NotificationFilterPushUser creation.
        /// </summary>
        [Fact]
        public void TestNotificationFilterPushUser()
        {
            SetUpApiContext();

            NotificationFilterPush notificationFilter = GetNotificationFilterPush();
            List<NotificationFilterPush> allCreatedNotificationFilter = NotificationFilterPushUserInternal.CreateWithListResponse(
                new List<NotificationFilterPush>() {notificationFilter}
            ).Value;

            Assert.True(allCreatedNotificationFilter.Count == 1);
        }

        /// <summary>
        /// Test clear all filters.
        /// </summary>
        [Fact]
        public void TestNotificationFilterClear()
        {
            SetUpApiContext();

            List<NotificationFilterPush> allCreatedNotificationFilterPushUser =
                    NotificationFilterPushUserInternal.CreateWithListResponse().Value;
            List<NotificationFilterUrl> allCreatedNotificationFilterUrlUser =
                NotificationFilterUrlUserInternal.CreateWithListResponse().Value;
            List<NotificationFilterUrl> allCreatedNotificationFilterUrlMonetaryAccount =
                    NotificationFilterUrlMonetaryAccountInternal.CreateWithListResponse().Value;
            
            Assert.Empty(allCreatedNotificationFilterPushUser);
            Assert.Empty(allCreatedNotificationFilterUrlUser);
            Assert.Empty(allCreatedNotificationFilterUrlMonetaryAccount);

            Assert.StrictEqual(0, NotificationFilterPushUserInternal.List().Value.Count);
            Assert.StrictEqual(0, NotificationFilterUrlUserInternal.List().Value.Count);
            Assert.StrictEqual(0, NotificationFilterUrlMonetaryAccountInternal.List().Value.Count);
        }
        
        private NotificationFilterUrl GetNotificationFilterUrl()
        {
            return new NotificationFilterUrl(FILTER_CATEGORY_MUTATION, FILTER_CALLBACK_URL);
        }
        
        private NotificationFilterPush GetNotificationFilterPush()
        {
            return new NotificationFilterPush(FILTER_CATEGORY_MUTATION);
        }
        
        private MonetaryAccountBank GetPrimaryMonetaryAccount()
        {
            return BunqContext.UserContext.PrimaryMonetaryAccountBank;
        }
    }
}