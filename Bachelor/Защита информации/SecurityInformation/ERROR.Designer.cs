namespace SecurityInformation
{
    partial class ErrorPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorPage));
            this.ErrorTextLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ErrorImageBox = new Emgu.CV.UI.ImageBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ErrorImageBox2 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorTextLabel
            // 
            this.ErrorTextLabel.AutoSize = true;
            this.ErrorTextLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorTextLabel.Location = new System.Drawing.Point(100, 95);
            this.ErrorTextLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorTextLabel.Name = "ErrorTextLabel";
            this.ErrorTextLabel.Size = new System.Drawing.Size(0, 30);
            this.ErrorTextLabel.TabIndex = 9;
            this.ErrorTextLabel.UseCompatibleTextRendering = true;
            this.ErrorTextLabel.UseMnemonic = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(205, 151);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(99, 30);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.TabStop = false;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseCompatibleTextRendering = true;
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ErrorImageBox
            // 
            this.ErrorImageBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ErrorImageBox.BackgroundImage")));
            this.ErrorImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ErrorImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ErrorImageBox.Location = new System.Drawing.Point(10, 75);
            this.ErrorImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorImageBox.MaximumSize = new System.Drawing.Size(64, 64);
            this.ErrorImageBox.MinimumSize = new System.Drawing.Size(64, 64);
            this.ErrorImageBox.Name = "ErrorImageBox";
            this.ErrorImageBox.Size = new System.Drawing.Size(64, 64);
            this.ErrorImageBox.TabIndex = 7;
            this.ErrorImageBox.TabStop = false;
            this.ErrorImageBox.WaitOnLoad = true;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLabel.Location = new System.Drawing.Point(215, 25);
            this.ErrorLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(99, 37);
            this.ErrorLabel.TabIndex = 6;
            this.ErrorLabel.Text = "ERROR!";
            this.ErrorLabel.UseCompatibleTextRendering = true;
            this.ErrorLabel.UseMnemonic = false;
            // 
            // ErrorImageBox2
            // 
            this.ErrorImageBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ErrorImageBox2.BackgroundImage")));
            this.ErrorImageBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ErrorImageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ErrorImageBox2.Location = new System.Drawing.Point(429, 75);
            this.ErrorImageBox2.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorImageBox2.MaximumSize = new System.Drawing.Size(64, 64);
            this.ErrorImageBox2.MinimumSize = new System.Drawing.Size(64, 64);
            this.ErrorImageBox2.Name = "ErrorImageBox2";
            this.ErrorImageBox2.Size = new System.Drawing.Size(64, 64);
            this.ErrorImageBox2.TabIndex = 11;
            this.ErrorImageBox2.TabStop = false;
            this.ErrorImageBox2.WaitOnLoad = true;
            // 
            // ErrorPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(502, 208);
            this.Controls.Add(this.ErrorImageBox2);
            this.Controls.Add(this.ErrorTextLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ErrorImageBox);
            this.Controls.Add(this.ErrorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(650, 250);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 255);
            this.Name = "ErrorPage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERROR!";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ErrorTextLabel;
        private System.Windows.Forms.Button CloseButton;
        private Emgu.CV.UI.ImageBox ErrorImageBox;
        private System.Windows.Forms.Label ErrorLabel;
        private Emgu.CV.UI.ImageBox ErrorImageBox2;
    }
}