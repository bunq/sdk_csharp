using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class MonetaryAccountSample : ISample
    {
        private const int UserItemId = 0; // Put your user ID here
        private const int MonetaryAccountItemId = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var monetaryAccount = MonetaryAccount.Get(apiContext, UserItemId, MonetaryAccountItemId).Value;
            Console.WriteLine(monetaryAccount.MonetaryAccountBank);
        }
    }
}
