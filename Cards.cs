using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonFrontDb.Enums;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace DragonFrontDb
{
    public static class Cards
    {

        #region Extensions
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
        #endregion

        public static readonly ReadOnlyDictionary<string, Card> CardDictionary;
        public static readonly ReadOnlyDictionary<Traits, string> TraitsDictionary;

        public static readonly ReadOnlyCollection<Card> All;
        public static readonly ReadOnlyCollection<Card> AllThorns;
        public static readonly ReadOnlyCollection<Card> AllStrife;
        public static readonly ReadOnlyCollection<Card> AllScales;
        public static readonly ReadOnlyCollection<Card> AllEclipse;
        public static readonly ReadOnlyCollection<Card> AllSilence;
        public static readonly ReadOnlyCollection<Card> AllUnaligned;


        static Cards()
        {
            #region Parse Cards
            var _allCardsMutable = ImportFromJson("AllCards.json").ToDictionary(k => k.ID, c => c);

            //add traits based on card text 
            //TODO:Remove this when all traits for each card are included in json
            var knownTraits = Enum.GetValues(typeof(Traits)).Cast<Traits>();
            foreach (var card in _allCardsMutable)
            {
                var cardTraits = card.Value.Traits?.ToList() ?? new List<Traits>();
                var traitText = card.Value.Text.Replace(" ", "_").Replace(":", "_").Replace(",", "_").Replace(".", "_").Insert(0, "_");
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
            var traitsJson = GetResourceTextFile("CardTraits.json");
            var mutableTraitDictionary = JsonConvert.DeserializeObject<Dictionary<Traits, string>>(traitsJson);
            #endregion

            TraitsDictionary = new ReadOnlyDictionary<Traits, string>(mutableTraitDictionary);
            CardDictionary = new ReadOnlyDictionary<string, Card>(_allCardsMutable);
            All = new ReadOnlyCollection<Card>(_allCardsMutable.Values.ToList());
            AllThorns = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.THORNS).ToList());
            AllStrife = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.STRIFE).ToList());
            AllEclipse = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.ECLIPSE).ToList());
            AllScales = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.SCALES).ToList());
            AllSilence = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.SILENCE).ToList());
            AllUnaligned = new ReadOnlyCollection<Card>(All.Where((c) => c.Faction == Faction.UNALIGNED).ToList());
            
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
}
