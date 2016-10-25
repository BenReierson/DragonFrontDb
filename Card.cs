using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonFrontDb.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace DragonFrontDb
{
    [JsonObject]
    public class Card
    {

        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardSet CardSet { get; internal set; }

        [JsonProperty]
        public string Text { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType Type { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction { get; internal set; }

        [JsonProperty]
        public bool Collectible { get; internal set; }

        [JsonProperty]
        public int Cost { get; internal set; }

        [JsonProperty]
        public string FlavorText { get; internal set; }

        [JsonProperty]
        public string Health { get; internal set; }

        [JsonProperty]
        public string ID { get; internal set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public Traits[] Traits { get; internal set; }

        [JsonProperty]
        public string Power { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity Rarity { get; internal set; }

        [JsonProperty]
        public int Version { get; internal set; }

        [JsonProperty]
        public int ManaFragments { get; internal set; }

        [JsonProperty]
        public bool IsGiant { get; internal set; }

        [JsonProperty]
        public Race Race { get; internal set; }

        public override string ToString()
        {
            return this.Name + " | " + this.Type.ToString() + " | " + this.Faction.ToString();
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            var equal = card != null && this.ID == card.ID;

            return equal;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
