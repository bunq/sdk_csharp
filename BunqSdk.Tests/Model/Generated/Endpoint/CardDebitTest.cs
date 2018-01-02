using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     CardDebit
    ///     CardName
    /// </summary>
    public class CardDebitTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private static readonly int UserId = Config.GetUserId();
        
        /// <summary>
        /// CardeDebit field value constatns.
        /// </summary>
        private const string CardDebitPinCode = "4045";
        private const int CardDebitSecondLineLengthMaximum = 20;
        
        /// <summary>
        /// The index of the first item in an array.
        /// </summary>
        private const int IndexFirst = 0;

        /// <summary>
        /// Number constatns.
        /// </summary>
        private const int NumberOne = 1;
        private const int NonNegativeIntegerMinimum = 0;
        private const int BaseDecimal = 10;
        
        /// <summary>
        /// API context used to for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests ordering a new card and checks if the fields we have entered are indeed correct by.
        /// </summary>
        [Fact]
        public void TestOrderNewMaestroCard()
        {
            var cardDebitMap = new Dictionary<string, object>
            {
                {CardDebit.FIELD_ALIAS, GetAlias()},
                {CardDebit.FIELD_NAME_ON_CARD, GetAnAllowedName()},
                {CardDebit.FIELD_PIN_CODE, CardDebitPinCode},
                {CardDebit.FIELD_SECOND_LINE, GenerateRandomSecondLine()}
            };
            var cardDebit = CardDebit.Create(ApiContext, cardDebitMap, UserId).Value;

            var cardFromCardEndpoint = Card.Get(ApiContext, UserId, cardDebit.Id.Value).Value;

            Assert.Equal(cardDebit.SecondLine, cardFromCardEndpoint.SecondLine);
            Assert.Equal(cardDebit.Created, cardFromCardEndpoint.Created);
            Assert.Equal(cardDebit.NameOnCard, cardFromCardEndpoint.NameOnCard);
        }

        private static string GetAnAllowedName()
        {
            return CardName.List(ApiContext, UserId).Value[IndexFirst].PossibleCardNameArray[IndexFirst];
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(
                NonNegativeIntegerMinimum,
                (int) Math.Pow(BaseDecimal, CardDebitSecondLineLengthMaximum + NumberOne) - NumberOne
            ).ToString();
        }

        private static Pointer GetAlias()
        {
            return User.Get(ApiContext, UserId).Value.UserCompany.Alias[IndexFirst];
        }
    }
}
