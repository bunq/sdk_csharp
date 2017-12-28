using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentBatchSample : ISample
    {
        private const string ValueAmountEur = "0.01";
        private const string ValueCurrencyEur = "EUR";
        private const string CounterPartyPointerType = "EMAIL";
        private const string CounterPartyEmail = "bravo@bunq.com";
        private const string ValueDescription = "This is a generated payment batch!";
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here

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
                            {Payment.FIELD_AMOUNT, new Amount(ValueAmountEur, ValueCurrencyEur)},
                            {
                                Payment.FIELD_COUNTERPARTY_ALIAS,
                                new Pointer(CounterPartyPointerType, CounterPartyEmail)
                            },
                            {Payment.FIELD_DESCRIPTION, ValueDescription}
                        }
                    }
                }
            };

            var paymentBatchId = PaymentBatch.Create(apiContext, paymentBatchMap, UserItemId,
                MonetaryAccountItemId).Value;

            Console.WriteLine(PaymentBatch.Get(apiContext, UserItemId, MonetaryAccountItemId, paymentBatchId));
        }
    }
}
