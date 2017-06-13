using System;
using System.Collections.Generic;
using System.Linq;
using DragonFrontDb.Enums;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DragonFrontDb
{
    public class Cards
    {
        public readonly ReadOnlyDictionary<string, Card> CardDictionary;
        public readonly ReadOnlyDictionary<Traits, string> TraitsDictionary;

        public readonly ReadOnlyCollection<Card> All;
        
        /// <summary>
        /// Create an instance of the cards database. By default, the built-in data is used.
        /// </summary>
        public Cards(string externalCardsArrayJson = null, string externalTraitsArrayJson = null)
        {
            var cardsJson = externalCardsArrayJson ?? Helper.GetResourceTextFile("AllCards.json");
            var traitsJson = externalTraitsArrayJson ?? Helper.GetResourceTextFile("CardTraits.json");

            var allCards = JsonConvert.DeserializeObject<List<Card>>(cardsJson);
            All = new ReadOnlyCollection<Card>(allCards);

            var allCardsDictionary = allCards.ToDictionary(k => k.ID, c => c);
            CardDictionary = new ReadOnlyDictionary<string, Card>(allCardsDictionary);

            ParseTraits(allCardsDictionary);
            var mutableTraitDictionary = JsonConvert.DeserializeObject<Dictionary<Traits, string>>(traitsJson);
            TraitsDictionary = new ReadOnlyDictionary<Traits, string>(mutableTraitDictionary);
        }

        private static void ParseTraits(Dictionary<string, Card> cardsDictionary)
        {
            //add traits based on card text 
            var knownTraits = Enum.GetValues(typeof(Traits)).Cast<Traits>();
            foreach (var card in cardsDictionary)
            {
                var cardTraits = card.Value.Traits?.ToList() ?? new List<Traits>();
                var traitText = card.Value.Text.Replace(' ', '_').Replace(':', '_').Replace(',', '_').Replace('.', '_').Insert(0, "_");
                foreach (var trait in knownTraits)
                {
                    if (!cardTraits.Contains(trait) &&
                        traitText.Contains(Enum.GetName(typeof(Traits), trait)))
                    { cardTraits.Add(trait); }
                }
                if (card.Value.IsGiant && !cardTraits.Contains(Traits.GIANT)) cardTraits.Add(Traits.GIANT);
                card.Value.Traits = cardTraits.ToArray();
            }
        }

        private static List<Card> ImportFromJson(string filename)
        {
            var json = Helper.GetResourceTextFile(filename);

            var cards = JsonConvert.DeserializeObject<List<Card>>(json);

            return cards;
        }
        
    }

    public static class CardsExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
