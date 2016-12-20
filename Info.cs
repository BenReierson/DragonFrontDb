using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFrontDb
{
    public static class Info
    {
        public static Version DragonFontDbVersion
        {
            get
            {
                return new Version(1,2,4);
            }
        }

        public static Version DragonFrontVersion
        {
            get
            {
                return new Version(1, 1, 5, 1);
            }
        }
    }
}
