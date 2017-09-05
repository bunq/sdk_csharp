using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentListSample : ISample
    {
        /// <summary>
        /// Message constants.
        /// </summary>
        private const string MESSAGE_LATEST_PAGE_IDS = "Latest page IDs: ";
        private const string MESSAGE_SECOND_LATEST_PAGE_IDS = "Second latest page IDs: ";
        private const string MESSAGE_NO_PRIOR_PAYMENTS_FOUND = "No prior payments found!";

        /// <summary>
        /// Size of each page of payment listing.
        /// </summary>
        private const int PAGE_SIZE = 3;

        /// <summary>
        /// Constants to be changed to run the example.
        /// </summary>
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ITEM_ID = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paginationCountOnly = new Pagination
            {
                Count = PAGE_SIZE,
            };
            Console.WriteLine(MESSAGE_LATEST_PAGE_IDS);
            var paymentResponse = Payment.List(apiContext, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID,
                paginationCountOnly.UrlParamsCountOnly);
            PrintPayments(paymentResponse.Value);
            var pagination = paymentResponse.Pagination;

            if (pagination.HasPreviousPage())
            {
                Console.WriteLine(MESSAGE_SECOND_LATEST_PAGE_IDS);
                var previousPaymentResponse = Payment.List(apiContext, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID,
                    pagination.UrlParamsPreviousPage);
                PrintPayments(previousPaymentResponse.Value);
            }
            else
            {
                Console.WriteLine(MESSAGE_NO_PRIOR_PAYMENTS_FOUND);
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
