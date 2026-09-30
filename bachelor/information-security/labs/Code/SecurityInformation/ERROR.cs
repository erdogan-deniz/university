using System;
using System.Windows.Forms;

namespace SecurityInformation
{
    public partial class ErrorPage : System.Windows.Forms.Form
    {
        public ErrorPage()  // LOAD ERROR FORM
        {
            this.TopMost = true;
            InitializeComponent();
        }

        public void GetData(System.Drawing.Point Location)  // SET PREVIOUS FORM LOCATION
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;
        }

        public void ChangeLabelText(string text)  // SET ERROR TEXT
        {
            this.ErrorTextLabel.Text = text;
        }

        private void CloseButton_Click(object sender, EventArgs e)  // CLOSE BUTTON
        {
            this.Close();
        }
    }
}
