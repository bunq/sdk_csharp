using System.Collections.Generic;
using Bunq.Sdk.Context;
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
    public class PaginationScenarioTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private static readonly int USER_ID = Config.GetUserId();
        private static readonly int MONETARY_ACCOUNT_ID = Config.GetMonetarytAccountId();
        private static readonly Pointer COUNTER_PARTY_OTHER = Config.GetCounterPartyAliasOther();

        /// <summary>
        /// Constants for scenario testing.
        /// </summary>
        private const int PAYMENT_LISTING_PAGE_SIZE = 2;
        private const int PAYMENT_REQUIRED_COUNT_MINIMUM = PAYMENT_LISTING_PAGE_SIZE * 2;
        private const int NUMBER_ZERO = 0;

        /// <summary>
        /// Constants for payment creation.
        /// </summary>
        private const string AMOUNT_EUR = "0.01";
        private const string CURRENCY = "EUR";
        private const string PAYMENT_DESCRIPTION = "C# test Payment";

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        [Fact]
        public void TestApiScenarioPaymentListingWithPagination()
        {
            EnsureEnoughPayments();
            var paymentsExpected = new List<Payment>(GetPaymentsRequired());
            var paginationCountOnly = new Pagination
            {
                Count = PAYMENT_LISTING_PAGE_SIZE
            };

            var responseLatest = ListPayments(paginationCountOnly.UrlParamsCountOnly);
            var paginationLatest = responseLatest.Pagination;
            var responsePrevious = ListPayments(paginationLatest.UrlParamsPreviousPage);
            var paginationPrevious = responsePrevious.Pagination;
            var responsePreviousNext = ListPayments(paginationPrevious.UrlParamsNextPage);

            var paymentsActual = new List<Payment>();
            paymentsActual.AddRange(responsePreviousNext.Value);
            paymentsActual.AddRange(responsePrevious.Value);
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

        private static IList<Payment> GetPaymentsRequired()
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
                {Payment.FIELD_AMOUNT, new Amount(AMOUNT_EUR, CURRENCY)},
                {Payment.FIELD_DESCRIPTION, PAYMENT_DESCRIPTION},
                {Payment.FIELD_COUNTERPARTY_ALIAS, COUNTER_PARTY_OTHER}
            };

            Payment.Create(API_CONTEXT, requestMap, USER_ID, MONETARY_ACCOUNT_ID);
        }
    }
}
