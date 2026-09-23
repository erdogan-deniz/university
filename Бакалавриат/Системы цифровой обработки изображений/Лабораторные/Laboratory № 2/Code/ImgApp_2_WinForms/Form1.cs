using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace Lab2
{
    public partial class Form1 : Form
    {
        private List<Point> controlPoints = new List<Point>();
        private List<Point> bezie_points = new List<Point>();
        private Graphics g;
        private Pen pen = new Pen(Color.Blue);

        public Point[] points = new Point[256];

        private Bitmap image = null;
        private Bitmap image2 = null;
        private Bitmap image3 = null;
        private Bitmap HistImg = new Bitmap(256, 138);
        private Bitmap HistImgRed = new Bitmap(256, 138);
        private Bitmap HistImgGreen = new Bitmap(256, 138);
        private Bitmap HistImgBlue = new Bitmap(256, 138);
        private Bitmap HistImgPrev = new Bitmap(256, 138);

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = image;
            pictureBoxGraph.Image = new Bitmap(256, 256);
            g = Graphics.FromImage(pictureBoxGraph.Image);
            g.Clear(Color.White);
            controlPoints.Add(new Point(0, 128));
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog  = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, jpeg, bmp, gif) |*.png;*.jpg;*.jpeg:*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    image.Dispose();
                }

                image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image;
                image2 = image;
                image3= image;
                Histo();
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, jpeg, bmp, gif) |*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image2 != null)
                {
                    image2.Save(saveFileFialog.FileName);
                }
            }
        }

        private void makeChart()
        {
            for (double x = 0; x < 256; x += 1)
            {
                double y = BezierCoordinate(bezie_points, x);
                Point p = new Point((int)x, (int)y);
                points[(int)x] = p;
            }

            for(int i=0;i<240;i+=10)
            {
                Point p = new Point(points[i].X, points[i].Y);
            }
        }

        private void chart_draw_Click(object sender, EventArgs e)
        {
            foreach (Point p in controlPoints) 
            {
                bezie_points.Add(new Point((p.X * 2), (128 - p.Y) * 2));
            }
            controlPoints.Add(new Point(128, 0));
            bezie_points.Add(new Point(256, 256));
            g.DrawEllipse(pen, 128, 0, 4, 4);
            pictureBoxGraph.Invalidate();
            DrawBezierSpline();
            makeChart();
        }

        private void Histo() //Рисовалка гистограммы
        {
            pictureBox3.Image = pictureBox2.Image;
            int[] N = new int[256];
            int[] _R = new int[256];
            int[] _G = new int[256];
            int[] _B = new int[256];
            double max = 0;
            for (int height = 0; height < image2.Height; height++)
            {
                for (int width = 0; width < image2.Width; width++)
                {
                    int c = image2.GetPixel(width, height).R + image2.GetPixel(width, height).G + image2.GetPixel(width, height).B;
                    c = c / 3;
                    N[c]++;
                    if (max< N[c]) max = N[c];
                }
            }
            double K = 128;
            HistImg = new Bitmap(256, 138);
            HistImgRed = new Bitmap(256, 138);
            HistImgGreen = new Bitmap(256, 138);
            HistImgBlue = new Bitmap(256, 138);
            using (Graphics g = Graphics.FromImage(HistImg))
            {
                for (int i = 0; i < N.Length; i++)
                {
                    double pct = N[i] / max;   // What percentage of the max is this value?
                    Point A = new Point(i, HistImg.Height - 5);
                    Point B = new Point(i, HistImg.Height - 5 - (int)(K * pct));
                    g.DrawLine(Pens.Black, A, B);  // Use that percentage of the height
                }
            }

            if(checkBox1.Checked==true)
            {
                double _max = 0;
                for (int height = 0; height < image2.Height; height++)
                {
                    for (int width = 0; width < image2.Width; width++)
                    {
                        int cr = image2.GetPixel(width, height).R;
                        _R[cr]++;
                        if (_max < _R[cr]) _max = _R[cr];
                    }
                }
                K = 128;
                using (Graphics g = Graphics.FromImage(HistImgRed))
                {
                    for (int i = 0; i < _R.Length; i++)
                    {
                        double pct = _R[i] / _max;   // What percentage of the max is this value?
                        Point A = new Point(i, HistImgRed.Height - 5);
                        Point B = new Point(i, HistImgRed.Height - 5 - (int)(K * pct));
                        g.DrawLine(Pens.Red, A, B);  // Use that percentage of the height
                    }
                }
                HRed.Image = HistImgRed;
                HRed.Refresh();
            }

            if (checkBox2.Checked == true)
            {
                double _max = 0;
                for (int height = 0; height < image2.Height; height++)
                {
                    for (int width = 0; width < image2.Width; width++)
                    {
                        int cr = image2.GetPixel(width, height).G;
                        _G[cr]++;
                        if (_max < _G[cr]) _max = _G[cr];
                    }
                }
                K = 128;
                using (Graphics g = Graphics.FromImage(HistImgGreen))
                {
                    for (int i = 0; i < _G.Length; i++)
                    {
                        double pct = _G[i] / _max;   // What percentage of the max is this value?
                        Point A = new Point(i, HistImgGreen.Height - 5);
                        Point B = new Point(i, HistImgGreen.Height - 5 - (int)(K * pct));
                        g.DrawLine(Pens.Green, A, B);  // Use that percentage of the height
                    }
                }
                hGrn.Image = HistImgGreen;
                hGrn.Refresh();
            }

            if (checkBox3.Checked == true)
            {
                double _max = 0;
                for (int height = 0; height < image2.Height; height++)
                {
                    for (int width = 0; width < image2.Width; width++)
                    {
                        int cr = image2.GetPixel(width, height).B;
                        _B[cr]++;
                        if (_max < _B[cr]) _max = _B[cr];
                    }
                }
                K = 128;
                using (Graphics g = Graphics.FromImage(HistImgBlue))
                {
                    for (int i = 0; i < _B.Length; i++)
                    {
                        double pct = _B[i] / _max;  // What percentage of the max is this value?
                        Point A = new Point(i, HistImgBlue.Height - 5);
                        Point B = new Point(i, HistImgBlue.Height - 5 - (int)(K * pct));
                        g.DrawLine(Pens.Blue, A, B);  // Use that percentage of the height
                    }
                }
                hBlu.Image = HistImgBlue;
                hBlu.Refresh();
            }

            pictureBox2.Image = HistImg;
            pictureBox2.Refresh();
            pictureBox3.Refresh();
        }

        public static double BezierCoordinate(List<Point> points, double x) // Безье
        {
            double y = 0;
            double t = 0;

            for (int i = 0; i < 1000; i++)
            {
                if (x <= points[0].X)
                {
                    y = points[0].Y;
                    break;
                }

                if (x >= points[3].X)
                {
                    y = points[3].Y;
                    break;
                }

                if (x >= points[1].X && x <= points[2].X)
                {
                    t = (x - points[0].X) / (points[3].X - points[0].X);
                    y = Math.Pow(1 - t, 3) * points[0].Y +
                        3 * t * Math.Pow(1 - t, 2) * points[1].Y +
                        3 * Math.Pow(t, 2) * (1 - t) * points[2].Y +
                        Math.Pow(t, 3) * points[3].Y;
                    break;
                }

                if (x <= points[1].X)
                {
                    t = (x - points[0].X) / (points[3].X - points[0].X);
                    y = Math.Pow(1 - t, 3) * points[0].Y +
                        3 * t * Math.Pow(1 - t, 2) * points[1].Y +
                        3 * Math.Pow(t, 2) * (1 - t) * points[2].Y +
                        Math.Pow(t, 3) * points[3].Y;
                    break;
                }

                if (x >= points[2].X)
                {
                    t = (x - points[0].X) / (points[3].X - points[0].X);
                    y = Math.Pow(1 - t, 3) * points[0].Y +
                        3 * t * Math.Pow(1 - t, 2) * points[1].Y +
                        3 * Math.Pow(t, 2) * (1 - t) * points[2].Y +
                        Math.Pow(t, 3) * points[3].Y;
                    break;
                }
            }

            return y;
        }

        private void bDraw_Click_1(object sender, EventArgs e) //Изменяем основную картинку
        {
            if (image != null)
            {

                for (int width = 0; width < image.Width; width++)
                {
                    for (int heigth = 0; heigth < image.Height; heigth++)
                    {
                        int R = Math.Abs(points[image.GetPixel(width, heigth).R].Y);
                        int G = Math.Abs(points[image.GetPixel(width, heigth).G].Y);
                        int B = Math.Abs(points[image.GetPixel(width, heigth).B].Y);
                        if (R > 255)
                            R = 255;
                        if (G > 255)
                            G = 255;
                        if (B > 255)
                            B = 255;
                        Color c3 = Color.FromArgb(R, G, B);
                        image2.SetPixel(width, heigth, c3);

                    }
                }

                Histo();
                pictureBox1.Image = image2;
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e) //Рисуем гистыч
        {
            Histo();
        }

        private void pictureBoxGraph_MouseClick(object sender, MouseEventArgs e) //Ставим точки на график
        {
            // Добавляем новую контрольную точку
            controlPoints.Add(new Point(e.X, e.Y));
            // Рисуем точку на изображении
            g.DrawEllipse(pen, e.X - 2, e.Y - 2, 4, 4);

            // Перерисовываем изображение
            pictureBoxGraph.Invalidate();

            // Если у нас есть достаточное количество контрольных точек, рисуем сплайн Безье
            if (controlPoints.Count ==3)
            {
                controlPoints.Add(new Point(128, 0));
                foreach (Point p in controlPoints)
                {
                    bezie_points.Add(new Point((p.X * 2), (128 - p.Y) * 2));
                }

                g.DrawEllipse(pen, 128, 0, 4, 4);
                pictureBoxGraph.Invalidate();
                DrawBezierSpline();
                makeChart();
            }
        }

        private void DrawBezierSpline()
        {
            // Создаем массив точек для сплайна Безье
            Point[] bpoints = controlPoints.ToArray();

            // Рисуем сплайн Безье на изображении
            g.DrawBeziers(pen, bpoints);

            // Перерисовываем изображение
            pictureBox1.Invalidate();
        }

        private void dropCurve_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            bezie_points.Clear();
            controlPoints.Add(new Point(0, 128));
            g.Clear(Color.White);
            pictureBoxGraph.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}