using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentListSample : ISample
    {
        /// <summary>
        /// Message constants.
        /// </summary>
        private const string MessageLatestPageIds = "Latest page IDs: ";
        private const string MessageSecondLatestPageIds = "Second latest page IDs: ";
        private const string MessageNoPriorPaymentsFound = "No prior payments found!";

        /// <summary>
        /// Size of each page of payment listing.
        /// </summary>
        private const int PageSize = 3;

        /// <summary>
        /// Constants to be changed to run the example.
        /// </summary>
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paginationCountOnly = new Pagination
            {
                Count = PageSize,
            };
            Console.WriteLine(MessageLatestPageIds);
            var paymentResponse = Payment.List(apiContext, UserItemId, MonetaryAccountItemId,
                paginationCountOnly.UrlParamsCountOnly);
            PrintPayments(paymentResponse.Value);
            var pagination = paymentResponse.Pagination;

            if (pagination.HasPreviousPage())
            {
                Console.WriteLine(MessageSecondLatestPageIds);
                var previousPaymentResponse = Payment.List(apiContext, UserItemId, MonetaryAccountItemId,
                    pagination.UrlParamsPreviousPage);
                PrintPayments(previousPaymentResponse.Value);
            }
            else
            {
                Console.WriteLine(MessageNoPriorPaymentsFound);
            }
        }

        private static void PrintPayments(IEnumerable<Payment> payments)
        {
            foreach (var payment in payments)
            {
                Console.WriteLine(payment.Id);
            }
        }
    }
}
