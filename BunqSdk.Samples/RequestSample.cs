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
        private const string STATUS_REVOKED = "REVOKED";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestId = RequestInquiry.Create(new Amount(REQUEST_AMOUNT, REQUEST_CURRENCY),
                new Pointer(COUNTERPARTY_POINTER_TYPE, COUNTERPARTY_EMAIL), REQUEST_DESCRIPTION, false).Value;
            
            Console.WriteLine(RequestInquiry.Get(requestId));

            var requestUpdateMap = new Dictionary<string, object> {{RequestInquiry.FIELD_STATUS, STATUS_REVOKED}};
            var requestUpdated = RequestInquiry.Update(requestId, status: STATUS_REVOKED);
            Console.WriteLine(requestUpdated);
        }
    }
}