namespace WFA_LukaMarkota
{
    partial class FormInit
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbCup = new ComboBox();
            cbLanguage = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnInitSave = new Button();
            SuspendLayout();
            // 
            // cbCup
            // 
            cbCup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCup.FormattingEnabled = true;
            cbCup.Location = new Point(75, 29);
            cbCup.Name = "cbCup";
            cbCup.Size = new Size(121, 23);
            cbCup.TabIndex = 0;
            // 
            // cbLanguage
            // 
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Location = new Point(75, 88);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(121, 23);
            cbLanguage.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 29);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Cup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 88);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Language";
            // 
            // btnInitSave
            // 
            btnInitSave.Location = new Point(89, 141);
            btnInitSave.Name = "btnInitSave";
            btnInitSave.Size = new Size(75, 23);
            btnInitSave.TabIndex = 4;
            btnInitSave.Text = "Save";
            btnInitSave.UseVisualStyleBackColor = true;
            btnInitSave.Click += btnInitSave_Click;
            // 
            // FormInit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 233);
            Controls.Add(btnInitSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbLanguage);
            Controls.Add(cbCup);
            Name = "FormInit";
            Text = "Setup";
            Load += FormInit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCup;
        private ComboBox cbLanguage;
        private Label label1;
        private Label label2;
        private Button btnInitSave;
    }
}
