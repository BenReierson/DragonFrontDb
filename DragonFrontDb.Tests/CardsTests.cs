using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFrontDb.Tests
{
    [TestClass]
    public class CardsTests
    {
        [TestMethod]
        public void GetAllCards()
        {
            var cards = Cards.All;

            Assert.IsTrue(cards.Count > 0, "Where are the cards?!");
        }
    }
}
