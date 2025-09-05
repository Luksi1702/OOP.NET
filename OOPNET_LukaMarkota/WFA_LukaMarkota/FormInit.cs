using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassesLibrary;

namespace WFA_LukaMarkota
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
        }

        // Load config / set dropdowns 
        private void FormInit_Load(object sender, EventArgs e)
        {
            cbCup.Items.AddRange(new[] { "Men", "Women" });
            cbLanguage.Items.AddRange(new[] { "English", "Hrvatski" });

            Information.EnsureRuntimeConfigExists();
            var config = Information.ReadConfig();

            bool hasGender = config.ContainsKey("gender");
            bool hasLanguage = config.ContainsKey("language");

            if (hasGender)
                cbCup.SelectedIndex = config["gender"] == "women" ? 1 : 0;

            if (hasLanguage)
                cbLanguage.SelectedIndex = config["language"] == "hr" ? 1 : 0;
        }


        // Save to config and close 
        private void btnInitSave_Click(object sender, EventArgs e)
        {
            string selectedGender = cbCup.SelectedItem?.ToString().ToLower();
            string selectedLanguage = cbLanguage.SelectedItem?.ToString().ToLower();

            if (string.IsNullOrEmpty(selectedGender) || string.IsNullOrEmpty(selectedLanguage))
            {
                MessageBox.Show("Please select both options.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = selectedGender == "women" ? "women" : "men";
            string language = selectedLanguage == "hrvatski" ? "hr" : "en";
            var currentConfig = Information.ReadConfig();
            string existingSource = currentConfig.GetValueOrDefault("source", "api");


            var newConfig = new Dictionary<string, string>
            {
                { "source", existingSource },
                { "gender", gender },
                { "language", language }
            };

            Information.WriteConfig(newConfig);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

