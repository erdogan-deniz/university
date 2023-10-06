using System.Diagnostics;
using System.Windows.Forms;

namespace SecurityInformation
{
    public partial class AboutUs : System.Windows.Forms.Form
    {
        public AboutUs()  // SET PAGE PREFERENCE
        {
            this.TopMost = true;
            _ = new OpenFileDialog();
            InitializeComponent();
        }

        private void PhotoButton_Click(object sender, System.EventArgs e)  // PROGRAMMER GITHUB LINK
        {
            Process.Start("https://github.com/Denzi33");
        }

        private void UniversityPicture_Click(object sender, System.EventArgs e)  // UNIVERSITY LINK
        {
            Process.Start("https://stankin.ru/");
        }
    }
}
