using System;
using DragonFrontDb.Enums;
using System.Linq;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace DragonFrontDb.Tests
{
    [TestFixture]
    public class CardsTests
    {
        [Test]
        public void GetAllCards()
        {
            var cards = new Cards().All;

            Assert.IsTrue(cards.Count > 0, "Where are the cards?!");
        }

        [Test]
        public void GetAllTraits()
        {
            var traits = new Cards().TraitsDictionary;

            Assert.AreEqual(Enum.GetValues(typeof(Traits)).Length, traits.Count);
        }

        [Test]
        public void GetConquestSet()
        {
            var conquestSet = new Cards().All.Where(c => c.CardSet == CardSet.CONQUEST);
            Assert.AreEqual(7, conquestSet.Count());
        }

        [Test]
        public void TestCurrentInfo()
        {
            var info = Info.Current;
            Assert.IsNotNull(info);
        }

        [Test]
        public void TestLoadExternalCardData()
        {
            var defaultCards = new Cards();
            var externalJson = GetResourceTextFile("TestCards.json");
            var externalCards = new Cards(externalJson);

            Assert.AreNotEqual(defaultCards, externalCards);
            Assert.AreNotEqual(defaultCards.All[0], externalCards.All[0]);
            Assert.AreEqual("Test001", externalCards.All[0].ID);
        }

        [Test]
        public void TestLoadExternalTraits()
        {
            var defaultTraits = new Cards().TraitsDictionary;
            var externalJson = GetResourceTextFile("TestTraits.json");
            var externalTraits = new Cards(externalTraitsArrayJson: externalJson).TraitsDictionary;

            Assert.AreEqual(Traits._SPAWN.ToString(), externalTraits.First().Key);
            Assert.AreEqual("Test", externalTraits.First().Value);
        }

        [Test]
        public void TestExternalCardAndTraitsData()
        {
            var defaultCards = new Cards();
            var externalJson = GetResourceTextFile("TestCards.json");
            var externalCards = new Cards(externalJson);

            var defaultTraits = new Cards().TraitsDictionary;
            externalJson = GetResourceTextFile("TestTraits.json");
            var externalTraits = new Cards(externalTraitsArrayJson: externalJson).TraitsDictionary;


            Assert.AreNotEqual(defaultCards, externalCards);
            Assert.AreNotEqual(defaultCards.All[0], externalCards.All[0]);
            Assert.AreEqual("Test001", externalCards.All[0].ID);

            Assert.AreEqual("Test", externalTraits.First().Value);
            Assert.AreEqual(Traits._SPAWN.ToString(), externalTraits.First().Key);
            Assert.AreEqual(Traits._SPAWN.ToString(), externalCards.CardDictionary["Test001"].Traits[0]);
        }


        [Test]
        public void TestValidFactions()
        {
			var testJson = GetResourceTextFile("TestCardsFactions.json");
			var testCards = new Cards(testJson);
			var validFactions = Enum.GetValues(typeof(Faction)).Cast<Faction>().Skip(2).ToArray();

			foreach (var card in testCards.All)
            {
                Assert.IsNotNull(card.ValidFactions);
				Assert.IsFalse(card.ValidFactions.Contains(Faction.INVALID));
				Assert.IsFalse(card.ValidFactions.Contains(Faction.UNALIGNED));
			}

            Assert.AreEqual("Test001", testCards.All[0].ID);
            var unalignedCard = testCards.All[0];
            Assert.IsTrue(validFactions.All(unalignedCard.ValidFactions.Contains));

			Assert.AreEqual("Test002", testCards.All[1].ID);
			var strifeCard = testCards.All[1];
			Assert.IsFalse(validFactions.All(strifeCard.ValidFactions.Contains));
            Assert.AreEqual(1, strifeCard.ValidFactions.Count());
            Assert.Contains(Faction.STRIFE, strifeCard.ValidFactions);

			Assert.AreEqual("Test003", testCards.All[2].ID);
			var strifeAndThornsCard = testCards.All[2];
			Assert.IsFalse(validFactions.All(strifeAndThornsCard.ValidFactions.Contains));
			Assert.AreEqual(2, strifeAndThornsCard.ValidFactions.Count());
			Assert.Contains(Faction.STRIFE, strifeAndThornsCard.ValidFactions);
			Assert.Contains(Faction.THORNS, strifeAndThornsCard.ValidFactions);

			Assert.AreEqual("Test004", testCards.All[3].ID);
			var tripleFactionChamp = testCards.All[3];
			Assert.IsFalse(validFactions.All(tripleFactionChamp.ValidFactions.Contains));
			Assert.AreEqual(3, tripleFactionChamp.ValidFactions.Count());
			Assert.Contains(Faction.SILENCE, tripleFactionChamp.ValidFactions);
			Assert.Contains(Faction.ECLIPSE, tripleFactionChamp.ValidFactions);
			Assert.Contains(Faction.DELIRIUM, tripleFactionChamp.ValidFactions);
		}

        [Test]
        public void TestTokens()
        {
            var allCards = new Cards().All;
			var tokens = allCards.Where(c=>c.Rarity == Rarity.TOKEN);
            Assert.IsTrue(tokens.Any());
            Assert.AreEqual(tokens.Count(), allCards.Count(c => c.Traits.Contains(Traits.TOKEN.ToString())));
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
