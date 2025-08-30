namespace WFA_LukaMarkota
{
    partial class PlayerStatControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            picImage = new PictureBox();
            lblStat = new Label();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(9, 17);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // picImage
            // 
            picImage.Location = new Point(110, 3);
            picImage.Name = "picImage";
            picImage.Size = new Size(45, 42);
            picImage.TabIndex = 1;
            picImage.TabStop = false;
            // 
            // lblStat
            // 
            lblStat.AutoSize = true;
            lblStat.Location = new Point(161, 17);
            lblStat.Name = "lblStat";
            lblStat.Size = new Size(38, 15);
            lblStat.TabIndex = 2;
            lblStat.Text = "label2";
            // 
            // PlayerStatControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStat);
            Controls.Add(picImage);
            Controls.Add(lblName);
            Name = "PlayerStatControl";
            Size = new Size(260, 50);
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private PictureBox picImage;
        private Label lblStat;
    }
}
