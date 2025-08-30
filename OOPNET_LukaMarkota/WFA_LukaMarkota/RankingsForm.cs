using ClassesLibrary;
using ClassesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WFA_LukaMarkota
{
    public partial class RankingsForm : Form
    {
        private string selectedTeam;
        private string gender;
        private List<Match> matches;

        public RankingsForm(string team, string gender)
        {
            InitializeComponent();
            selectedTeam = team;
            this.gender = gender;
        }

        private async void RankingsForm_Load(object sender, EventArgs e)
        {
            await LoadMatchesAsync();
            SetupComboBox();
            tabStats.SelectedIndexChanged += TabStats_SelectedIndexChanged;
        }

        private async Task LoadMatchesAsync()
        {
            try
            {
                var allMatches = await Information.LoadMatchesAsync();

                matches = allMatches
                    .Where(m =>
                        string.Equals(m.HomeTeam.Code, selectedTeam, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(m.AwayTeam.Code, selectedTeam, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (matches.Count == 0)
                {
                    MessageBox.Show($"No matches found for team code: {selectedTeam}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading matches: {ex.Message}");
            }
        }

        private void SetupComboBox()
        {
            cbMatches.Items.Clear();

            foreach (var match in matches)
            {
                cbMatches.Items.Add($"{match.HomeTeamCountry} vs {match.AwayTeamCountry} - {match.Location}");
            }

            cbMatches.SelectedIndexChanged += cbMatches_SelectedIndexChanged;
            if (cbMatches.Items.Count > 0)
                cbMatches.SelectedIndex = 0;
        }

        private void cbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedMatch();
        }

        private void TabStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedMatch();
        }

        private void LoadSelectedMatch()
        {
            int index = cbMatches.SelectedIndex;
            if (index < 0 || index >= matches.Count) return;

            var match = matches[index];

            lblHomeTeam.Text = match.HomeTeamCountry;
            lblAwayTeam.Text = match.AwayTeamCountry;
            lblLocation.Text = match.Location;
            lblAttendance.Text = match.Attendance?.ToString("N0") ?? "N/A";

            var homePlayers = match.HomeTeamStatistics.StartingEleven
                .Concat(match.HomeTeamStatistics.Substitutes)
                .ToList();

            var awayPlayers = match.AwayTeamStatistics.StartingEleven
                .Concat(match.AwayTeamStatistics.Substitutes)
                .ToList();

            string statType = tabStats.SelectedTab == tabGoals ? "goal" : "yellow-card";

            DisplayPlayers(match, homePlayers, awayPlayers, statType);
        }

        private void DisplayPlayers(Match match, List<StartingEleven> homePlayers, List<StartingEleven> awayPlayers, string statType)
        {
            pnlHomePlayers.Controls.Clear();
            pnlAwayPlayers.Controls.Clear();

            var allEvents = match.HomeTeamEvents.Concat(match.AwayTeamEvents);

            var playerStats = allEvents
                .Where(e => e.TypeOfEvent == statType)
                .GroupBy(e => e.Player)
                .ToDictionary(g => g.Key, g => g.Count());

            var sortedHome = homePlayers
                .OrderByDescending(p => playerStats.TryGetValue(p.Name ?? "", out var count) ? count : 0);

            var sortedAway = awayPlayers
                .OrderByDescending(p => playerStats.TryGetValue(p.Name ?? "", out var count) ? count : 0);

            foreach (var player in sortedHome)
            {
                int statValue = playerStats.TryGetValue(player.Name ?? "", out var count) ? count : 0;
                pnlHomePlayers.Controls.Add(new PlayerStatControl(player, statValue));
            }

            foreach (var player in sortedAway)
            {
                int statValue = playerStats.TryGetValue(player.Name ?? "", out var count) ? count : 0;
                pnlAwayPlayers.Controls.Add(new PlayerStatControl(player, statValue));
            }
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (cbMatches.SelectedIndex < 0 || cbMatches.SelectedIndex >= matches.Count)
                return;

            var match = matches[cbMatches.SelectedIndex];
            string statType = tabStats.SelectedTab == tabGoals ? "goal" : "yellow-card";

            var allEvents = match.HomeTeamEvents.Concat(match.AwayTeamEvents);
            var playerStats = allEvents
                .Where(ev => ev.TypeOfEvent == statType)
                .GroupBy(ev => ev.Player)
                .ToDictionary(g => g.Key, g => g.Count());

            var homePlayers = match.HomeTeamStatistics.StartingEleven.Concat(match.HomeTeamStatistics.Substitutes);
            var awayPlayers = match.AwayTeamStatistics.StartingEleven.Concat(match.AwayTeamStatistics.Substitutes);

            var sortedHome = homePlayers.OrderByDescending(p => playerStats.TryGetValue(p.Name ?? "", out var count) ? count : 0);
            var sortedAway = awayPlayers.OrderByDescending(p => playerStats.TryGetValue(p.Name ?? "", out var count) ? count : 0);

            Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font playerFont = new Font("Segoe UI", 10);
            int y = 50;

            e.Graphics.DrawString($"Match: {match.HomeTeamCountry} vs {match.AwayTeamCountry}", headerFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString($"Location: {match.Location}", playerFont, Brushes.Black, 50, y);
            y += 20;
            e.Graphics.DrawString($"Attendance: {match.Attendance?.ToString("N0") ?? "N/A"}", playerFont, Brushes.Black, 50, y);
            y += 30;

            e.Graphics.DrawString($"{match.HomeTeamCountry} Players ({statType}):", headerFont, Brushes.Black, 50, y);
            y += 30;
            foreach (var player in sortedHome)
            {
                int stat = playerStats.TryGetValue(player.Name ?? "", out var count) ? count : 0;
                e.Graphics.DrawString($"{player.Name} - {stat}", playerFont, Brushes.Black, 70, y);
                y += 20;
            }

            y += 30;
            e.Graphics.DrawString($"{match.AwayTeamCountry} Players ({statType}):", headerFont, Brushes.Black, 50, y);
            y += 30;
            foreach (var player in sortedAway)
            {
                int stat = playerStats.TryGetValue(player.Name ?? "", out var count) ? count : 0;
                e.Graphics.DrawString($"{player.Name} - {stat}", playerFont, Brushes.Black, 70, y);
                y += 20;
            }
        }
    }
}
