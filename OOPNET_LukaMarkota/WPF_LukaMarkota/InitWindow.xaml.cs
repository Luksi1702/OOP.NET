using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_LukaMarkota
{
    /// <summary>
    /// Interaction logic for InitWindow.xaml
    /// </summary>
    public partial class InitWindow : Window
    {
        public InitWindow()
        {
            InitializeComponent();
        }

        private void SaveConfig_Click(object sender, RoutedEventArgs e)
        {
            string selectedGender = ((ComboBoxItem)cbGender.SelectedItem)?.Content.ToString().ToLower();
            string selectedLanguage = ((ComboBoxItem)cbLanguage.SelectedItem)?.Content.ToString().ToLower();

            if (string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(selectedLanguage))
            {
                MessageBox.Show("Molimo odaberite obje opcije.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string gender = selectedGender == "žensko" ? "women" : "men";
            string language = selectedLanguage == "hrvatski" ? "hr" : "en";

            var currentConfig = ClassesLibrary.Information.ReadConfig();
            string existingSource = currentConfig.GetValueOrDefault("source", "api");

            var newConfig = new Dictionary<string, string>
            {
                { "source", existingSource },
                { "gender", gender },
                { "language", language },
                { "windowmode", ((ComboBoxItem)cbWindowMode.SelectedItem)?.Tag.ToString() ?? "fullscreen" }
            };

            ClassesLibrary.Information.WriteConfig(newConfig);

            var config = ClassesLibrary.Information.ReadConfig();
            var mainWindow = new MainWindow();

            string mode = config.GetValueOrDefault("windowmode", "fullscreen");

            if (mode == "fullscreen")
            {
                mainWindow.WindowState = WindowState.Maximized;
                mainWindow.WindowStyle = WindowStyle.None;
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
                    mainWindow.ResizeMode = ResizeMode.NoResize;
                    mainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }

            mainWindow.Show();
            UIStyleHelper.ApplyStyle(mainWindow, mode);
            this.Close();
        }
    }
}
