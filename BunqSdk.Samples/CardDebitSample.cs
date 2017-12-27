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
        private const string NameYourCompany = "USER_COMPANY_NAME"; // Put your user name here
        private const string PinCode = "0461";
        private const string PointerTypeEmail = "EMAIL";
        private const string EmailYourCompany = "at@at.at"; // Put your user email here
        private const string PointerNameTest = "test pointer";
        private const int UserItemId = 0; // Put your user ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var requestMap = new Dictionary<string, object>
            {
                {CardDebit.FieldNameOnCard, NameYourCompany},
                {CardDebit.FieldSecondLine, GenerateRandomSecondLine()},
                {CardDebit.FieldPinCode, PinCode},
                {
                    CardDebit.FieldAlias,
                    new Pointer(PointerTypeEmail, EmailYourCompany) {Name = PointerNameTest}
                },
            };

            Console.WriteLine(CardDebit.Create(apiContext, requestMap, UserItemId));
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(0, (int) Math.Pow(10, 21) - 1).ToString();
        }
    }
}
