namespace SecurityInformation
{
    partial class AddNewUserForn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewUserForn));
            this.InputNewLoginLabel = new System.Windows.Forms.Label();
            this.UserLoginTextBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputNewLoginLabel
            // 
            this.InputNewLoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputNewLoginLabel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.InputNewLoginLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputNewLoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InputNewLoginLabel.Location = new System.Drawing.Point(147, 54);
            this.InputNewLoginLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InputNewLoginLabel.MaximumSize = new System.Drawing.Size(274, 30);
            this.InputNewLoginLabel.MinimumSize = new System.Drawing.Size(274, 30);
            this.InputNewLoginLabel.Name = "InputNewLoginLabel";
            this.InputNewLoginLabel.Size = new System.Drawing.Size(274, 30);
            this.InputNewLoginLabel.TabIndex = 0;
            this.InputNewLoginLabel.Text = "INPUT NEW USER LOGIN:";
            this.InputNewLoginLabel.UseCompatibleTextRendering = true;
            this.InputNewLoginLabel.UseMnemonic = false;
            // 
            // UserLoginTextBox
            // 
            this.UserLoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserLoginTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLoginTextBox.Location = new System.Drawing.Point(147, 100);
            this.UserLoginTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserLoginTextBox.MaximumSize = new System.Drawing.Size(210, 30);
            this.UserLoginTextBox.MaxLength = 255;
            this.UserLoginTextBox.MinimumSize = new System.Drawing.Size(210, 30);
            this.UserLoginTextBox.Name = "UserLoginTextBox";
            this.UserLoginTextBox.ShortcutsEnabled = false;
            this.UserLoginTextBox.Size = new System.Drawing.Size(210, 30);
            this.UserLoginTextBox.TabIndex = 1;
            this.UserLoginTextBox.TabStop = false;
            this.UserLoginTextBox.WordWrap = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CloseButton.FlatAppearance.BorderSize = 2;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(147, 151);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(90, 35);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.TabStop = false;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseCompatibleTextRendering = true;
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddUserButton
            // 
            this.AddUserButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddUserButton.Location = new System.Drawing.Point(267, 151);
            this.AddUserButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(90, 35);
            this.AddUserButton.TabIndex = 3;
            this.AddUserButton.TabStop = false;
            this.AddUserButton.Text = "ADD";
            this.AddUserButton.UseCompatibleTextRendering = true;
            this.AddUserButton.UseMnemonic = false;
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddNewUserForn
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = global::SecurityInformation.Properties.Resources.BackgroundPhotoTwo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(502, 253);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UserLoginTextBox);
            this.Controls.Add(this.InputNewLoginLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "AddNewUserForn";
            this.ShowInTaskbar = false;
            this.Text = "ADD NEW USER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputNewLoginLabel;
        private System.Windows.Forms.TextBox UserLoginTextBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AddUserButton;
    }
}