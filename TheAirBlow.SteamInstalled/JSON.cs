using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.SteamInstalled
{
    public class JSON
    {
        public AppsJSON applist;
    }

    public class AppsJSON
    {
        public List<AppJSON> apps;
    }

    public class AppJSON
    {
        public string appid;
        public string name;
    }
}
