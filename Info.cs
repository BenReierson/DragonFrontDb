﻿using DragonFrontDb.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFrontDb
{
    public record Info
    {
        public Version DragonFontDbVersion { get; set; }

        public Version DragonFrontVersion { get; set; }

        public Version CardDataVersion { get; set; }

        public Version CardDataCompatibleVersion { get; set;}

        public string CardDataName { get; set; }

		public string CardDataUrl { get; set; }

		public string CardTraitsUrl { get; set; }

        public DataStatus CardDataStatus { get; set; }

        public Dictionary<Version, string> CardDataChangeLog { get; set; }

        private static Info _info;
        public static Info Current => _info ?? 
            (_info = JsonConvert.DeserializeObject<Info>(Helper.GetResourceTextFile("Info.json"), new LegacyVersionConverter()));
        
    }

    public class LegacyVersionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = serializer.Deserialize<Dictionary<string, int>>(reader);
            return new Version(dict["Major"], dict["Minor"], dict["Build"], 0); //revision not used
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Version);
        }
    }
}
