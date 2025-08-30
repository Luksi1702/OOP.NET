namespace WFA_LukaMarkota
{
    partial class PlayerControl
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
            lblNumber = new Label();
            lblPosition = new Label();
            picImage = new PictureBox();
            picCaptain = new PictureBox();
            panelDragSurface = new Panel();
            btnUpdateImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCaptain).BeginInit();
            panelDragSurface.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AccessibleDescription = "";
            lblName.AutoSize = true;
            lblName.Location = new Point(16, 104);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(15, 131);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(38, 15);
            lblNumber.TabIndex = 1;
            lblNumber.Text = "label2";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(71, 131);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(38, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "label3";
            // 
            // picImage
            // 
            picImage.Location = new Point(32, 14);
            picImage.Name = "picImage";
            picImage.Size = new Size(77, 73);
            picImage.TabIndex = 3;
            picImage.TabStop = false;
            // 
            // picCaptain
            // 
            picCaptain.Location = new Point(93, 163);
            picCaptain.Name = "picCaptain";
            picCaptain.Size = new Size(31, 32);
            picCaptain.TabIndex = 5;
            picCaptain.TabStop = false;
            // 
            // panelDragSurface
            // 
            panelDragSurface.BackColor = Color.Transparent;
            panelDragSurface.BorderStyle = BorderStyle.FixedSingle;
            panelDragSurface.Controls.Add(btnUpdateImage);
            panelDragSurface.Controls.Add(picImage);
            panelDragSurface.Controls.Add(picCaptain);
            panelDragSurface.Controls.Add(lblPosition);
            panelDragSurface.Controls.Add(lblNumber);
            panelDragSurface.Cursor = Cursors.Hand;
            panelDragSurface.Dock = DockStyle.Fill;
            panelDragSurface.Location = new Point(0, 0);
            panelDragSurface.Name = "panelDragSurface";
            panelDragSurface.Size = new Size(150, 200);
            panelDragSurface.TabIndex = 7;
            // 
            // btnUpdateImage
            // 
            btnUpdateImage.Location = new Point(12, 163);
            btnUpdateImage.Name = "btnUpdateImage";
            btnUpdateImage.Size = new Size(75, 23);
            btnUpdateImage.TabIndex = 6;
            btnUpdateImage.Text = "Image";
            btnUpdateImage.UseVisualStyleBackColor = true;
            btnUpdateImage.Click += btnUpdateImage_Click;
            // 
            // PlayerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblName);
            Controls.Add(panelDragSurface);
            Name = "PlayerControl";
            Size = new Size(150, 200);
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCaptain).EndInit();
            panelDragSurface.ResumeLayout(false);
            panelDragSurface.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private PictureBox picImage;
        private PictureBox picCaptain;
        private Panel panelDragSurface;
        private Button btnUpdateImage;
    }
}
