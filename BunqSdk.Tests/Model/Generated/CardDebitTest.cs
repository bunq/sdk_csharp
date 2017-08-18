using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated
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
        private const string PIN_CODE = "4045";
        private const int INDEX_FIRST = 0;
        private const int NONNEGATIVE_INTEGER_MINIMUM = 0;
        private const int BASE_DECIMAL = 10;
        private const int CARD_SECOND_LINE_LENGTH_MAXIMUM = 20;
        private const int NUMBER_ONE = 1;

        private static readonly int USER_ID = Config.GetUserId();

        /// <summary>
        /// API context used to for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

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
                {CardDebit.FIELD_PIN_CODE, PIN_CODE},
                {CardDebit.FIELD_SECOND_LINE, GenerateRandomSecondLine()}
            };
            var cardDebit = CardDebit.Create(API_CONTEXT, cardDebitMap, USER_ID).Value;

            var cardFromCardEndpoint = Card.Get(API_CONTEXT, USER_ID, cardDebit.Id.Value).Value;

            Assert.Equal(cardDebit.SecondLine, cardFromCardEndpoint.SecondLine);
            Assert.Equal(cardDebit.Created, cardFromCardEndpoint.Created);
            Assert.Equal(cardDebit.NameOnCard, cardFromCardEndpoint.NameOnCard);
        }

        private static string GetAnAllowedName()
        {
            return CardName.List(API_CONTEXT, USER_ID).Value[INDEX_FIRST].PossibleCardNameArray[INDEX_FIRST];
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
            return User.Get(API_CONTEXT, USER_ID).Value.UserCompany.Alias[INDEX_FIRST];
        }
    }
}
