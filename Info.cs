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
                return new Version(0, 1);
            }
        }

        public static Version DragonFrontVersion
        {
            get
            {
                return new Version(0, 96, 24309, 2);
            }
        }
    }
}
