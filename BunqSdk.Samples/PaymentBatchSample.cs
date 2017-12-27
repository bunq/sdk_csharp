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
        private const string PaymentAmount = "0.01";
        private const string PaymentCurrency = "EUR";
        private const string CounterpartyPointerType = "EMAIL";
        private const string CounterpartyEmail = "bravo@bunq.com";
        private const string PaymentDescription = "This is a generated payment batch!";
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paymentBatchMap = new Dictionary<string, object>
            {
                {
                    PaymentBatch.FieldPayments,
                    new List<object>
                    {
                        new Dictionary<string, object>
                        {
                            {Payment.FieldAmount, new Amount(PaymentAmount, PaymentCurrency)},
                            {
                                Payment.FieldCounterpartyAlias,
                                new Pointer(CounterpartyPointerType, CounterpartyEmail)
                            },
                            {Payment.FieldDescription, PaymentDescription}
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
