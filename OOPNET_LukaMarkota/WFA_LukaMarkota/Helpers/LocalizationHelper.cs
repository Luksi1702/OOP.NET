using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_LukaMarkota.Helpers
{
    public static class LocalizationHelper
    {
        private static Dictionary<string, string> en = new Dictionary<string, string>
        {
            { "favourite_team", "Favourite team" },
            { "confirm_selection", "Confirm Selection" },
            { "favourite_players", "Favourite players" },
            { "other_players", "Other players" },
            { "show_rankings", "Show Rankings" },
            { "export_pdf", "Export to PDF" },
            { "select_team_warning", "Please select a team." },
            { "team_saved", "Team saved successfully." },
            { "match_not_found", "No match found for selected team." }
        };

        private static Dictionary<string, string> hr = new Dictionary<string, string>
        {
            { "favourite_team", "Omiljena reprezentacija" },
            { "confirm_selection", "Potvrdi izbor" },
            { "favourite_players", "Omiljeni igrači" },
            { "other_players", "Ostali igrači" },
            { "show_rankings", "Prikaži poredak" },
            { "export_pdf", "Izvezi u PDF" },
            { "select_team_warning", "Molimo odaberite reprezentaciju." },
            { "team_saved", "Reprezentacija je spremljena." },
            { "match_not_found", "Nema utakmice za odabranu reprezentaciju." }
        };

        public static string Translate(string key, string language)
        {
            var dict = language == "hr" ? hr : en;
            return dict.ContainsKey(key) ? dict[key] : key;
        }
    }
}
