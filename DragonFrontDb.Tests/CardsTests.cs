using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonFrontDb.Enums;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Reflection;

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

        [TestMethod]
        public void TestCurrentInfo()
        {
            var info = Info.Current;
            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void TestLoadExternalCardData()
        {
            var defaultCards = Cards.Instance();
            var externalJson = GetResourceTextFile("TestCards.json");
            var externalCards = Cards.Instance(externalJson);

            Assert.AreNotEqual(defaultCards, externalCards);
            Assert.AreNotEqual(defaultCards.All[0], externalCards.All[0]);
            Assert.AreEqual("Test001", externalCards.All[0].ID);
        }

        [TestMethod]
        public void TestLoadExternalTraits()
        {
            var defaultTraits = Cards.Instance().TraitsDictionary;
            var externalJson = GetResourceTextFile("TestTraits.json");
            var externalTraits = Cards.Instance(externalTraitsArrayJson: externalJson).TraitsDictionary;

            Assert.AreEqual(Traits._SPAWN, externalTraits.First().Key);
            Assert.AreEqual("Test", externalTraits.First().Value);
        }

        [TestMethod]
        public void TestExternalCardAndTraitsData()
        {
            var defaultCards = Cards.Instance();
            var externalJson = GetResourceTextFile("TestCards.json");
            var externalCards = Cards.Instance(externalJson);

            var defaultTraits = Cards.Instance().TraitsDictionary;
            externalJson = GetResourceTextFile("TestTraits.json");
            var externalTraits = Cards.Instance(externalTraitsArrayJson: externalJson).TraitsDictionary;


            Assert.AreNotEqual(defaultCards, externalCards);
            Assert.AreNotEqual(defaultCards.All[0], externalCards.All[0]);
            Assert.AreEqual("Test001", externalCards.All[0].ID);

            Assert.AreEqual("Test", externalTraits.First().Value);
            Assert.AreEqual(Traits._SPAWN, externalTraits.First().Key);
            Assert.AreEqual(Traits._SPAWN, externalCards.CardDictionary["Test001"].Traits[0]);
        }

        internal static string GetResourceTextFile(string filename)
        {
            string result = string.Empty;

            using (Stream stream = typeof(CardsTests).GetTypeInfo().Assembly.GetManifestResourceStream("DragonFrontDb.Tests." + filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
    }
}
