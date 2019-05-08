using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
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
        /// Card constants.
        /// </summary>
        private const string CardPinAssignmentTypePrimary = "PRIMARY";

        private const string PinCode = "4045";
        private const int NonnegativeIntegerMinimum = 0;
        private const int CardSecondLineLengthMaximum = 20;
        private const string CardTypeMaestro = "MAESTRO";

        /// <summary>
        /// Number constants.
        /// </summary>
        private const int BaseDecimal = 10;

        private const int NumberOne = 1;

        /// <summary>
        /// Tests ordering a new card and checks if the fields we have entered are indeed correct by.
        /// </summary>
        [Fact]
        public void TestOrderNewMaestroCard()
        {
            SetUpTestCase();

            var cardPinAssignment = new CardPinAssignment(
                CardPinAssignmentTypePrimary
            )
            {
                PinCode = PinCode,
                MonetaryAccountId = BunqContext.UserContext.PrimaryMonetaryAccountBank.Id
            };
            var allCardPinAssignments = new List<CardPinAssignment> {cardPinAssignment};
            var cardDebit = CardDebit.Create(
                GenerateRandomSecondLine(),
                GetAnAllowedName(),
                GetAlias(),
                CardTypeMaestro,
                allCardPinAssignments
            ).Value;

            Assert.True(cardDebit.Id != null);

            var cardFromCardEndpoint = Card.Get(cardDebit.Id.Value).Value;

            Assert.Equal(cardDebit.SecondLine, cardFromCardEndpoint.SecondLine);
            Assert.Equal(cardDebit.Created, cardFromCardEndpoint.Created);
            Assert.Equal(cardDebit.NameOnCard, cardFromCardEndpoint.NameOnCard);
        }

        private static string GetAnAllowedName()
        {
            return CardName.List().Value.First().PossibleCardNameArray.First();
        }

        private static string GenerateRandomSecondLine()
        {
            var random = new Random();

            return random.Next(
                NonnegativeIntegerMinimum,
                (int) Math.Pow(BaseDecimal, CardSecondLineLengthMaximum + NumberOne) - NumberOne
            ).ToString();
        }
    }
}