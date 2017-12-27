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
        private const string RequestAmount = "12.30";
        private const string RequestCurrency = "EUR";
        private const string CounterpartyPointerType = "EMAIL";
        private const string CounterpartyEmail = "bravo@bunq.com";
        private const string RequestDescription = "This is a generated request!";
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here
        private const string StatusRevoked = "REVOKED";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestMap = new Dictionary<string, object>
            {
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(RequestAmount, RequestCurrency)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, new Pointer(CounterpartyPointerType, CounterpartyEmail)},
                {RequestInquiry.FIELD_DESCRIPTION, RequestDescription},
                {RequestInquiry.FIELD_ALLOW_BUNQME, true}
            };
            var requestId = RequestInquiry.Create(apiContext, requestMap, UserItemId, MonetaryAccountItemId).Value;
            Console.WriteLine(RequestInquiry.Get(apiContext, UserItemId, MonetaryAccountItemId, requestId));

            var requestUpdateMap = new Dictionary<string, object> {{RequestInquiry.FIELD_STATUS, StatusRevoked}};
            var requestUpdated = RequestInquiry.Update(apiContext, requestUpdateMap, UserItemId,
                MonetaryAccountItemId, requestId);
            Console.WriteLine(requestUpdated);
        }
    }
}
