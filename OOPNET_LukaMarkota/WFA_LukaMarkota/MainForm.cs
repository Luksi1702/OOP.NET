using ClassesLibrary;
using ClassesLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_LukaMarkota.Helpers;

namespace WFA_LukaMarkota
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip playerContextMenu;

        public MainForm()
        {
            InitializeComponent();
        }

        // 🔹 Entry point
        private async void MainForm_Load(object sender, EventArgs e)
        {
            Information.EnsureRuntimeConfigExists();
            Information.ValidateLocalDataOrFallbackToApi();
            InitializeImageFolder();
            SetupDragDrop();
            SetupContextMenu();
            LoadConfigAndApplySettings();
            await LoadFavoritePlayersAsync();
            await LoadTeamsIntoComboBoxAsync();
            this.FormClosing += MainForm_FormClosing;
        }

        // 🔹 Initialization
        private void InitializeImageFolder()
        {
            if (!Directory.Exists(Information.SharedImageFolderPath))
                Directory.CreateDirectory(Information.SharedImageFolderPath);
        }


        private void SetupDragDrop()
        {
            pnlFavourites.AllowDrop = true;
            pnlOthers.AllowDrop = true;

            pnlFavourites.DragEnter += Panel_DragEnter;
            pnlOthers.DragEnter += Panel_DragEnter;

            pnlFavourites.DragDrop += PanelFavorites_DragDrop;
            pnlOthers.DragDrop += PanelOthers_DragDrop;
        }

        private void SetupContextMenu()
        {
            playerContextMenu = new ContextMenuStrip();

            var addToFavoritesItem = new ToolStripMenuItem("Dodaj u favorite");
            addToFavoritesItem.Click += AddSelectedToFavorites;

            var removeFromFavoritesItem = new ToolStripMenuItem("Makni iz favorita");
            removeFromFavoritesItem.Click += RemoveSelectedFromFavorites;

            playerContextMenu.Items.Add(addToFavoritesItem);
            playerContextMenu.Items.Add(removeFromFavoritesItem);
        }

        private void LoadConfigAndApplySettings()
        {
            var config = Information.ReadConfig();
            string language = config.GetValueOrDefault("language", "en");

            ApplyLanguage(language);
        }

        private void ApplyLanguage(string language)
        {
            lblFavouriteTeam.Text = LocalizationHelper.Translate("favourite_team", language);
            btnConfirmTeam.Text = LocalizationHelper.Translate("confirm_selection", language);
            lblFavouritePlayers.Text = LocalizationHelper.Translate("favourite_players", language);
            lblOtherPlayers.Text = LocalizationHelper.Translate("other_players", language);
            btnShowRankings.Text = LocalizationHelper.Translate("show_rankings", language);
            btnSettings.Text = LocalizationHelper.Translate("settings", language);
        }

        //Data loading
        private async Task LoadFavoritePlayersAsync()
        {
            FavoriteHelper.EnsureFavoriteFileExists();
            var favoriteNames = FavoriteHelper.LoadFavoritePlayers();

            var matches = await Information.LoadMatchesAsync();

            foreach (var match in matches)
            {
                var allPlayers = match.HomeTeamStatistics.StartingEleven
                    .Concat(match.HomeTeamStatistics.Substitutes)
                    .Concat(match.AwayTeamStatistics.StartingEleven)
                    .Concat(match.AwayTeamStatistics.Substitutes);

                foreach (var player in allPlayers)
                {
                    if (favoriteNames.Contains(player.Name) &&
                        !pnlFavourites.Controls.OfType<PlayerControl>().Any(p => p.PlayerData.Name == player.Name))
                    {
                        Invoke(new Action(() =>
                        {
                            var pc = new PlayerControl(player, true);
                            pc.ContextMenuStrip = playerContextMenu;
                            pnlFavourites.Controls.Add(pc);
                        }));
                    }
                }
            }
        }

        private async Task LoadTeamsIntoComboBoxAsync()
        {
            var teams = await Information.LoadTeamsAsync();

            cbFavouriteTeam.Items.Clear();
            foreach (var team in teams.OrderBy(t => t.Country))
            {
                cbFavouriteTeam.Items.Add($"{team.Country} ({team.FifaCode})");
            }

            cbFavouriteTeam.SelectedIndex = -1;
        }

        private async Task LoadPlayersForTeamAsync(string teamName, string gender)
        {
            var matches = await Information.LoadMatchesAsync();

            var match = matches.FirstOrDefault(m =>
                m.HomeTeamCountry == teamName || m.AwayTeamCountry == teamName);

            if (match == null)
            {
                MessageBox.Show("No match found for selected team.");
                return;
            }

            var teamStats = match.HomeTeamCountry == teamName
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;

            var allPlayers = teamStats.StartingEleven
                .Concat(teamStats.Substitutes)
                .ToList();

            pnlOthers.Controls.Clear();

            var nonFavoritePlayers = allPlayers
                .Where(p => !pnlFavourites.Controls
                    .OfType<PlayerControl>()
                    .Any(f => f.PlayerData.Name == p.Name))
                .OrderBy(p => p.ShirtNumber)
                .ToList();

            foreach (var player in nonFavoritePlayers)
            {
                var pc = new PlayerControl(player, false);
                pc.ContextMenuStrip = playerContextMenu;
                pnlOthers.Controls.Add(pc);
            }
        }

        //Favorites
        private void SaveCurrentFavorites()
        {
            var favoriteNames = pnlFavourites.Controls
                .OfType<PlayerControl>()
                .Select(pc => pc.PlayerData.Name)
                .ToList();

            FavoriteHelper.SaveFavoritePlayers(favoriteNames);
        }

        private void AddSelectedToFavorites(object sender, EventArgs e)
        {
            var selected = pnlOthers.Controls.OfType<PlayerControl>().Where(p => p.Selected).ToList();
            foreach (var player in selected)
            {
                pnlOthers.Controls.Remove(player);
                pnlFavourites.Controls.Add(player);
                player.Selected = false;
                player.BackColor = Color.Transparent;
            }
            SaveCurrentFavorites();
        }

        private void RemoveSelectedFromFavorites(object sender, EventArgs e)
        {
            var selected = pnlFavourites.Controls.OfType<PlayerControl>().Where(p => p.Selected).ToList();
            foreach (var player in selected)
            {
                pnlFavourites.Controls.Remove(player);
                pnlOthers.Controls.Add(player);
                player.Selected = false;
                player.BackColor = Color.Transparent;
            }
            SaveCurrentFavorites();
        }

        //UI Events
        private async void btnConfirmTeam_Click(object sender, EventArgs e)
        {
            string selectedEntry = cbFavouriteTeam.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedEntry))
            {
                MessageBox.Show("Please select a team.");
                return;
            }

            string teamName = selectedEntry.Split('(')[0].Trim();
            string teamCode = selectedEntry.Split('(')[1].Replace(")", "").Trim();

            var config = Information.ReadConfig();
            config["team"] = teamCode;
            Information.WriteConfig(config);

            string gender = config.GetValueOrDefault("gender", "men");
            await LoadPlayersForTeamAsync(teamName, gender);
        }

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            var initForm = new FormInit();
            var result = initForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var config = Information.ReadConfig();
                string gender = config.GetValueOrDefault("gender", "men");
                string language = config.GetValueOrDefault("language", "en");

                ApplyLanguage(language);
                await LoadTeamsIntoComboBoxAsync();
                pnlOthers.Controls.Clear();
            }
        }

        //Drag-and-drop logic
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerControl)))
                e.Effect = DragDropEffects.Move;
        }

        private void PanelFavorites_DragDrop(object sender, DragEventArgs e)
        {
            var player = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
            pnlFavourites.Controls.Add(player);
            pnlOthers.Controls.Remove(player);
            SaveCurrentFavorites();
        }

        private void PanelOthers_DragDrop(object sender, DragEventArgs e)
        {
            var player = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
            pnlOthers.Controls.Add(player);
            pnlFavourites.Controls.Remove(player);
            SaveCurrentFavorites();
        }

        private void btnShowRankings_Click(object sender, EventArgs e)
        {
            var config = Information.ReadConfig();

            string team = config.GetValueOrDefault("team", "");
            string gender = config.GetValueOrDefault("gender", "men");

            if (string.IsNullOrEmpty(team))
            {
                MessageBox.Show("Molimo odaberite reprezentaciju prije prikaza rang lista.");
                return;
            }

            var rankingsForm = new RankingsForm(team, gender);
            rankingsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Jeste li sigurni da želite zatvoriti aplikaciju?",
                "Potvrda izlaza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
