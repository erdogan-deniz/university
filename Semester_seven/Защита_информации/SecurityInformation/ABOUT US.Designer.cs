namespace SecurityInformation
{
    partial class AboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUs));
            this.StudentLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.TaskOneLabel = new System.Windows.Forms.Label();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.UniversityNameLabel = new System.Windows.Forms.Label();
            this.UniversityLabel = new System.Windows.Forms.Label();
            this.TaskTwoLabel = new System.Windows.Forms.Label();
            this.ProgrammerPhotoButton = new System.Windows.Forms.Button();
            this.UniversityPicture = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.UniversityPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentLabel
            // 
            resources.ApplyResources(this.StudentLabel, "StudentLabel");
            this.StudentLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.UseCompatibleTextRendering = true;
            this.StudentLabel.UseMnemonic = false;
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.UseCompatibleTextRendering = true;
            // 
            // GroupNameLabel
            // 
            resources.ApplyResources(this.GroupNameLabel, "GroupNameLabel");
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.UseCompatibleTextRendering = true;
            this.GroupNameLabel.UseMnemonic = false;
            // 
            // GroupLabel
            // 
            resources.ApplyResources(this.GroupLabel, "GroupLabel");
            this.GroupLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.UseCompatibleTextRendering = true;
            this.GroupLabel.UseMnemonic = false;
            // 
            // TaskOneLabel
            // 
            resources.ApplyResources(this.TaskOneLabel, "TaskOneLabel");
            this.TaskOneLabel.Name = "TaskOneLabel";
            this.TaskOneLabel.UseCompatibleTextRendering = true;
            this.TaskOneLabel.UseMnemonic = false;
            // 
            // TaskLabel
            // 
            resources.ApplyResources(this.TaskLabel, "TaskLabel");
            this.TaskLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.UseCompatibleTextRendering = true;
            this.TaskLabel.UseMnemonic = false;
            // 
            // UniversityNameLabel
            // 
            resources.ApplyResources(this.UniversityNameLabel, "UniversityNameLabel");
            this.UniversityNameLabel.Name = "UniversityNameLabel";
            this.UniversityNameLabel.UseCompatibleTextRendering = true;
            this.UniversityNameLabel.UseMnemonic = false;
            // 
            // UniversityLabel
            // 
            resources.ApplyResources(this.UniversityLabel, "UniversityLabel");
            this.UniversityLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UniversityLabel.Name = "UniversityLabel";
            this.UniversityLabel.UseCompatibleTextRendering = true;
            this.UniversityLabel.UseMnemonic = false;
            // 
            // TaskTwoLabel
            // 
            resources.ApplyResources(this.TaskTwoLabel, "TaskTwoLabel");
            this.TaskTwoLabel.Name = "TaskTwoLabel";
            this.TaskTwoLabel.UseCompatibleTextRendering = true;
            this.TaskTwoLabel.UseMnemonic = false;
            // 
            // ProgrammerPhotoButton
            // 
            this.ProgrammerPhotoButton.BackgroundImage = global::SecurityInformation.Properties.Resources.ProgrammerPhoto;
            resources.ApplyResources(this.ProgrammerPhotoButton, "ProgrammerPhotoButton");
            this.ProgrammerPhotoButton.Name = "ProgrammerPhotoButton";
            this.ProgrammerPhotoButton.UseCompatibleTextRendering = true;
            this.ProgrammerPhotoButton.UseMnemonic = false;
            this.ProgrammerPhotoButton.UseVisualStyleBackColor = true;
            this.ProgrammerPhotoButton.Click += new System.EventHandler(this.PhotoButton_Click);
            // 
            // UniversityPicture
            // 
            this.UniversityPicture.BackgroundImage = global::SecurityInformation.Properties.Resources.UniversityPhoto;
            resources.ApplyResources(this.UniversityPicture, "UniversityPicture");
            this.UniversityPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UniversityPicture.ErrorImage = global::SecurityInformation.Properties.Resources.NotFound;
            this.UniversityPicture.Name = "UniversityPicture";
            this.UniversityPicture.TabStop = false;
            this.UniversityPicture.Click += new System.EventHandler(this.UniversityPicture_Click);
            // 
            // AboutUs
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CausesValidation = false;
            this.Controls.Add(this.ProgrammerPhotoButton);
            this.Controls.Add(this.TaskTwoLabel);
            this.Controls.Add(this.UniversityNameLabel);
            this.Controls.Add(this.UniversityLabel);
            this.Controls.Add(this.UniversityPicture);
            this.Controls.Add(this.TaskOneLabel);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.GroupNameLabel);
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.StudentLabel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutUs";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.UniversityPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Label TaskOneLabel;
        private System.Windows.Forms.Label TaskLabel;
        private Emgu.CV.UI.ImageBox UniversityPicture;
        private System.Windows.Forms.Label UniversityNameLabel;
        private System.Windows.Forms.Label UniversityLabel;
        private System.Windows.Forms.Label TaskTwoLabel;
        private System.Windows.Forms.Button ProgrammerPhotoButton;
    }
}