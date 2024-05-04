namespace WindowsFormsApp1
{
    partial class FaceDetection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceDetection));
            this.CameraPictureBox = new System.Windows.Forms.PictureBox();
            this.FaceDetectionButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraPictureBox
            // 
            this.CameraPictureBox.BackColor = System.Drawing.SystemColors.MenuBar;
            resources.ApplyResources(this.CameraPictureBox, "CameraPictureBox");
            this.CameraPictureBox.Name = "CameraPictureBox";
            this.CameraPictureBox.TabStop = false;
            // 
            // FaceDetectionButton
            // 
            this.FaceDetectionButton.AutoEllipsis = true;
            this.FaceDetectionButton.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.FaceDetectionButton, "FaceDetectionButton");
            this.FaceDetectionButton.Name = "FaceDetectionButton";
            this.FaceDetectionButton.UseCompatibleTextRendering = true;
            this.FaceDetectionButton.UseMnemonic = false;
            this.FaceDetectionButton.UseVisualStyleBackColor = true;
            this.FaceDetectionButton.Click += new System.EventHandler(this.FaceDetectionButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseCompatibleTextRendering = true;
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FaceDetection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.BackgroundPhoto;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FaceDetectionButton);
            this.Controls.Add(this.CameraPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaceDetection";
            this.Load += new System.EventHandler(this.FaceDetection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraPictureBox;
        private System.Windows.Forms.Button FaceDetectionButton;
        private System.Windows.Forms.Button CloseButton;
    }
}

