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
        /// Config values.
        /// </summary>
        private static readonly int UserId = Config.GetUserId();
        private static readonly int MonetaryAccountId = Config.GetMonetarytAccountId();
        private static readonly Pointer CounterPartyOther = Config.GetCounterPartyAliasOther();

        /// <summary>
        /// Constants for scenario testing.
        /// </summary>
        private const int PaymentListingPageSize = 2;
        private const int PaymentRequiredCountMinimum = PaymentListingPageSize * 2;
        private const int NumberZero = 0;

        /// <summary>
        /// Constants for payment creation.
        /// </summary>
        private const string PaymentAmountEur = "0.01";
        private const string PaymentCurrencyEur = "EUR";
        private const string PaymentDescription = "C# test Payment";

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        [Fact]
        public void TestApiScenarioPaymentListingWithPagination()
        {
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
            return Payment.List(ApiContext, UserId, MonetaryAccountId, urlParams);
        }

        private static void CreatePayment()
        {
            var requestMap = new Dictionary<string, object>
            {
                {Payment.FIELD_AMOUNT, new Amount(PaymentAmountEur, PaymentCurrencyEur)},
                {Payment.FIELD_DESCRIPTION, PaymentDescription},
                {Payment.FIELD_COUNTERPARTY_ALIAS, CounterPartyOther}
            };

            Payment.Create(ApiContext, requestMap, UserId, MonetaryAccountId);
        }
    }
}
