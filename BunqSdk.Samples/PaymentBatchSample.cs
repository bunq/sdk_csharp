using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentBatchSample : ISample
    {
        private const string PAYMENT_AMOUNT = "0.01";
        private const string PAYMENT_CURRENCY = "EUR";
        private const string COUNTERPARTY_POINTER_TYPE = "EMAIL";
        private const string COUNTERPARTY_EMAIL = "bravo@bunq.com";
        private const string PAYMENT_DESCRIPTION = "This is a generated payment batch!";
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ITEM_ID = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paymentBatchMap = new Dictionary<string, object>
            {
                {
                    PaymentBatch.FIELD_PAYMENTS,
                    new List<object>
                    {
                        new Dictionary<string, object>
                        {
                            {Payment.FIELD_AMOUNT, new Amount(PAYMENT_AMOUNT, PAYMENT_CURRENCY)},
                            {
                                Payment.FIELD_COUNTERPARTY_ALIAS,
                                new Pointer(COUNTERPARTY_POINTER_TYPE, COUNTERPARTY_EMAIL)
                            },
                            {Payment.FIELD_DESCRIPTION, PAYMENT_DESCRIPTION}
                        }
                    }
                }
            };

            var paymentBatchId = PaymentBatch.Create(apiContext, paymentBatchMap, USER_ITEM_ID,
                MONETARY_ACCOUNT_ITEM_ID).Value;

            Console.WriteLine(PaymentBatch.Get(apiContext, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID, paymentBatchId));
        }
    }
}
