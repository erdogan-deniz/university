namespace SecurityInformation
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.UserStatusLabel = new System.Windows.Forms.Label();
            this.UserLoginLabel = new System.Windows.Forms.Label();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CheckUsersButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserStatusLabel
            // 
            resources.ApplyResources(this.UserStatusLabel, "UserStatusLabel");
            this.UserStatusLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.UserStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserStatusLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UserStatusLabel.Name = "UserStatusLabel";
            this.UserStatusLabel.UseCompatibleTextRendering = true;
            this.UserStatusLabel.UseMnemonic = false;
            // 
            // UserLoginLabel
            // 
            resources.ApplyResources(this.UserLoginLabel, "UserLoginLabel");
            this.UserLoginLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.UserLoginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserLoginLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UserLoginLabel.Name = "UserLoginLabel";
            this.UserLoginLabel.UseCompatibleTextRendering = true;
            this.UserLoginLabel.UseMnemonic = false;
            // 
            // MenuLabel
            // 
            resources.ApplyResources(this.MenuLabel, "MenuLabel");
            this.MenuLabel.BackColor = System.Drawing.SystemColors.MenuText;
            this.MenuLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.UseCompatibleTextRendering = true;
            this.MenuLabel.UseMnemonic = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // CheckUsersButton
            // 
            resources.ApplyResources(this.CheckUsersButton, "CheckUsersButton");
            this.CheckUsersButton.Name = "CheckUsersButton";
            this.CheckUsersButton.TabStop = false;
            this.CheckUsersButton.UseCompatibleTextRendering = true;
            this.CheckUsersButton.UseMnemonic = false;
            this.CheckUsersButton.UseVisualStyleBackColor = true;
            this.CheckUsersButton.Click += new System.EventHandler(this.ShowUsersList);
            // 
            // AddUserButton
            // 
            resources.ApplyResources(this.AddUserButton, "AddUserButton");
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.TabStop = false;
            this.AddUserButton.UseCompatibleTextRendering = true;
            this.AddUserButton.UseMnemonic = false;
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.TabStop = false;
            this.CloseButton.UseCompatibleTextRendering = true;
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LoginLabel
            // 
            resources.ApplyResources(this.LoginLabel, "LoginLabel");
            this.LoginLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.UseCompatibleTextRendering = true;
            this.LoginLabel.UseMnemonic = false;
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.UseCompatibleTextRendering = true;
            this.StatusLabel.UseMnemonic = false;
            // 
            // UserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::SecurityInformation.Properties.Resources.UserPageBackground;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.CheckUsersButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.UserLoginLabel);
            this.Controls.Add(this.UserStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserStatusLabel;
        private System.Windows.Forms.Label UserLoginLabel;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CheckUsersButton;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label StatusLabel;
    }
}