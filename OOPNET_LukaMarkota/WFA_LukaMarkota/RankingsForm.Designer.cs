namespace WFA_LukaMarkota
{
    partial class RankingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingsForm));
            tabStats = new TabControl();
            tabGoals = new TabPage();
            tabCards = new TabPage();
            pnlAwayPlayers = new FlowLayoutPanel();
            lblAwayTeam = new Label();
            pnlHomePlayers = new FlowLayoutPanel();
            lblHomeTeam = new Label();
            btnExportToPDF = new Button();
            cbMatches = new ComboBox();
            label1 = new Label();
            lblLocation = new Label();
            label3 = new Label();
            lblAttendance = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            pageSetupDialog1 = new PageSetupDialog();
            printPreviewDialog1 = new PrintPreviewDialog();
            tabStats.SuspendLayout();
            SuspendLayout();
            // 
            // tabStats
            // 
            tabStats.Controls.Add(tabGoals);
            tabStats.Controls.Add(tabCards);
            tabStats.Location = new Point(3, 2);
            tabStats.Name = "tabStats";
            tabStats.SelectedIndex = 0;
            tabStats.Size = new Size(149, 32);
            tabStats.TabIndex = 0;
            // 
            // tabGoals
            // 
            tabGoals.Location = new Point(4, 24);
            tabGoals.Name = "tabGoals";
            tabGoals.Padding = new Padding(3);
            tabGoals.Size = new Size(141, 4);
            tabGoals.TabIndex = 0;
            tabGoals.Text = "Goals";
            tabGoals.UseVisualStyleBackColor = true;
            // 
            // tabCards
            // 
            tabCards.Location = new Point(4, 24);
            tabCards.Name = "tabCards";
            tabCards.Padding = new Padding(3);
            tabCards.Size = new Size(141, 4);
            tabCards.TabIndex = 1;
            tabCards.Text = "Yellow cards";
            tabCards.UseVisualStyleBackColor = true;
            // 
            // pnlAwayPlayers
            // 
            pnlAwayPlayers.AutoScroll = true;
            pnlAwayPlayers.Location = new Point(293, 95);
            pnlAwayPlayers.Name = "pnlAwayPlayers";
            pnlAwayPlayers.Size = new Size(230, 340);
            pnlAwayPlayers.TabIndex = 3;
            // 
            // lblAwayTeam
            // 
            lblAwayTeam.AutoSize = true;
            lblAwayTeam.Location = new Point(293, 58);
            lblAwayTeam.Name = "lblAwayTeam";
            lblAwayTeam.Size = new Size(38, 15);
            lblAwayTeam.TabIndex = 1;
            lblAwayTeam.Text = "label2";
            // 
            // pnlHomePlayers
            // 
            pnlHomePlayers.AutoScroll = true;
            pnlHomePlayers.Location = new Point(25, 95);
            pnlHomePlayers.Name = "pnlHomePlayers";
            pnlHomePlayers.Size = new Size(230, 340);
            pnlHomePlayers.TabIndex = 2;
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Location = new Point(25, 58);
            lblHomeTeam.Name = "lblHomeTeam";
            lblHomeTeam.Size = new Size(38, 15);
            lblHomeTeam.TabIndex = 0;
            lblHomeTeam.Text = "label1";
            // 
            // btnExportToPDF
            // 
            btnExportToPDF.Location = new Point(608, 397);
            btnExportToPDF.Name = "btnExportToPDF";
            btnExportToPDF.Size = new Size(129, 38);
            btnExportToPDF.TabIndex = 10;
            btnExportToPDF.Text = "Export to PDF";
            btnExportToPDF.UseVisualStyleBackColor = true;
            btnExportToPDF.Click += btnExportToPDF_Click;
            // 
            // cbMatches
            // 
            cbMatches.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMatches.FormattingEnabled = true;
            cbMatches.Location = new Point(563, 28);
            cbMatches.Name = "cbMatches";
            cbMatches.Size = new Size(225, 23);
            cbMatches.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(563, 293);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 12;
            label1.Text = "Location:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(625, 293);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(38, 15);
            lblLocation.TabIndex = 13;
            lblLocation.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(563, 254);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 14;
            label3.Text = "Guest count:";
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.Location = new Point(643, 254);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(38, 15);
            lblAttendance.TabIndex = 15;
            lblAttendance.Text = "label1";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // RankingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAttendance);
            Controls.Add(label3);
            Controls.Add(lblLocation);
            Controls.Add(label1);
            Controls.Add(pnlHomePlayers);
            Controls.Add(pnlAwayPlayers);
            Controls.Add(cbMatches);
            Controls.Add(btnExportToPDF);
            Controls.Add(lblAwayTeam);
            Controls.Add(tabStats);
            Controls.Add(lblHomeTeam);
            Name = "RankingsForm";
            Text = "RankingsForm";
            Load += RankingsForm_Load;
            tabStats.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabStats;
        private TabPage tabGoals;
        private TabPage tabCards;
        private Button btnExportToPDF;
        private ComboBox cbMatches;
        private FlowLayoutPanel pnlAwayPlayers;
        private FlowLayoutPanel pnlHomePlayers;
        private Label lblAwayTeam;
        private Label lblHomeTeam;
        private Label label1;
        private Label lblLocation;
        private Label label3;
        private Label lblAttendance;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private PageSetupDialog pageSetupDialog1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}