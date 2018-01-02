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
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here
        private const string ValueAmountEur = "0.01";
        private const string ValueCurrencyEur = "EUR";
        private const string CounterPartyPointerType = "EMAIL";
        private const string CounterPartyEmail = "bravo@bunq.com";
        private const string ValueDescription = "This is a generated payment!";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paymentMap = new Dictionary<string, object>
            {
                {Payment.FIELD_AMOUNT, new Amount(ValueAmountEur, ValueCurrencyEur)},
                {
                    Payment.FIELD_COUNTERPARTY_ALIAS,
                    new Pointer(CounterPartyPointerType, CounterPartyEmail)
                },
                {Payment.FIELD_DESCRIPTION, ValueDescription}
            };

            var paymentId = Payment.Create(apiContext, paymentMap, UserItemId, MonetaryAccountItemId).Value;

            Console.WriteLine(Payment.Get(apiContext, UserItemId, MonetaryAccountItemId, paymentId));
            
            // Save the API context to account for all the changes that might have occurred to it
            // during the sample execution
            apiContext.Save();
        }
    }
}
