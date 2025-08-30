using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WPF_LukaMarkota
{
    public static class UIStyleHelper
    {
        public static void ApplyStyle(Window window, string resolution)
        {
            double fontSize;
            Thickness margin;

            switch (resolution)
            {
                case "1280x720":
                    fontSize = 12;
                    margin = new Thickness(4);
                    break;
                case "1600x900":
                    fontSize = 14;
                    margin = new Thickness(6);
                    break;
                case "1920x1080":
                    fontSize = 16;
                    margin = new Thickness(8);
                    break;
                default:
                    fontSize = 14;
                    margin = new Thickness(6);
                    break;
            }

            ApplyToChildren(window.Content as DependencyObject, fontSize, margin);
        }

        private static void ApplyToChildren(DependencyObject parent, double fontSize, Thickness margin)
        {
            if (parent == null) return;

            foreach (var child in LogicalTreeHelper.GetChildren(parent))
            {
                if (child is Control control)
                {
                    control.FontSize = fontSize;
                    control.Margin = margin;
                }

                if (child is PlayerControl player)
                {
                    ApplyPlayerStyle(player, fontSize);
                }

                if (child is DependencyObject depChild)
                    ApplyToChildren(depChild, fontSize, margin);
            }
        }

        private static void ApplyPlayerStyle(PlayerControl player, double fontSize)
        {
            double imageSize = fontSize * 2.5;
            imageSize = Math.Max(30, Math.Min(imageSize, 60)); //range

            player.NumberText.FontSize = fontSize;
            player.NameText.FontSize = fontSize - 2;
            player.CaptainText.FontSize = fontSize - 2;
        }

    }

}
