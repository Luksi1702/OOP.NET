using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_LukaMarkota.Helpers
{
    public static class FavoriteHelper
    {
        public static string RuntimeFavoritePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorite_players.txt");

        public static void EnsureFavoriteFileExists()
        {
            if (!File.Exists(RuntimeFavoritePath))
                File.WriteAllText(RuntimeFavoritePath, "");
        }

        public static List<string> LoadFavoritePlayers()
        {
            EnsureFavoriteFileExists();
            return File.ReadAllLines(RuntimeFavoritePath).ToList();
        }

        public static void SaveFavoritePlayers(List<string> playerNames)
        {
            File.WriteAllLines(RuntimeFavoritePath, playerNames);
        }
    }
}
