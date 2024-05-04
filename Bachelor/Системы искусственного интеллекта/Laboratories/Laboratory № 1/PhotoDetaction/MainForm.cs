using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;


namespace PhotoDetaction
{
    public partial class MainForm : Form
    {
        private static readonly CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        public MainForm()  // CREATE WINDOW AND HIDE PICTURE BOX
        {
            InitializeComponent();
        }

        private void RecognizeButton_Click(object sender, EventArgs e)  // RECOGNIZE FACE ON PHOTO
        {
            try  // TRY TO START PROGRAMM
            {
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;
                    PhotoPictureBox.Image = Image.FromFile(path);
                    Bitmap bitmap = new Bitmap(PhotoPictureBox.Image);
                    Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
                    Rectangle[] faces = classifier.DetectMultiScale(grayImage, 1.2, 0);

                    this.PhotoPictureBox.Show();

                    foreach (Rectangle face in faces) 
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (Pen pen = new Pen(Color.Red, 5))
                            {
                                graphics.DrawRectangle(pen, face);
                            }
                        }
                    }

                    PhotoPictureBox.Image = bitmap;
                }
                else 
                {
                    MessageBox.Show("INCORRECT CHOOSE!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)  // HIDE PICTURE BOX
        {
            this.PhotoPictureBox.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)  // CLOSE APPLICATION
        {
            Application.Exit();
        }
    }
}
