using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentSample : ISample
    {
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ITEM_ID = 0; // Put your monetary account ID here
        private const string PAYMENT_AMOUNT = "0.01";
        private const string PAYMENT_CURRENCY = "EUR";
        private const string COUNTERPARTY_POINTER_TYPE = "EMAIL";
        private const string COUNTERPARTY_EMAIL = "bravo@bunq.com";
        private const string PAYMENT_DESCRIPTION = "This is a generated payment!";

        public void Run()
        {
            BunqContext.LoadApiContext(ApiContext.Restore());
            var paymentId = Payment.Create(new Amount(PAYMENT_AMOUNT, PAYMENT_CURRENCY),
                new Pointer(COUNTERPARTY_POINTER_TYPE, COUNTERPARTY_EMAIL), PAYMENT_DESCRIPTION).Value;

            Console.WriteLine(Payment.Get(paymentId));

            // Save the API context to account for all the changes that might have occurred to it
            // during the sample execution
            BunqContext.ApiContext.Save();
        }
    }
}