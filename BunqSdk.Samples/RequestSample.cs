using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class RequestSample : ISample
    {
        private const string ValueAmountEur = "12.30";
        private const string ValueCurrencyEur = "EUR";
        private const string CounterPartyPointerType = "EMAIL";
        private const string CounterPartyEmail = "bravo@bunq.com";
        private const string ValueDescription = "This is a generated request!";
        private const string ValueStatusRevoked = "REVOKED";
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestMap = new Dictionary<string, object>
            {
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(ValueAmountEur, ValueCurrencyEur)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, new Pointer(CounterPartyPointerType, CounterPartyEmail)},
                {RequestInquiry.FIELD_DESCRIPTION, ValueDescription},
                {RequestInquiry.FIELD_ALLOW_BUNQME, true}
            };
            var requestId = RequestInquiry.Create(apiContext, requestMap, UserItemId, MonetaryAccountItemId).Value;
            Console.WriteLine(RequestInquiry.Get(apiContext, UserItemId, MonetaryAccountItemId, requestId));

            var requestUpdateMap = new Dictionary<string, object> {{RequestInquiry.FIELD_STATUS, ValueStatusRevoked}};
            var requestUpdated = RequestInquiry.Update(apiContext, requestUpdateMap, UserItemId,
                MonetaryAccountItemId, requestId);
            Console.WriteLine(requestUpdated);
        }
    }
}
