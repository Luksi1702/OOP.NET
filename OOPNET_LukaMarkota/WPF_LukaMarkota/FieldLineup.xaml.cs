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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassesLibrary.Models;

namespace WPF_LukaMarkota
{
    /// <summary>
    /// Interaction logic for FieldLineup.xaml
    /// </summary>
    public partial class FieldLineup : UserControl
    {
        public FieldLineup()
        {
            InitializeComponent();
        }

        public void SetLineups(List<StartingEleven> homePlayers, List<StartingEleven> awayPlayers)
        {
            ClearField();
            SetDynamicColumns(homePlayers, awayPlayers);

            foreach (var player in homePlayers)
                AddPlayerToField(player, isHome: true);

            foreach (var player in awayPlayers)
                AddPlayerToField(player, isHome: false);
        }



        private void SetDynamicColumns(List<StartingEleven> homePlayers, List<StartingEleven> awayPlayers)
        {
            HomeGoaliePanel.Columns = 1;
            HomeDefendersPanel.Columns = Math.Max(1, homePlayers.Count(p => p.Position?.ToLower() == "defender"));
            HomeMidfieldersPanel.Columns = Math.Max(1, homePlayers.Count(p => p.Position?.ToLower() == "midfield"));
            HomeForwardsPanel.Columns = Math.Max(1, homePlayers.Count(p => p.Position?.ToLower() == "forward"));

            AwayGoaliePanel.Columns = 1;
            AwayDefendersPanel.Columns = Math.Max(1, awayPlayers.Count(p => p.Position?.ToLower() == "defender"));
            AwayMidfieldersPanel.Columns = Math.Max(1, awayPlayers.Count(p => p.Position?.ToLower() == "midfield"));
            AwayForwardsPanel.Columns = Math.Max(1, awayPlayers.Count(p => p.Position?.ToLower() == "forward"));
        }


        private void ClearField()
        {
            HomeGoaliePanel.Children.Clear();
            HomeDefendersPanel.Children.Clear();
            HomeMidfieldersPanel.Children.Clear();
            HomeForwardsPanel.Children.Clear();

            AwayGoaliePanel.Children.Clear();
            AwayDefendersPanel.Children.Clear();
            AwayMidfieldersPanel.Children.Clear();
            AwayForwardsPanel.Children.Clear();
        }


        private void AddPlayerToField(StartingEleven player, bool isHome)
        {
            var control = new PlayerControl();
            control.SetPlayer(player);

            string position = player.Position?.ToLower() ?? "";

            Panel targetPanel = null;

            if (isHome)
            {
                switch (position)
                {
                    case "goalie": targetPanel = HomeGoaliePanel; break;
                    case "defender": targetPanel = HomeDefendersPanel; break;
                    case "midfield": targetPanel = HomeMidfieldersPanel; break;
                    case "forward": targetPanel = HomeForwardsPanel; break;
                }
            }
            else
            {
                switch (position)
                {
                    case "goalie": targetPanel = AwayGoaliePanel; break;
                    case "defender": targetPanel = AwayDefendersPanel; break;
                    case "midfield": targetPanel = AwayMidfieldersPanel; break;
                    case "forward": targetPanel = AwayForwardsPanel; break;
                }
            }

            targetPanel?.Children.Add(control);
        }


    }
}
