using ClassesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPF_LukaMarkota
{
    public partial class HomeTeamLineup : UserControl
    {
        private Team? _team;
        private Match? _currentMatch; 

        public HomeTeamLineup()
        {
            InitializeComponent();
        }

        //from MainWindow when match is selected
        public void SetTeamFromMatch(string country, List<Team> allTeams)
        {
            _team = allTeams
                .FirstOrDefault(t => t.Country.Equals(country, StringComparison.OrdinalIgnoreCase));
        }

        public void SetLineup(List<StartingEleven> players)
        {
            icStartingEleven.ItemsSource = players ?? new List<StartingEleven>();
        }

        public void SetMatch(Match match)
        {
            _currentMatch = match;
        }

        private void btnHomeTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            if (_team == null)
            {
                MessageBox.Show("Nema podataka za odabranu reprezentaciju.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var teamWindow = new TeamInfoWindow(_team);
            teamWindow.Opacity = 0;
            teamWindow.Show();

            var fadeIn = new System.Windows.Media.Animation.DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            teamWindow.BeginAnimation(Window.OpacityProperty, fadeIn);
        }



    }
}

