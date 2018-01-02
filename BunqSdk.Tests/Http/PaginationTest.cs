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
        private const int PaginationOlderIdCustom = 1;
        private const int PaginationNewerIdCustom = 2;
        private const int PaginationFutureIdCustom = 3;
        private const int PaginationCountCustom = 5;

        [Fact]
        public void TestGetUrlParamsCountOnly()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.ParamCount, PaginationCountCustom.ToString()}
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
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsPreviousPageExpected = new Dictionary<string, string>
            {
                {Pagination.ParamCount, PaginationCountCustom.ToString()},
                {Pagination.ParamOlderId, PaginationOlderIdCustom.ToString()}
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
                {Pagination.ParamOlderId, PaginationOlderIdCustom.ToString()}
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
                {Pagination.ParamCount, PaginationCountCustom.ToString()},
                {Pagination.ParamNewerId, PaginationNewerIdCustom.ToString()}
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
                {Pagination.ParamNewerId, PaginationNewerIdCustom.ToString()}
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
                {Pagination.ParamCount, PaginationCountCustom.ToString()},
                {Pagination.ParamNewerId, PaginationFutureIdCustom.ToString()}
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
                {Pagination.ParamCount, PaginationCountCustom.ToString()},
                {Pagination.ParamNewerId, PaginationFutureIdCustom.ToString()}
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
