using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class CardDebitSample : ISample
    {
        private const string NAME_YOUR_COMPANY = "USER_COMPANY_NAME"; // Put your user name here
        private const string PIN_CODE = "0461";
        private const string POINTER_TYPE_EMAIL = "EMAIL";
        private const string EMAIL_YOUR_COMPANY = "at@at.at"; // Put your user email here
        private const string POINTER_NAME_TEST = "test pointer";
        private const int USER_ITEM_ID = 0; // Put your user ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestMap = new Dictionary<string, object>
            {
                {CardDebit.FIELD_NAME_ON_CARD, NAME_YOUR_COMPANY},
                {CardDebit.FIELD_SECOND_LINE, GenerateRandomSecondLine()},
                {CardDebit.FIELD_PIN_CODE, PIN_CODE},
                {
                    CardDebit.FIELD_ALIAS,
                    new Pointer(POINTER_TYPE_EMAIL, EMAIL_YOUR_COMPANY) {Name = POINTER_NAME_TEST}
                },
            };

            Console.WriteLine(CardDebit.Create(apiContext, requestMap, USER_ITEM_ID));
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(0, (int) Math.Pow(10, 21) - 1).ToString();
        }
    }
}
