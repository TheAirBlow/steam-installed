using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.SteamInstalled
{
    public class Main
    {
        public const string gamesAPI = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/";

        public static string GetGamesNameByID(string id)
        {
            byte[] bytes = new WebClient().DownloadData(gamesAPI);
            string content = Encoding.UTF8.GetString(bytes);
            JSON json = JsonConvert.DeserializeObject<JSON>(content);

            return json.applist.apps.OrderByDescending(app => app.appid == id).ToList()[0].name;
        }

        public static bool IsGameInstalled(string id)
        {
            try
            {
                string name = GetGamesNameByID(id);
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
                string path = (string)key.GetValue("SteamPath");
                path += "/steamapps/";
                foreach (string file in Directory.GetFiles(path))
                {
                    if (Path.GetFileName(file).StartsWith("appmanifest_"))
                    {
                        string data = File.ReadAllText(file);
                        if (data.Contains($"\"name\"		\"{name}\"")
                            && data.Contains($"\"appid\"		\"{id}\"")) return true;
                    }
                }

                return false;
            }
            catch { return false; }
        }
    }
}
