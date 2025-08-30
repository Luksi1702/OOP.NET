using ClassesLibrary;
using ClassesLibrary.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WFA_LukaMarkota
{
    public partial class PlayerStatControl : UserControl
    {
        public PlayerStatControl(StartingEleven player, int statValue)
        {
            InitializeComponent();

            lblName.Text = player.Name;
            lblStat.Text = $"Stat: {statValue}";

            picImage.Image = LoadPlayerImage(player.Name);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Image LoadPlayerImage(string name)
        {
            string imagePath = Information.GetPlayerImagePath(name);
            string fallbackPath = Information.DefaultPlayerImagePath;

            if (File.Exists(imagePath))
                return Image.FromFile(imagePath);

            return File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : null;
        }
    }
}
