using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;
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
        /// Constants for scenario testing.
        /// </summary>
        private const int PaymentListingPageSize = 2;
        private const int PaymentRequiredCountMinimum = PaymentListingPageSize * 2;
        private const int NumberZero = 0;

        [Fact]
        public void TestApiScenarioPaymentListingWithPagination()
        {
            SetUpTestCase();

            EnsureEnoughPayments();
            var paymentsExpected = new List<Payment>(GetPaymentsRequired());
            var paginationCountOnly = new Pagination
            {
                Count = PaymentListingPageSize
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
            for (var i = NumberZero; i < GetPaymentsMissingCount(); ++i)
            {
                CreatePayment();
            }
        }

        private static int GetPaymentsMissingCount()
        {
            return PaymentRequiredCountMinimum - GetPaymentsRequired().Count;
        }

        private static IList<Payment> GetPaymentsRequired()
        {
            var pagination = new Pagination
            {
                Count = PaymentRequiredCountMinimum
            };

            return ListPayments(pagination.UrlParamsCountOnly).Value;
        }

        private static BunqResponse<List<Payment>> ListPayments(IDictionary<string, string> urlParams)
        {
            return Payment.List(urlParams: urlParams);
        }

        private static void CreatePayment()
        {
            Payment.Create(new Amount(PaymentAmountEur, PaymentCurrency), GetPointerBravo(), PaymentDescription);
        }
    }
}
