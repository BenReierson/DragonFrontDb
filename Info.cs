using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFrontDb
{
    public class Info
    {
        public Version DragonFontDbVersion { get; set; }

        public Version DragonFrontVersion { get; set; }

        public Version CardDataVersion { get; set; }

        public Version CardDataCompatibleVersion { get; set;}

        public string CardDataName { get; set; }

        public Dictionary<Version, string> CardDataChangeLog { get; set; }

        private static Info _info;
        public static Info Current => _info ?? 
            (_info = JsonConvert.DeserializeObject<Info>(Helper.GetResourceTextFile("Info.json")));
        
    }
}
