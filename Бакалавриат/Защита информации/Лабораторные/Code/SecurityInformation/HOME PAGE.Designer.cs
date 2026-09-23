namespace SecurityInformation
{
    partial class HomePage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.InputLoginLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.InputPasswordLabel = new System.Windows.Forms.Label();
            this.SignInButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputLoginLabel
            // 
            this.InputLoginLabel.AutoSize = true;
            this.InputLoginLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.InputLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputLoginLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputLoginLabel.Location = new System.Drawing.Point(42, 53);
            this.InputLoginLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InputLoginLabel.Name = "InputLoginLabel";
            this.InputLoginLabel.Size = new System.Drawing.Size(171, 20);
            this.InputLoginLabel.TabIndex = 0;
            this.InputLoginLabel.Text = "INPUT USER LOGIN:";
            this.InputLoginLabel.UseMnemonic = false;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox.Location = new System.Drawing.Point(46, 76);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameTextBox.MaxLength = 255;
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ShortcutsEnabled = false;
            this.UserNameTextBox.Size = new System.Drawing.Size(250, 38);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.WordWrap = false;
            // 
            // UserPasswordTextBox
            // 
            this.UserPasswordTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordTextBox.Location = new System.Drawing.Point(46, 153);
            this.UserPasswordTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserPasswordTextBox.MaxLength = 255;
            this.UserPasswordTextBox.Name = "UserPasswordTextBox";
            this.UserPasswordTextBox.PasswordChar = '*';
            this.UserPasswordTextBox.Size = new System.Drawing.Size(250, 38);
            this.UserPasswordTextBox.TabIndex = 2;
            this.UserPasswordTextBox.TabStop = false;
            this.UserPasswordTextBox.UseSystemPasswordChar = true;
            this.UserPasswordTextBox.WordWrap = false;
            // 
            // InputPasswordLabel
            // 
            this.InputPasswordLabel.AutoSize = true;
            this.InputPasswordLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.InputPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputPasswordLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InputPasswordLabel.Location = new System.Drawing.Point(42, 133);
            this.InputPasswordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InputPasswordLabel.Name = "InputPasswordLabel";
            this.InputPasswordLabel.Size = new System.Drawing.Size(217, 20);
            this.InputPasswordLabel.TabIndex = 3;
            this.InputPasswordLabel.Text = "INPUT USER PASSWORD:";
            this.InputPasswordLabel.UseMnemonic = false;
            // 
            // SignInButton
            // 
            this.SignInButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SignInButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignInButton.Location = new System.Drawing.Point(191, 215);
            this.SignInButton.Margin = new System.Windows.Forms.Padding(0);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(105, 35);
            this.SignInButton.TabIndex = 4;
            this.SignInButton.TabStop = false;
            this.SignInButton.Text = "SIGN IN";
            this.SignInButton.UseCompatibleTextRendering = true;
            this.SignInButton.UseMnemonic = false;
            this.SignInButton.UseVisualStyleBackColor = false;
            this.SignInButton.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(46, 215);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExitButton.Size = new System.Drawing.Size(60, 35);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseCompatibleTextRendering = true;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(482, 26);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.HelpToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HelpToolStripMenuItem.Checked = true;
            this.HelpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.HelpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutUsToolStripMenuItem});
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold);
            this.HelpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.ShowShortcutKeys = false;
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.HelpToolStripMenuItem.Text = "Options";
            this.HelpToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // AboutUsToolStripMenuItem
            // 
            this.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem";
            this.AboutUsToolStripMenuItem.ShowShortcutKeys = false;
            this.AboutUsToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.AboutUsToolStripMenuItem.Text = "About us";
            this.AboutUsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.AboutUsToolStripMenuItem.Click += new System.EventHandler(this.AboutUsToolStripMenuItem_Click);
            // 
            // HomePage
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.InputPasswordLabel);
            this.Controls.Add(this.UserPasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.InputLoginLabel);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(600, 250);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "HomePage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SIGN IN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomePage_FormClosed);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputLoginLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox UserPasswordTextBox;
        private System.Windows.Forms.Label InputPasswordLabel;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutUsToolStripMenuItem;
    }
}

