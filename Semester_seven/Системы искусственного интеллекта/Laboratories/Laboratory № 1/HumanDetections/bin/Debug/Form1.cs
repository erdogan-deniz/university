using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Emgu.CV.Capture capture = new Emgu.CV.Capture();
            capture.Start();

            //HaarCascade faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
            HaarCascade haaryuz = new HaarCascade("C:\\Users\\Deniz\\source\\repos\\WindowsFormsApp1\\haarcascade_frontalface_default.xml");
            HaarCascade haargoz = new HaarCascade("C:\\Users\\Deniz\\source\\repos\\WindowsFormsApp1\\haarcascade_eye.xml");
            HaarCascade haaragiz = new HaarCascade("C:\\Users\\Deniz\\source\\repos\\WindowsFormsApp1\\haarcascade_mcs_mouth.xml");
            HaarCascade haarburun = new HaarCascade("C:\\Users\\Deniz\\source\\repos\\WindowsFormsApp1\\haarcascade_mcs_nose.xml");

            capture.ImageGrabbed += (x, y) =>
            {
                var image = capture.RetrieveBgrFrame();
                if (image != null)
                {
                    //Elde edilen kamera görüntüsü Image<Gray, byte> nesnesine convert ediliyor.
                    var grayimage = image.Convert<Gray, byte>();

                    //grayimage nesnemizde DetectHaarCascade metodu aracılığıyla HaarCascade
                    //nesnesinde tutulan cascade aranmaktadır.
                    MCvAvgComp[][] Yuzler = grayimage.DetectHaarCascade(haaryuz, 1.2, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Gozler = grayimage.DetectHaarCascade(haargoz, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Agizlar = grayimage.DetectHaarCascade(haaragiz, 1.2, 100, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvAvgComp[][] Burunlar = grayimage.DetectHaarCascade(haarburun, 1.2, 50, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));

                    //Bulunan tüm nesnelerin koordinatları elde edilip gerekli çizim
                    //işlemi gerçekleştirilmektedir.
                    foreach (MCvAvgComp yuz in Yuzler[0])
                        image.Draw(yuz.rect, new Bgr(Color.Red), 2);
                    foreach (MCvAvgComp goz in Gozler[0])
                        image.Draw(goz.rect, new Bgr(Color.Black), 2);
                    foreach (MCvAvgComp agiz in Agizlar[0])
                        image.Draw(agiz.rect, new Bgr(Color.Blue), 2);
                    foreach (MCvAvgComp burun in Burunlar[0])
                        image.Draw(burun.rect, new Bgr(Color.Yellow), 2);
                }
                pictureBox1.Image = image.ToBitmap();
            };
        }
    }
}
