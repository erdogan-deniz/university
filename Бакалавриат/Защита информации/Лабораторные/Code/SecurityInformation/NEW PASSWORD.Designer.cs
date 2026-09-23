namespace SecurityInformation
{
    partial class NewPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPasswordForm));
            this.OldPasswordLabel = new System.Windows.Forms.Label();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.OldPasswordBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.LimitsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OldPasswordLabel
            // 
            this.OldPasswordLabel.AutoSize = true;
            this.OldPasswordLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OldPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OldPasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OldPasswordLabel.Location = new System.Drawing.Point(16, 22);
            this.OldPasswordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OldPasswordLabel.Name = "OldPasswordLabel";
            this.OldPasswordLabel.Size = new System.Drawing.Size(178, 28);
            this.OldPasswordLabel.TabIndex = 0;
            this.OldPasswordLabel.Text = "INPUT PASSWORD:";
            this.OldPasswordLabel.UseCompatibleTextRendering = true;
            this.OldPasswordLabel.UseMnemonic = false;
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NewPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewPasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewPasswordLabel.Location = new System.Drawing.Point(16, 90);
            this.NewPasswordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(227, 28);
            this.NewPasswordLabel.TabIndex = 1;
            this.NewPasswordLabel.Text = "INPUT NEW PASSWORD:";
            this.NewPasswordLabel.UseCompatibleTextRendering = true;
            this.NewPasswordLabel.UseMnemonic = false;
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(16, 158);
            this.ConfirmPasswordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(257, 28);
            this.ConfirmPasswordLabel.TabIndex = 2;
            this.ConfirmPasswordLabel.Text = "CONFIRM NEW PASSWORD:";
            this.ConfirmPasswordLabel.UseCompatibleTextRendering = true;
            this.ConfirmPasswordLabel.UseMnemonic = false;
            // 
            // OldPasswordBox
            // 
            this.OldPasswordBox.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OldPasswordBox.Location = new System.Drawing.Point(16, 53);
            this.OldPasswordBox.Name = "OldPasswordBox";
            this.OldPasswordBox.PasswordChar = '*';
            this.OldPasswordBox.Size = new System.Drawing.Size(257, 30);
            this.OldPasswordBox.TabIndex = 3;
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPasswordBox.Location = new System.Drawing.Point(16, 121);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.PasswordChar = '*';
            this.newPasswordBox.Size = new System.Drawing.Size(257, 30);
            this.newPasswordBox.TabIndex = 4;
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPasswordBox.Location = new System.Drawing.Point(16, 189);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.PasswordChar = '*';
            this.confirmPasswordBox.Size = new System.Drawing.Size(257, 30);
            this.confirmPasswordBox.TabIndex = 5;
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChangeButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeButton.Location = new System.Drawing.Point(378, 108);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(100, 35);
            this.ChangeButton.TabIndex = 6;
            this.ChangeButton.TabStop = false;
            this.ChangeButton.Text = "SET";
            this.ChangeButton.UseCompatibleTextRendering = true;
            this.ChangeButton.UseMnemonic = false;
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangePasswordButton);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(378, 182);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 35);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.TabStop = false;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LimitsLabel
            // 
            this.LimitsLabel.AutoSize = true;
            this.LimitsLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LimitsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LimitsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LimitsLabel.Location = new System.Drawing.Point(378, 22);
            this.LimitsLabel.Name = "LimitsLabel";
            this.LimitsLabel.Size = new System.Drawing.Size(72, 28);
            this.LimitsLabel.TabIndex = 8;
            this.LimitsLabel.Text = "LIMITS:";
            this.LimitsLabel.UseCompatibleTextRendering = true;
            this.LimitsLabel.UseMnemonic = false;
            // 
            // NewPasswordForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::SecurityInformation.Properties.Resources.NewPasswordBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(502, 263);
            this.Controls.Add(this.LimitsLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.OldPasswordBox);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.OldPasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SET NEW PASSWORD";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label OldPasswordLabel;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.TextBox OldPasswordBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label LimitsLabel;
    }
}