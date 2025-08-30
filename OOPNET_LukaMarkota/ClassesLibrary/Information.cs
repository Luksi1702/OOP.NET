using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClassesLibrary.Models;
using ClassesLibrary.Helpers;

namespace ClassesLibrary
{
    public static class Information
    {

        public static string RuntimeConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

        public static string TemplateConfigPath
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string solutionRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.Parent?.FullName;
                return Path.Combine(solutionRoot ?? "", "SharedData", "config.txt");
            }
        }


        public static string SharedImageFolderPath
        {
            get
            {
                // Traverse up 4 levels from bin/Debug/netX.X/
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string solutionRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.Parent?.FullName;

                return Path.Combine(solutionRoot ?? "", "Images");
            }
        }

        public static string SharedDataFolderPath
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string solutionRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.Parent?.FullName;
                return Path.Combine(solutionRoot ?? "", "SharedData");
            }
        }

        public static string DefaultPlayerImagePath =>
            Path.Combine(SharedImageFolderPath, "defaultPlayerImage.png");

        public static string CaptainBadgeImagePath =>
            Path.Combine(SharedImageFolderPath, "captain.jpg");

        public static string GetPlayerImagePath(string playerName) =>
            Path.Combine(SharedImageFolderPath, playerName + ".jpg");


        // Reads all config key-value pairs into a dictionary
        public static Dictionary<string, string> ReadConfig()
        {
            var config = new Dictionary<string, string>();

            if (!File.Exists(RuntimeConfigPath))
                return config;

            foreach (var line in File.ReadAllLines(RuntimeConfigPath))
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                    config[parts[0].Trim().ToLower()] = parts[1].Trim().ToLower();
            }

            return config;
        }



        // Writes config dictionary to file
        public static void WriteConfig(Dictionary<string, string> config)
        {
            var lines = config.Select(kvp => $"{kvp.Key}={kvp.Value}");
            File.WriteAllLines(RuntimeConfigPath, lines);
        }

        //config file exists?
        public static void EnsureRuntimeConfigExists()
        {
            if (!File.Exists(RuntimeConfigPath))
            {
                if (File.Exists(TemplateConfigPath))
                {
                    File.Copy(TemplateConfigPath, RuntimeConfigPath);
                }

            }
        }

        public static void ValidateLocalDataOrFallbackToApi()
        {
            var config = ReadConfig();
            string source = config.GetValueOrDefault("source", "api");
            string gender = config.GetValueOrDefault("gender", "men");

            if (source != "file") return;

            string teamFile = Path.Combine(SharedDataFolderPath, gender == "women" ? "women_teams.json" : "men_teams.json");
            string matchFile = Path.Combine(SharedDataFolderPath, gender == "women" ? "women_matches.json" : "men_matches.json");

            bool teamExists = File.Exists(teamFile);
            bool matchExists = File.Exists(matchFile);

            if (!teamExists || !matchExists)
            {
                config["source"] = "api";
                WriteConfig(config);
            }
        }



        public static async Task<List<Team>> LoadTeamsAsync()
        {
            var config = ReadConfig();
            string source = config.GetValueOrDefault("source", "api");
            string gender = config.GetValueOrDefault("gender", "men");

            string fileName = Path.Combine(SharedDataFolderPath, gender == "women" ? "women_teams.json" : "men_teams.json");

            if (source == "file" && File.Exists(fileName))
            {
                string json = await File.ReadAllTextAsync(fileName);
                return JsonConvert.DeserializeObject<List<Team>>(json, Converter.Settings);
            }

            string apiUrl = gender == "women"
                ? "https://worldcup-vua.nullbit.hr/women/teams/results"
                : "https://worldcup-vua.nullbit.hr/men/teams/results";

            using var client = new HttpClient();
            var apiJson = await client.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<List<Team>>(apiJson, Converter.Settings);
        }


        public static async Task<List<Match>> LoadMatchesAsync()
        {
            var config = ReadConfig();
            string source = config.GetValueOrDefault("source", "api");
            string gender = config.GetValueOrDefault("gender", "men");

            string fileName = Path.Combine(SharedDataFolderPath, gender == "women" ? "women_matches.json" : "men_matches.json");

            if (source == "file" && File.Exists(fileName))
            {
                string json = await File.ReadAllTextAsync(fileName);
                return JsonConvert.DeserializeObject<List<Match>>(json, Converter.Settings);
            }

            string apiUrl = gender == "women"
                ? "https://worldcup-vua.nullbit.hr/women/matches"
                : "https://worldcup-vua.nullbit.hr/men/matches";

            using var client = new HttpClient();
            var apiJson = await client.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<List<Match>>(apiJson, Converter.Settings);


        }

    }
}
