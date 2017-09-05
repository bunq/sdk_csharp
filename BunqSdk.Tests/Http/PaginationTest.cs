using System.Collections.Generic;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Xunit;

namespace Bunq.Sdk.Tests.Http
{
    /// <summary>
    /// Tests:
    ///     Pagination
    /// </summary>
    public class PaginationTest
    {
        /// <summary>
        /// Values of pagination properties for testing.
        /// </summary>
        private const int PAGINATION_OLDER_ID_CUSTOM = 1;
        private const int PAGINATION_NEWER_ID_CUSTOM = 2;
        private const int PAGINATION_FUTURE_ID_CUSTOM = 3;
        private const int PAGINATION_COUNT_CUSTOM = 5;

        [Fact]
        public void TestGetUrlParamsCountOnly()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()}
            };

            Assert.Equal(urlParamsCountOnlyExpected, pagination.UrlParamsCountOnly);
        }

        private static Pagination CreatePaginationWithAllPropertiesSet()
        {
            return new Pagination
            {
                OlderId = PAGINATION_OLDER_ID_CUSTOM,
                NewerId = PAGINATION_NEWER_ID_CUSTOM,
                FutureId = PAGINATION_FUTURE_ID_CUSTOM,
                Count = PAGINATION_COUNT_CUSTOM
            };
        }

        [Fact]
        public void TestGetUrlParamsPreviousPage()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsPreviousPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_OLDER_ID, PAGINATION_OLDER_ID_CUSTOM.ToString()}
            };

            Assert.True(pagination.HasPreviousPage());
            Assert.Equal(urlParamsPreviousPageExpected, pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageNoCount()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.Count = null;
            var urlParamsPreviousPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_OLDER_ID, PAGINATION_OLDER_ID_CUSTOM.ToString()}
            };

            Assert.True(pagination.HasPreviousPage());
            Assert.Equal(urlParamsPreviousPageExpected, pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageNewer()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_NEWER_ID, PAGINATION_NEWER_ID_CUSTOM.ToString()}
            };

            Assert.True(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageNewerNoCount()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.Count = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_NEWER_ID, PAGINATION_NEWER_ID_CUSTOM.ToString()}
            };

            Assert.True(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFuture()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_NEWER_ID, PAGINATION_FUTURE_ID_CUSTOM.ToString()}
            };

            Assert.False(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFutureNoCount()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_NEWER_ID, PAGINATION_FUTURE_ID_CUSTOM.ToString()}
            };

            Assert.False(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageFromPaginationWithNoPreviousPage()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.OlderId = null;

            Assert.False(pagination.HasPreviousPage());
            Assert.Throws<BunqException>(() => pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFromPaginationWithNoNextPage()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            pagination.FutureId = null;

            Assert.Throws<BunqException>(() => pagination.UrlParamsNextPage);
        }
    }
}
