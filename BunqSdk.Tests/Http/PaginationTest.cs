using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
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
        /// Config values.
        /// </summary>
        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly Pointer COUNTER_PARTY_OTHER = Config.GetCounterAliasOther();

        /// <summary>
        /// Values of pagination properties for testing.
        /// </summary>
        private const int PAGINATION_OLDER_ID_CUSTOM = 1;
        private const int PAGINATION_NEWER_ID_CUSTOM = 2;
        private const int PAGINATION_FUTURE_ID_CUSTOM = 3;
        private const int PAGINATION_COUNT_CUSTOM = 5;

        /// <summary>
        /// Constants for scenario testing.
        /// </summary>
        private const int PAYMENT_LISTING_PAGE_SIZE = 2;
        private const int PAYMENT_REQUIRED_COUNT_MINIMUM = PAYMENT_LISTING_PAGE_SIZE * 2;
        private const int NUMBER_ZERO = 0;

        /// <summary>
        /// Constants for payment creation.
        /// </summary>
        private const string AMOUNT_IN_EUR = "0.01";
        private const string FIELD_CURRENCY = "EUR";
        private const string FIELD_PAYMENT_DESCRIPTION = "C# test Payment";

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

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
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_OLDER_ID, PAGINATION_OLDER_ID_CUSTOM.ToString()}
            };

            Assert.Equal(urlParamsCountOnlyExpected, pagination.UrlParamsPreviousPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageNewer()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_NEWER_ID, PAGINATION_NEWER_ID_CUSTOM.ToString()}
            };

            Assert.Equal(urlParamsCountOnlyExpected, pagination.UrlParamsNextPage);
        }

        [Fact]
        public void TestGetUrlParamsNextPageFuture()
        {
            var pagination = CreatePaginationWithNoNextPageAssured();
            var urlParamsCountOnlyExpected = new Dictionary<string, string>
            {
                {Pagination.PARAM_COUNT, PAGINATION_COUNT_CUSTOM.ToString()},
                {Pagination.PARAM_NEWER_ID, PAGINATION_FUTURE_ID_CUSTOM.ToString()}
            };

            Assert.False(pagination.HasNextPageAssured());
            Assert.Equal(urlParamsCountOnlyExpected, pagination.UrlParamsNextPage);
        }

        private static Pagination CreatePaginationWithNoNextPageAssured()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.NewerId = null;

            return pagination;
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageFromPaginationWithNoPreviousPage()
        {
            var pagination = CreatePaginationWithNoPreviousPage();

            Assert.False(pagination.HasPreviousPage());
            Assert.Throws<BunqException>(() => pagination.UrlParamsPreviousPage);
        }

        private static Pagination CreatePaginationWithNoPreviousPage()
        {
            var pagination = CreatePaginationWithAllPropertiesSet();
            pagination.OlderId = null;

            return pagination;
        }

        [Fact]
        public void TestGetUrlParamsPreviousPageFromPaginationWithNoNextPage()
        {
            var pagination = CreatePaginationWithNoNextPage();

            Assert.Throws<BunqException>(() => pagination.UrlParamsNextPage);
        }

        private static Pagination CreatePaginationWithNoNextPage()
        {
            var pagination = CreatePaginationWithNoNextPageAssured();
            pagination.FutureId = null;

            return pagination;
        }

        [Fact]
        public void TestApiScenarioPaymentListingWithPagination()
        {
            EnsureEnoughPayments();
            var paymentsExpected = new HashSet<Payment>(GetPaymentsRequired());
            var paginationCountOnly = new Pagination
            {
                Count = PAYMENT_LISTING_PAGE_SIZE
            };

            var paymentResponseLatest = ListPayments(paginationCountOnly.UrlParamsCountOnly);
            var paginationLatest = paymentResponseLatest.Pagination;
            var paymentResponsePrevious = ListPayments(paginationLatest.UrlParamsPreviousPage);
            var paginationPrevious = paymentResponsePrevious.Pagination;
            var paymentResponsePreviousNext = ListPayments(paginationPrevious.UrlParamsNextPage);

            var paymentsActual = new HashSet<Payment>();
            paymentsActual.UnionWith(paymentResponsePreviousNext.Value);
            paymentsActual.UnionWith(paymentResponsePrevious.Value);
            var paymentsExpectedSerialized = BunqJsonConvert.SerializeObject(paymentsExpected);
            var paymentsActualSerialized = BunqJsonConvert.SerializeObject(paymentsActual);

            Assert.Equal(paymentsExpectedSerialized, paymentsActualSerialized);
        }

        private static void EnsureEnoughPayments()
        {
            for (var i = NUMBER_ZERO; i < GetPaymentsMissingCount(); ++i)
            {
                CreatePayment();
            }
        }

        private static int GetPaymentsMissingCount()
        {
            return PAYMENT_REQUIRED_COUNT_MINIMUM - GetPaymentsRequired().Count;
        }

        private static List<Payment> GetPaymentsRequired()
        {
            var pagination = new Pagination
            {
                Count = PAYMENT_REQUIRED_COUNT_MINIMUM
            };

            return ListPayments(pagination.UrlParamsCountOnly).Value;
        }

        private static BunqResponse<List<Payment>> ListPayments(IDictionary<string, string> urlParams)
        {
            return Payment.List(API_CONTEXT, USER_ID, MONETARY_ACCOUNT_ID, urlParams);
        }

        private static void CreatePayment()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FIELD_AMOUNT, new Amount(AMOUNT_IN_EUR, FIELD_CURRENCY)},
                {Payment.FIELD_DESCRIPTION, FIELD_PAYMENT_DESCRIPTION},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_OTHER}
            };

            Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);
        }
    }
}
