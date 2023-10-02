using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FaceDetection : Form
    {
        Emgu.CV.Capture capture = new Emgu.CV.Capture();

        public FaceDetection()  // FORM LOADS
        {
            InitializeComponent();
        }

        private void FaceDetection_Load(object sender, EventArgs e)  // AT START HIDE CAMERA BOX
        {
            this.CameraPictureBox.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)  // CLOSE APPLICATION
        {
            capture.Stop();
            System.Windows.Forms.Application.Exit();
        }

        private void FaceDetectionButton_Click(object sender, EventArgs e)  // START DETECTION
        {
            this.CameraPictureBox.Show();
            capture.Start();

            // OPEN XML CASCADES
            HaarCascade faceCascade = new HaarCascade("..\\..\\haarcascade_frontalface_default.xml");
            HaarCascade eyesCascad = new HaarCascade("..\\..\\haarcascade_eye.xml");
            HaarCascade mouthCascad = new HaarCascade("..\\..\\haarcascade_mcs_mouth.xml");
            HaarCascade headCascad = new HaarCascade("..\\..\\haarcascade_mcs_nose.xml");

            capture.ImageGrabbed += (x, y) =>
            {
                var image = capture.RetrieveBgrFrame();

                if (image != null)
                {
                    var grayImage = image.Convert<Gray, byte>();

                    // 	HaarCascade haarObj, double scaleFactor, int minNeighbors, HAAR_DETECTION_TYPE flag, Size minSize
                    MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(faceCascade, 1.1, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Eyes = grayImage.DetectHaarCascade(eyesCascad, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Mouths = grayImage.DetectHaarCascade(mouthCascad, 1.1, 100, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Noses = grayImage.DetectHaarCascade(headCascad, 1.1, 50, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));

                    foreach (MCvAvgComp face in Faces[0])
                        image.Draw(face.rect, new Bgr(Color.Red), 2);

                    foreach (MCvAvgComp eye in Eyes[0])
                        image.Draw(eye.rect, new Bgr(Color.Black), 2);

                    foreach (MCvAvgComp mouth in Mouths[0])
                        image.Draw(mouth.rect, new Bgr(Color.Blue), 2);

                    foreach (MCvAvgComp nose in Noses[0])
                        image.Draw(nose.rect, new Bgr(Color.Yellow), 2);
                }

                CameraPictureBox.Image = image.ToBitmap();
            };
        }
    }
}
