using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class MonetaryAccountSample : ISample
    {
        public void Run()
        {
            BunqContext.LoadApiContext(ApiContext.Restore());
            var monetaryAccount = BunqContext.UserContext.PrimaryMonetaryAccountBank;
            Console.WriteLine(monetaryAccount);
        }
    }
}
