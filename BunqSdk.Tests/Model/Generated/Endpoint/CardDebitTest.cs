using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const string CARD_PIN_ASSIGNMENT_TYPE_PRIMARY = "PRIMARY";

        private const string PIN_CODE = "4045";
        private const int INDEX_FIRST = 0;
        private const int NONNEGATIVE_INTEGER_MINIMUM = 0;
        private const int BASE_DECIMAL = 10;
        private const int CARD_SECOND_LINE_LENGTH_MAXIMUM = 20;
        private const int NUMBER_ONE = 1;
        private const string CardTypeMaestro = "MAESTRO";

        private static readonly int USER_ID = Config.GetUserId();

        /// <summary>
        /// API context used to for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = SetUpApiContext();

        /// <summary>
        /// Tests ordering a new card and checks if the fields we have entered are indeed correct by.
        /// </summary>
        [Fact]
        public void TestOrderNewMaestroCard()
        {
            var cardPinAssignment = new CardPinAssignment(
                CARD_PIN_ASSIGNMENT_TYPE_PRIMARY,
                PIN_CODE,
                Config.GetMonetarytAccountId());
            var allCardPinAssignments = new List<CardPinAssignment> {cardPinAssignment};
            var cardDebit = CardDebit.Create(GenerateRandomSecondLine(), GetAnAllowedName(), GetAlias(), CardTypeMaestro,
                allCardPinAssignments).Value;

            Assert.True(cardDebit.Id != null);
            
            var cardFromCardEndpoint = Card.Get(cardDebit.Id.Value).Value;

            Assert.Equal(cardDebit.SecondLine, cardFromCardEndpoint.SecondLine);
            Assert.Equal(cardDebit.Created, cardFromCardEndpoint.Created);
            Assert.Equal(cardDebit.NameOnCard, cardFromCardEndpoint.NameOnCard);
        }

        private static string GetAnAllowedName()
        {
            return CardName.List().Value[INDEX_FIRST].PossibleCardNameArray[INDEX_FIRST];
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(
                NONNEGATIVE_INTEGER_MINIMUM,
                (int) Math.Pow(BASE_DECIMAL, CARD_SECOND_LINE_LENGTH_MAXIMUM + NUMBER_ONE) - NUMBER_ONE
            ).ToString();
        }

        private static Pointer GetAlias()
        {
            return User.Get().Value.UserCompany.Alias[INDEX_FIRST];
        }
    }
}