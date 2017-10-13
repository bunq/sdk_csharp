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

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paginationCountOnly = new Pagination
            {
                Count = PAGE_SIZE,
            };

            var monetaryAccounts = MonetaryAccount.List(apiContext, USER_ITEM_ID).Value;

            foreach (var monetaryAccount in monetaryAccounts)
            {
                var acctBank = monetaryAccount.MonetaryAccountBank;

                if (!acctBank.Id.HasValue)
                {
                    continue;
                }

                var monetaryAccountId = acctBank.Id.Value;

                Console.WriteLine("Begin payment list dump for monetary account: " + monetaryAccountId);
                Console.WriteLine(MESSAGE_LATEST_PAGE_IDS);

                var paymentResponse = Payment.List(apiContext, USER_ITEM_ID, monetaryAccountId,
                    paginationCountOnly.UrlParamsCountOnly);
                PrintPayments(paymentResponse.Value);
                var pagination = paymentResponse.Pagination;

                if (pagination.HasPreviousPage())
                {
                    Console.WriteLine(MESSAGE_SECOND_LATEST_PAGE_IDS);
                    var previousPaymentResponse = Payment.List(apiContext, USER_ITEM_ID, monetaryAccountId,
                        pagination.UrlParamsPreviousPage);
                    PrintPayments(previousPaymentResponse.Value);
                }
                else
                {
                    Console.WriteLine(MESSAGE_NO_PRIOR_PAYMENTS_FOUND);
                }
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
