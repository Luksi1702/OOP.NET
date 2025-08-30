using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using ClassesLibrary;

namespace WPF_LukaMarkota
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // First ensure config exists
            Information.EnsureRuntimeConfigExists();

            // Validate local data and possibly update config
            Information.ValidateLocalDataOrFallbackToApi();

            // ✅ Reload config after validation
            var config = Information.ReadConfig();

            bool missingKeys = !IsConfigComplete(config);

            if (missingKeys)
            {
                var initWindow = new InitWindow();
                initWindow.Show(); // InitWindow handles config setup
            }
            else
            {
                LaunchMainWindow(config);
            }
        }




        private bool IsConfigComplete(Dictionary<string, string> config)
        {
            return config.ContainsKey("gender") &&
                   config.ContainsKey("language") &&
                   config.ContainsKey("windowmode") &&
                   config.ContainsKey("source");
        }

        private void LaunchMainWindow(Dictionary<string, string> config)
        {
            var mainWindow = new MainWindow();

            string mode = config.GetValueOrDefault("windowmode", "fullscreen");

            if (mode == "fullscreen")
            {
                mainWindow.WindowState = WindowState.Maximized;
                mainWindow.ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                var parts = mode.Split('x');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int width) &&
                    int.TryParse(parts[1], out int height))
                {
                    mainWindow.Width = width;
                    mainWindow.Height = height;
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }
            }

            mainWindow.Show();
        }



    }
}
