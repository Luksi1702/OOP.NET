using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using ClassesLibrary.Models;

namespace WPF_LukaMarkota
{
    public partial class MainWindow : Window
    {
        private Match? _currentMatch;
        private List<Team> _allTeams = new();

        private bool _isAppExitRequested = true;

        public void SuppressExitConfirmation()
        {
            _isAppExitRequested = false;
        }

        public MainWindow()
        {
            InitializeComponent();
            matchHeader.MatchSelected += OnMatchSelected;
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _allTeams = await ClassesLibrary.Information.LoadTeamsAsync();
        }

        private void OnMatchSelected(Match match)
        {
            _currentMatch = match;

            List<StartingEleven> homePlayers;
            if (match.HomeTeamStatistics != null && match.HomeTeamStatistics.StartingEleven != null)
                homePlayers = match.HomeTeamStatistics.StartingEleven;
            else
                homePlayers = new List<StartingEleven>();

            List<StartingEleven> awayPlayers;
            if (match.AwayTeamStatistics != null && match.AwayTeamStatistics.StartingEleven != null)
                awayPlayers = match.AwayTeamStatistics.StartingEleven;
            else
                awayPlayers = new List<StartingEleven>();

            // lineups
            homeTeamLineupControl.SetLineup(homePlayers);
            awayTeamLineupControl.SetLineup(awayPlayers);
            fieldLineupControl.SetLineups(homePlayers, awayPlayers);

            // team info
            homeTeamLineupControl.SetTeamFromMatch(match.HomeTeamCountry, _allTeams);
            awayTeamLineupControl.SetTeamFromMatch(match.AwayTeamCountry, _allTeams);

            // match context
            homeTeamLineupControl.SetMatch(match);
            awayTeamLineupControl.SetMatch(match);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_isAppExitRequested)
            {
                var confirmWindow = new ConfirmationWindow();
                confirmWindow.ShowDialog();

                if (!confirmWindow.IsConfirmed)
                {
                    e.Cancel = true;
                }
            }

            base.OnClosing(e);
        }
    }
}
