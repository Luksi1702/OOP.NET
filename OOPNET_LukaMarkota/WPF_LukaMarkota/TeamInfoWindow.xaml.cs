using ClassesLibrary.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_LukaMarkota
{
    /// <summary>
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        public TeamInfoWindow(Team team)
        {
            InitializeComponent();

            lblTeamName.Text = $"Reprezentacija: {team.Country}";
            lblFifaCode.Text = $"FIFA kod: {team.FifaCode}";
            lblMatches.Text = $"Odigrano: {team.GamesPlayed}";
            lblWins.Text = $"Pobjede: {team.Wins}";
            lblLosses.Text = $"Porazi: {team.Losses}";
            lblDraws.Text = $"Neodlučeno: {team.Draws}";
            lblGoalsScored.Text = $"Golovi zabijeni: {team.GoalsFor}";
            lblGoalsConceded.Text = $"Golovi primljeni: {team.GoalsAgainst}";
            lblGoalDifference.Text = $"Gol razlika: {team.GoalDifferential}";
        }
    }


}
