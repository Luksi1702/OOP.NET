using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassesLibrary;
using ClassesLibrary.Models;

namespace WFA_LukaMarkota
{
    public partial class PlayerControl : UserControl
    {
        public StartingEleven PlayerData { get; private set; }
        public bool Selected { get; set; } = false;

        private Point _mouseDownLocation;
        private bool _dragInitiated = false;

        public PlayerControl(StartingEleven player, bool isFavorite)
        {
            InitializeComponent();
            PlayerData = player;

            // Set player info
            lblName.Text = player.Name;
            lblNumber.Text = $"#{player.ShirtNumber}";
            lblPosition.Text = player.Position;

            // Load player image
            picImage.Image = LoadPlayerImage(player.Name);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.BorderStyle = BorderStyle.FixedSingle;

            // Load captain icon
            picCaptain.Image = LoadCaptainIcon();
            picCaptain.SizeMode = PictureBoxSizeMode.Zoom;
            picCaptain.Visible = player.Captain;

            // Drag surface
            panelDragSurface.BackColor = Color.Transparent;
            panelDragSurface.Cursor = Cursors.Hand;
            panelDragSurface.SendToBack();
            panelDragSurface.MouseDown += PlayerControl_MouseDown;
            panelDragSurface.MouseMove += PlayerControl_MouseMove;

            // Selection logic
            this.Click += PlayerControl_Click;
            foreach (Control child in Controls)
                child.Click += PlayerControl_Click;

            // Update image button
            btnUpdateImage.Click += btnUpdateImage_Click;
        }

        // Toggle selection on Ctrl+Click
        private void PlayerControl_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                ToggleSelection();
            }
            else
            {
                if (Parent is Panel panel)
                {
                    foreach (var pc in panel.Controls.OfType<PlayerControl>())
                        pc.Deselect();
                }
                Select();
            }
        }

        public void ToggleSelection()
        {
            Selected = !Selected;
            BackColor = Selected ? Color.LightBlue : Color.Transparent;
        }

        public void Select()
        {
            Selected = true;
            BackColor = Color.LightBlue;
        }

        public void Deselect()
        {
            Selected = false;
            BackColor = Color.Transparent;
        }

        // Drag-and-drop
        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _dragInitiated = false;
        }

        private void PlayerControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_dragInitiated)
            {
                int dragThreshold = SystemInformation.DragSize.Width;
                if (Math.Abs(e.X - _mouseDownLocation.X) > dragThreshold ||
                    Math.Abs(e.Y - _mouseDownLocation.Y) > dragThreshold)
                {
                    _dragInitiated = true;
                    DoDragDrop(this, DragDropEffects.Move);
                }
            }
        }

        // Load player image or fallback
        private Image LoadPlayerImage(string name)
        {
            string imagePath = Information.GetPlayerImagePath(name);
            string fallbackPath = Information.DefaultPlayerImagePath;

            if (File.Exists(imagePath))
                return Image.FromFile(imagePath);

            return File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : null;
        }


        // Load captain icon
        private Image LoadCaptainIcon()
        {
            string iconPath = Information.CaptainBadgeImagePath;
            return File.Exists(iconPath) ? Image.FromFile(iconPath) : null;
        }


        // Update player image
        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            dialog.Title = $"Odaberi sliku za {PlayerData.Name}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = dialog.FileName;
                string targetPath = Information.GetPlayerImagePath(PlayerData.Name); 
                string targetFolder = Path.GetDirectoryName(targetPath);

                try
                {
                    // solution-level Images folder exists?
                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    picImage.Image?.Dispose();

                    using var original = Image.FromFile(sourcePath);
                    original.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    picImage.Image = Image.FromFile(targetPath);
                    picImage.SizeMode = PictureBoxSizeMode.Zoom;
                    picImage.BorderStyle = BorderStyle.FixedSingle;

                    MessageBox.Show("Slika uspješno ažurirana.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri spremanju slike: {ex.Message}");
                }
            }
        }


    }
}
