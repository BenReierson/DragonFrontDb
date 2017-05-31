using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonFrontDb.Enums;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace DragonFrontDb
{
    public class Cards
    {
        public ReadOnlyDictionary<string, Card> CardDictionary { get; private set; }
        public ReadOnlyDictionary<Traits, string> TraitsDictionary { get; private set; }

        public ReadOnlyCollection<Card> All { get; private set; }
        
        /// <summary>
        /// Create an instance of the cards database. By default, the built-in data is used.
        /// </summary>
        public static Cards Instance(string externalCardsArrayJson = null, string externalTraitsArrayJson = null)
        {
            var cardsJson = externalCardsArrayJson ?? GetResourceTextFile("AllCards.json");
            var traitsJson = externalTraitsArrayJson ?? GetResourceTextFile("CardTraits.json");

            #region Parse Cards
            var allCards = JsonConvert.DeserializeObject<List<Card>>(cardsJson);
            var allCardsDictionary = allCards.ToDictionary(k => k.ID, c => c);

            //add traits based on card text 
            var knownTraits = Enum.GetValues(typeof(Traits)).Cast<Traits>();
            foreach (var card in allCardsDictionary)
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
            #endregion

            #region Parse Trait Descriptions
            var mutableTraitDictionary = JsonConvert.DeserializeObject<Dictionary<Traits, string>>(traitsJson);
            #endregion

            var cards = new Cards
            {
                TraitsDictionary = new ReadOnlyDictionary<Traits, string>(mutableTraitDictionary),
                CardDictionary = new ReadOnlyDictionary<string, Card>(allCardsDictionary),
                All = new ReadOnlyCollection<Card>(allCards)
            };

            return cards;
        }

        private static List<Card> ImportFromJson(string filename)
        {
            var json = GetResourceTextFile(filename);

            var cards = JsonConvert.DeserializeObject<List<Card>>(json);

            return cards;
        }


        private static string GetResourceTextFile(string filename)
        {
            string result = string.Empty;

            using (Stream stream = typeof(Card).GetTypeInfo().Assembly.GetManifestResourceStream("DragonFrontDb." + filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
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
