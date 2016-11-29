using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonFrontDb.Enums;
using Newtonsoft.Json;

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

        [TestMethod]
        public void GetAllTraits()
        {
            var traits = Cards.TraitsDictionary;

            Assert.AreEqual(Enum.GetValues(typeof(Traits)).Length, traits.Count);
        }
    }
}
