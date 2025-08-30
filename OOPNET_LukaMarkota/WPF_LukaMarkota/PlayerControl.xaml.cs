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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassesLibrary.Models;
using ClassesLibrary;
using System.IO;
using System.Windows.Controls;

namespace WPF_LukaMarkota
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();

        }


        //for UIStyleHelper
        public Image PlayerImage => imgPlayer;
        public TextBlock NumberText => txtNumber;
        public TextBlock NameText => txtName;
        public TextBlock CaptainText => txtCaptain;


        public void SetPlayer(ClassesLibrary.Models.StartingEleven player)
        {
            txtNumber.Text = player.ShirtNumber.ToString();
            txtName.Text = player.Name;
            txtCaptain.Text = player.Captain ? "(C)" : "";

            string imagePath = ClassesLibrary.Information.GetPlayerImagePath(player.Name);

            if (File.Exists(imagePath))
            {
                imgPlayer.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            }
            else
            {
                string fallbackPath = ClassesLibrary.Information.DefaultPlayerImagePath;
                if (File.Exists(fallbackPath))
                {
                    imgPlayer.Source = new BitmapImage(new Uri(fallbackPath, UriKind.Absolute));
                }
                else
                {
                    imgPlayer.Source = null;
                }
            }
        }


    }
}
