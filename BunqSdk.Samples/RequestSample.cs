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
        private const string REQUEST_AMOUNT = "12.30";
        private const string REQUEST_CURRENCY = "EUR";
        private const string COUNTERPARTY_POINTER_TYPE = "EMAIL";
        private const string COUNTERPARTY_EMAIL = "bravo@bunq.com";
        private const string REQUEST_DESCRIPTION = "This is a generated request!";
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ITEM_ID = 0; // Put your monetary account ID here
        private const string STATUS_REVOKED = "REVOKED";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestMap = new Dictionary<string, object>
            {
                {RequestInquiry.FIELD_AMOUNT_INQUIRED, new Amount(REQUEST_AMOUNT, REQUEST_CURRENCY)},
                {RequestInquiry.FIELD_COUNTERPARTY_ALIAS, new Pointer(COUNTERPARTY_POINTER_TYPE, COUNTERPARTY_EMAIL)},
                {RequestInquiry.FIELD_DESCRIPTION, REQUEST_DESCRIPTION},
                {RequestInquiry.FIELD_ALLOW_BUNQME, true}
            };
            var requestId = RequestInquiry.Create(apiContext, requestMap, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID).Value;
            Console.WriteLine(RequestInquiry.Get(apiContext, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID, requestId));

            var requestUpdateMap = new Dictionary<string, object> {{RequestInquiry.FIELD_STATUS, STATUS_REVOKED}};
            var requestUpdated = RequestInquiry.Update(apiContext, requestUpdateMap, USER_ITEM_ID,
                MONETARY_ACCOUNT_ITEM_ID, requestId);
            Console.WriteLine(requestUpdated);
        }
    }
}
