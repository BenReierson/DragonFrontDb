using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DragonFrontDb
{
    internal class Helper
    {
        internal static string GetResourceTextFile(string filename)
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
        
        internal static async Task<string> GetResourceTextFileAsync(string filename)
        {
            await using var stream = typeof(Card).GetTypeInfo().Assembly.GetManifestResourceStream("DragonFrontDb." + filename);
            using var sr = new StreamReader(stream);
            var result = await sr.ReadToEndAsync();
            return result;
        }
    }

}
