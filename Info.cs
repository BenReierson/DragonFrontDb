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
                return new Version(1,3,7);
            }
        }

        public static Version DragonFrontVersion
        {
            get
            {
                return new Version(1, 4, 2, 0);
            }
        }
    }
}
