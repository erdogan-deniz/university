namespace PhotoDetaction
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.DetectionButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PhotoPictureBox
            // 
            this.PhotoPictureBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.PhotoPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.PhotoPictureBox.Name = "PhotoPictureBox";
            this.PhotoPictureBox.Size = new System.Drawing.Size(750, 430);
            this.PhotoPictureBox.TabIndex = 0;
            this.PhotoPictureBox.TabStop = false;
            // 
            // DetectionButton
            // 
            this.DetectionButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DetectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DetectionButton.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetectionButton.Location = new System.Drawing.Point(795, 314);
            this.DetectionButton.Margin = new System.Windows.Forms.Padding(0);
            this.DetectionButton.Name = "DetectionButton";
            this.DetectionButton.Size = new System.Drawing.Size(200, 50);
            this.DetectionButton.TabIndex = 1;
            this.DetectionButton.Text = "DETECTION";
            this.DetectionButton.UseMnemonic = false;
            this.DetectionButton.UseVisualStyleBackColor = false;
            this.DetectionButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG|*.jpg|PNG|*.png";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(795, 392);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(200, 50);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseMnemonic = false;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PhotoDetaction.Properties.Resources.BackgroundPhoto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1007, 453);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DetectionButton);
            this.Controls.Add(this.PhotoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1025, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1025, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHOTO DETACTION";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PhotoPictureBox;
        private System.Windows.Forms.Button DetectionButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ExitButton;
    }
}

