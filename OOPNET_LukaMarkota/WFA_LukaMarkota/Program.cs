using System;
using System.IO;
using System.Windows.Forms;
using ClassesLibrary;

namespace WFA_LukaMarkota
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = Information.ReadConfig();
            bool hasGender = config.ContainsKey("gender");
            bool hasLanguage = config.ContainsKey("language");

            if (!hasGender || !hasLanguage)
            {
                var initForm = new FormInit();
                if (initForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Configuration not completed. Exiting.");
                    Application.Exit();
                    return;
                }
            }





            Application.Run(new MainForm());
        }
    }
}
