using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassesLibrary.Models;

namespace WPF_LukaMarkota
{
    public partial class MatchHeader : UserControl
    {
        public MatchHeader()
        {
            InitializeComponent();
        }

        public event Action<Match> MatchSelected;

        private class TeamDisplay
        {
            public string DisplayText { get; set; }
            public Team Team { get; set; }
        }

        private class MatchDisplay
        {
            public string DisplayText { get; set; }
            public Match Match { get; set; }
        }

        private async void MatchHeader_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var teams = await ClassesLibrary.Information.LoadTeamsAsync();

                var teamDisplayList = teams
                    .OrderBy(t => t.Country)
                    .Select(t => new TeamDisplay
                    {
                        DisplayText = $"{t.Country} ({t.FifaCode})",
                        Team = t
                    })
                    .ToList();

                PopulateComboBox(cbTeamSelector, teamDisplayList, "DisplayText");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load teams: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void cbTeamSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTeamSelector.SelectedItem is not TeamDisplay selected) return;

            try
            {
                var allMatches = await ClassesLibrary.Information.LoadMatchesAsync();

                var teamMatches = allMatches
                    .Where(m =>
                        m.HomeTeamCountry.Equals(selected.Team.Country, StringComparison.OrdinalIgnoreCase) ||
                        m.AwayTeamCountry.Equals(selected.Team.Country, StringComparison.OrdinalIgnoreCase))
                    .Select(m => new MatchDisplay
                    {
                        DisplayText = $"{m.HomeTeamCountry} vs {m.AwayTeamCountry}",
                        Match = m
                    })
                    .OrderBy(md => md.DisplayText)
                    .ToList();

                PopulateComboBox(cbMatchSelector, teamMatches, "DisplayText");

                if (teamMatches.Count > 0)
                {
                    DisplayMatch(teamMatches[0].Match);
                    MatchSelected?.Invoke(teamMatches[0].Match);
                }
                else
                {
                    ClearMatchDisplay();
                    MatchSelected?.Invoke(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load matches: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbMatchSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMatchSelector.SelectedItem is not MatchDisplay selected) return;

            DisplayMatch(selected.Match);
            MatchSelected?.Invoke(selected.Match);
        }

        private void DisplayMatch(Match match)
        {
            lblMatchLocation.Text = match.Location;
            lblTeamA.Text = match.HomeTeamCountry;
            lblTeamB.Text = match.AwayTeamCountry;
            lblScore.Text = $"{match.HomeTeam?.Goals ?? 0} : {match.AwayTeam?.Goals ?? 0}";
        }

        private void ClearMatchDisplay()
        {
            lblMatchLocation.Text = "No matches found";
            lblTeamA.Text = "Team A";
            lblTeamB.Text = "Team B";
            lblScore.Text = "0 : 0";
        }

        private void PopulateComboBox<T>(ComboBox comboBox, IEnumerable<T> items, string displayPath)
        {
            var itemList = items.ToList();
            comboBox.ItemsSource = itemList;
            comboBox.DisplayMemberPath = displayPath;
            comboBox.SelectedIndex = itemList.Any() ? 0 : -1;
        }

        private void btnOpenSettings_Click(object sender, RoutedEventArgs e)
        {
            var initWindow = new InitWindow();
            initWindow.Show();

            // Close the current MainWindow (the one hosting this MatchHeader)
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.SuppressExitConfirmation(); // Prevent confirmation dialog
            mainWindow?.Close();
        }

    }
}
