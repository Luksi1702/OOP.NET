namespace WFA_LukaMarkota
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblFavouriteTeam = new Label();
            cbFavouriteTeam = new ComboBox();
            btnConfirmTeam = new Button();
            btnShowRankings = new Button();
            lblFavouritePlayers = new Label();
            pnlFavourites = new FlowLayoutPanel();
            pnlOthers = new FlowLayoutPanel();
            lblOtherPlayers = new Label();
            btnSettings = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            dodajUFavoriteToolStripMenuItem = new ToolStripMenuItem();
            makiToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFavouriteTeam
            // 
            lblFavouriteTeam.AutoSize = true;
            lblFavouriteTeam.Location = new Point(12, 69);
            lblFavouriteTeam.Name = "lblFavouriteTeam";
            lblFavouriteTeam.Size = new Size(86, 15);
            lblFavouriteTeam.TabIndex = 0;
            lblFavouriteTeam.Text = "Favourite team";
            // 
            // cbFavouriteTeam
            // 
            cbFavouriteTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFavouriteTeam.FormattingEnabled = true;
            cbFavouriteTeam.Location = new Point(146, 70);
            cbFavouriteTeam.Name = "cbFavouriteTeam";
            cbFavouriteTeam.Size = new Size(279, 23);
            cbFavouriteTeam.TabIndex = 1;
            // 
            // btnConfirmTeam
            // 
            btnConfirmTeam.Location = new Point(440, 69);
            btnConfirmTeam.Name = "btnConfirmTeam";
            btnConfirmTeam.Size = new Size(122, 23);
            btnConfirmTeam.TabIndex = 2;
            btnConfirmTeam.Text = "confirmSelection";
            btnConfirmTeam.UseVisualStyleBackColor = true;
            btnConfirmTeam.Click += btnConfirmTeam_Click;
            // 
            // btnShowRankings
            // 
            btnShowRankings.Location = new Point(68, 511);
            btnShowRankings.Name = "btnShowRankings";
            btnShowRankings.Size = new Size(129, 38);
            btnShowRankings.TabIndex = 3;
            btnShowRankings.Text = "showRankings";
            btnShowRankings.UseVisualStyleBackColor = true;
            btnShowRankings.Click += btnShowRankings_Click;
            // 
            // lblFavouritePlayers
            // 
            lblFavouritePlayers.AutoSize = true;
            lblFavouritePlayers.Location = new Point(30, 120);
            lblFavouritePlayers.Name = "lblFavouritePlayers";
            lblFavouritePlayers.Size = new Size(96, 15);
            lblFavouritePlayers.TabIndex = 5;
            lblFavouritePlayers.Text = "Favourite players";
            // 
            // pnlFavourites
            // 
            pnlFavourites.AllowDrop = true;
            pnlFavourites.AutoScroll = true;
            pnlFavourites.Location = new Point(30, 138);
            pnlFavourites.Name = "pnlFavourites";
            pnlFavourites.Size = new Size(214, 338);
            pnlFavourites.TabIndex = 6;
            // 
            // pnlOthers
            // 
            pnlOthers.AllowDrop = true;
            pnlOthers.AutoScroll = true;
            pnlOthers.Location = new Point(348, 138);
            pnlOthers.Name = "pnlOthers";
            pnlOthers.Size = new Size(214, 338);
            pnlOthers.TabIndex = 8;
            // 
            // lblOtherPlayers
            // 
            lblOtherPlayers.AutoSize = true;
            lblOtherPlayers.Location = new Point(348, 120);
            lblOtherPlayers.Name = "lblOtherPlayers";
            lblOtherPlayers.Size = new Size(77, 15);
            lblOtherPlayers.TabIndex = 7;
            lblOtherPlayers.Text = "Other players";
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(392, 511);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(129, 38);
            btnSettings.TabIndex = 10;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { dodajUFavoriteToolStripMenuItem, makiToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(159, 48);
            // 
            // dodajUFavoriteToolStripMenuItem
            // 
            dodajUFavoriteToolStripMenuItem.Name = "dodajUFavoriteToolStripMenuItem";
            dodajUFavoriteToolStripMenuItem.Size = new Size(158, 22);
            dodajUFavoriteToolStripMenuItem.Text = "Dodaj u favorite";
            dodajUFavoriteToolStripMenuItem.Click += AddSelectedToFavorites;
            // 
            // makiToolStripMenuItem
            // 
            makiToolStripMenuItem.Name = "makiToolStripMenuItem";
            makiToolStripMenuItem.Size = new Size(158, 22);
            makiToolStripMenuItem.Text = "Makni iz favoria";
            makiToolStripMenuItem.Click += RemoveSelectedFromFavorites;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(btnSettings);
            Controls.Add(pnlOthers);
            Controls.Add(lblOtherPlayers);
            Controls.Add(pnlFavourites);
            Controls.Add(lblFavouritePlayers);
            Controls.Add(btnShowRankings);
            Controls.Add(btnConfirmTeam);
            Controls.Add(cbFavouriteTeam);
            Controls.Add(lblFavouriteTeam);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFavouriteTeam;
        private ComboBox cbFavouriteTeam;
        private Button btnConfirmTeam;
        private Button btnShowRankings;
        private Label lblFavouritePlayers;
        private FlowLayoutPanel pnlFavourites;
        private FlowLayoutPanel pnlOthers;
        private Label lblOtherPlayers;
        private Button btnSettings;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem dodajUFavoriteToolStripMenuItem;
        private ToolStripMenuItem makiToolStripMenuItem;
    }
}