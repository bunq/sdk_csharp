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
    public class PaginationTest : BunqSdkTestBase
    {
        /// <summary>
        /// Values of pagination properties for testing.
        /// </summary>
        private const int PaginationOlderIdCustom = 1;
        private const int PaginationNewerIdCustom = 2;
        private const int PaginationFutureIdCustom = 3;
        private const int PaginationCountCustom = 5;

        [Fact]
        public void TestGetUrlParamsCountOnly()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PaginationCountCustom.ToString()}
            };

            Assert.Equal(urlParamsCountOnlyExpected, pagination.UrlParamsCountOnly);
        }

        private static Pagination CreatePaginationWithAllPropertiesSet()
        {
            return new Pagination
            {
                OlderId = PaginationOlderIdCustom,
                NewerId = PaginationNewerIdCustom,
                FutureId = PaginationFutureIdCustom,
                Count = PaginationCountCustom
            };
        }

        [Fact]
        public void TestGetUrlParamsPreviousPage()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsPreviousPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PaginationCountCustom.ToString()},
                {Pagination.PARAM_OLDER_ID, PaginationOlderIdCustom.ToString()}
            };

            Assert.True(pagination.HasPreviousPage());
            Assert.Equal(urlParamsPreviousPageExpected, pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageNoCount()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.Count = null;
            var urlParamsPreviousPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_OLDER_ID, PaginationOlderIdCustom.ToString()}
            };

            Assert.True(pagination.HasPreviousPage());
            Assert.Equal(urlParamsPreviousPageExpected, pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageNewer()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PaginationCountCustom.ToString()},
                {Pagination.PARAM_NEWER_ID, PaginationNewerIdCustom.ToString()}
            };

            Assert.True(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageNewerNoCount()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.Count = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_NEWER_ID, PaginationNewerIdCustom.ToString()}
            };

            Assert.True(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFuture()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PaginationCountCustom.ToString()},
                {Pagination.PARAM_NEWER_ID, PaginationFutureIdCustom.ToString()}
            };

            Assert.False(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFutureNoCount()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            var urlParamsNextPageExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PaginationCountCustom.ToString()},
                {Pagination.PARAM_NEWER_ID, PaginationFutureIdCustom.ToString()}
            };

            Assert.False(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsNextPageExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageFromPaginationWithNoPreviousPage()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.OlderId = null;

            Assert.False(pagination.HasPreviousPage());
            Assert.Throws<BunqException>(() => pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFromPaginationWithNoNextPage()
        {
            SetUpTestCase();

            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;
            pagination.FutureId = null;

            Assert.Throws<BunqException>(() => pagination.UrlParamsNextPage);
        }
    }
}
