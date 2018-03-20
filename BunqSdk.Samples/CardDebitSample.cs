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
        private const string CARD_PIN_ASSIGNMENT_TYPE_PRIMARY = "PRIMARY";
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ID = 0; // Put your monetaryAccount ID here

        public void Run()
        {
            BunqContext.LoadApiContext(ApiContext.Restore());
            var cardPinAssignment = new CardPinAssignment(
                CARD_PIN_ASSIGNMENT_TYPE_PRIMARY,
                PIN_CODE,
                MONETARY_ACCOUNT_ID
            );
            var allCardPinAssignments = new List<CardPinAssignment> {cardPinAssignment};

            Console.WriteLine(CardDebit.Create(GenerateRandomSecondLine(), NAME_YOUR_COMPANY,
                new Pointer(POINTER_TYPE_EMAIL, EMAIL_YOUR_COMPANY) {Name = POINTER_NAME_TEST},
                pinCodeAssignment: allCardPinAssignments));
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(0, (int) Math.Pow(10, 21) - 1).ToString();
        }
    }
}