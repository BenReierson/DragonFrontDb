using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonFrontDb.Enums;
using Newtonsoft.Json;
using System.Linq;

namespace DragonFrontDb.Tests
{
    [TestClass]
    public class CardsTests
    {
        [TestMethod]
        public void GetAllCards()
        {
            var cards = Cards.Instance().All;

            Assert.IsTrue(cards.Count > 0, "Where are the cards?!");
        }

        [TestMethod]
        public void GetAllTraits()
        {
            var traits = Cards.Instance().TraitsDictionary;

            Assert.AreEqual(Enum.GetValues(typeof(Traits)).Length, traits.Count);
        }

        [TestMethod]
        public void GetConquestSet()
        {
            var conquestSet = Cards.Instance().All.Where(c => c.CardSet == CardSet.CONQUEST);
            Assert.AreEqual(7, conquestSet.Count());
        }
    }
}
