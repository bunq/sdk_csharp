using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
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
            var allPayment = new List<Payment>();
            var payment = new Payment
            {
                Amount = new Amount(PAYMENT_AMOUNT, PAYMENT_CURRENCY),
                CounterpartyAlias =
                    new MonetaryAccountReference(new Pointer(COUNTERPARTY_POINTER_TYPE, COUNTERPARTY_EMAIL)),
                Description = PAYMENT_DESCRIPTION
            };

            var paymentBatchId = PaymentBatch.Create(allPayment).Value;

            Console.WriteLine(PaymentBatch.Get(paymentBatchId));
        }
    }
}
