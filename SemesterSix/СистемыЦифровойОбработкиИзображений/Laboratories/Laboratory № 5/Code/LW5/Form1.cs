using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LW5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int w, jp = 0;
        int h;

        private Bitmap start;
        private Bitmap finish;
        private Bitmap Fstart;
        private Bitmap Ffinish;


        private void button1_Click(object sender, EventArgs e)
        {
            var opd = new OpenFileDialog();// Создает окно открытия файла
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;//Размещает по всей ширине объекта
            if (opd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opd.FileName);
                pictureBox2.BackColor = Color.Transparent;
            }

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label2.Visible = true;
            numericUpDown1.Visible = true;
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            maskedTextBox3.Text = "0";
            maskedTextBox4.Text = "0";
            comboBox1.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            furie();
            jp = 1;


        }
        int nud1 = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != nud1) { furieObraz(); nud1 = (int)numericUpDown1.Value; }
            comboBox1_SelectedIndexChanged(sender, e);
            var ui = comboBox1.SelectedIndex;
            if (ui > -1) circle(ui);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            maskedTextBox1.Visible = true;
            maskedTextBox2.Visible = true;
            maskedTextBox3.Visible = true;
            var ui =  comboBox1.SelectedIndex;
            if (ui == 0) { label6.Visible = false; maskedTextBox4.Visible = false; label1.Visible = false; numericUpDown4.Visible = false; }
            if (ui == 1) { label6.Visible = false; maskedTextBox4.Visible = false; label1.Visible = false; numericUpDown4.Visible = false; }
            if (ui == 2) { label6.Visible = true; maskedTextBox4.Visible = true; label1.Visible = false; numericUpDown4.Visible = false; }
            if (ui == 3) { label6.Visible = true; maskedTextBox4.Visible = true; label1.Visible = false; numericUpDown4.Visible = false; }
            if (ui == 4) { label6.Visible = true; maskedTextBox4.Visible = true; label1.Visible = true; numericUpDown4.Visible = true; }
            if (ui == 5) { label6.Visible = true; maskedTextBox4.Visible = true; label1.Visible = true; numericUpDown4.Visible = true; }
            
        }


        Complex[] DFT(Complex[] x, double n1)
        {
            int N = x.Length;
            Complex[] G = new Complex[N];
            for (int u = 0; u < N; ++u)
            {
                for (int v = 0; v < N; ++v)
                {
                    double fi = -2.0 * Math.PI * u * v / N;
                    G[u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * x[v]);
                }
                G[u] = n1 * G[u];
            }
            return G;

        }


        Complex[] fr;
        Complex[] fb;
        Complex[] fg;
        Complex[,] fr1;
        Complex[,] fb1;
        Complex[,] fg1;
        void furie()
        {
            var NImg = (Bitmap)pictureBox2.Image;
            w = NImg.Width;
            h = NImg.Height;
            int ki = 40;
            int h1 = 380;
            int w1 = 280;
            double[,] iznr = new double[w, h];
            double[,] izng = new double[w, h];
            double[,] iznb = new double[w, h];
            Complex[,] fiznr = new Complex[w, h];
            Complex[,] fizng = new Complex[w, h];
            Complex[,] fiznb = new Complex[w, h];
            Complex[,] fiznr1 = new Complex[h, w];
            Complex[,] fizng1 = new Complex[h, w];
            Complex[,] fiznb1 = new Complex[h, w];


            if (jp == 0)
            {
                fr = new Complex[w * h];
                fb = new Complex[w * h];
                fg = new Complex[w * h];
                fr1 = new Complex[h, w];
                fb1 = new Complex[h, w];
                fg1 = new Complex[h, w];
                start = new Bitmap(w, h);
                finish = new Bitmap(w, h);
                Fstart = new Bitmap(w, h);
                Ffinish = new Bitmap(w, h);

                for (int i = 0; i < h; ++i)
                {
                    for (int j = 0; j < w; ++j)
                    {
                        var pix = NImg.GetPixel(j, i);
                        int r = pix.R;
                        int g = pix.G;
                        int b = pix.B;
                        iznr[j, i] = r * Math.Pow(-1, i + j);
                        izng[j, i] = g * Math.Pow(-1, i + j);
                        iznb[j, i] = b * Math.Pow(-1, i + j);
                        start.SetPixel(j, i, pix);

                    }
                }
                for (int i = 0; i < h; ++i)
                {
                    for (int j = 0; j < w; ++j)
                    {
                        Fstart.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                        Ffinish.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                    }
                }

                for (int i = 0; i < h; ++i)
                {
                    double[] diznr = new double[w];
                    double[] dizng = new double[w];
                    double[] diznb = new double[w];
                    for (int j = 0; j < w; ++j)
                    {
                        diznr[j] = iznr[j, i];
                        dizng[j] = izng[j, i];
                        diznb[j] = iznb[j, i];
                    }

                    var c_iznr = diznr.Select(x => new Complex(x, 0)).ToArray();
                    var c_iznb = diznb.Select(x => new Complex(x, 0)).ToArray();
                    var c_izng = dizng.Select(x => new Complex(x, 0)).ToArray();
                    var fur = DFT(c_iznr, 1.0 / w);
                    var fub = DFT(c_iznb, 1.0 / w);
                    var fug = DFT(c_izng, 1.0 / w);

                    for (int j = 0; j < w; ++j)
                    {
                        fiznr[j, i] = fur[j];
                        fizng[j, i] = fug[j];
                        fiznb[j, i] = fub[j];
                    }
                }


                for (int i = 0; i < h; ++i)
                {
                    for (int j = 0; j < w; ++j)
                    {
                        fiznr1[i, j] = fiznr[j, i];
                        fiznb1[i, j] = fiznb[j, i];
                        fizng1[i, j] = fizng[j, i];
                    }
                }

                for (int i = 0; i < w; ++i)
                {
                    Complex[] diznr = new Complex[h];
                    Complex[] diznb = new Complex[h];
                    Complex[] dizng = new Complex[h];
                    for (int j = 0; j < h; ++j)
                    {
                        diznr[j] = fiznr1[j, i];
                        diznb[j] = fiznb1[j, i];
                        dizng[j] = fizng1[j, i];
                    }

                    var fur = DFT(diznr, 1.0 / h);
                    var fub = DFT(diznb, 1.0 / h);
                    var fug = DFT(dizng, 1.0 / h);
                    

                    for (int j = 0; j < h; ++j)
                    {
                        fr1[j, i] = fur[j];
                        fb1[j, i] = fub[j];
                        fg1[j, i] = fug[j];
                        fr[i + j * w] = fur[j];
                        fb[i + j * w] = fub[j];
                        fg[i + j * w] = fug[j];
                    }
                }
            }

            furieObraz();

        }



        double color(double c)
        {
            double ty = c;
            if (c > 255) { ty = 255; }
            if (c < 0) ty = 0;
            return ty;
        }

        void furieObraz()
        {
            var NImg = (Bitmap)pictureBox2.Image;
            w = NImg.Width;
            h = NImg.Height;
            double[,] iznr = new double[w, h];
            double[,] izng = new double[w, h];
            double[,] iznb = new double[w, h];
            int[] yr = new int[w * h];
            int[] yb = new int[w * h];
            int[] yg = new int[w * h];
            Complex[] fr=new Complex[w*h];
            Complex[] fb = new Complex[w * h];
            Complex[] fg = new Complex[w * h];
            int cg = 0;
            for(int i=0;i<h;i++)
                for(int j=0;j<w;j++)
                {
                    fr[cg] = fr1[i, j];
                    fb[cg] = fb1[i, j];
                    fg[cg] = fg1[i, j];
                    cg++;
                }


            double er = (int)(numericUpDown1.Value);
            var mar = fr[1].Real;
            var mag = fg[1].Real;
            var mab = fb[1].Real;
            //Чисто визуализация
            for (int i = 0; i < fr.Length; i++)
            {
                var gh = Math.Log(fr[i].Imaginary + 1);
                if (gh > mar) mar = gh;
                gh = Math.Log(fb[i].Imaginary + 1);
                if (gh > mab) mab = gh;
                gh = Math.Log(fg[i].Imaginary + 1);
                if (gh > mag) mag = gh;

            }
            var po = 255.0 / er;
            var gi = 1.0;
            if (po < 100) { gi = gi +  0.5* er; }
            for (int i = 0; i < w * h; ++i)
            {
                yr[i] = (int)color(gi * Math.Log(fr[i].Magnitude + 1) * 255 / mar);
                yb[i] = (int)color(gi * Math.Log(fb[i].Magnitude + 1) * 255 / mab);
                yg[i] = (int)color(gi * Math.Log(fg[i].Magnitude + 1) * 255 / mag);
                
            }
            yr = yr.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();
            yb = yb.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();
            yg = yg.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();

            for (int j = 0; j < h; ++j)
            {
                for (int i = 0; i < w; ++i)
                {
                    iznr[i, j] = yr[i + j * w];
                    iznb[i, j] = yb[i + j * w];
                    izng[i, j] = yg[i + j * w];
                }
            }

            for (int j = 0; j < w; ++j)
            {
                for (int i = 0; i < h; ++i)
                {
                    var pix = Fstart.GetPixel(j, i);
                    int r = (int)iznr[j, i];
                    int b = (int)iznb[j, i];
                    int g = (int)izng[j, i];
                    Ffinish.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            //Размещает по всей ширине объекта
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Ffinish;


        }


        void circle(int ui)
        {

            int rt = 0;//область выделения вне и внутри
            int rb = 0;
            double grad = 0;
            int povt = 1;
            pictureBox1.Invalidate();
            pictureBox1.Update();
            Graphics grGis;

            int widt2 = w / 2;
            int heit2 = h / 2;
            int xc = Convert.ToInt32(maskedTextBox1.Text);
            int yc = Convert.ToInt32(maskedTextBox2.Text)*(-1);
            if (ui % 2 == 0) { rt = 0; rb = 255; }
            if (ui % 2 == 1) { rt = 255; rb = 0; }
            int x1 = (int)(xc  + widt2);
            int y1 = (int)(yc  + heit2);
            int r1 = Convert.ToInt32(maskedTextBox3.Text);
            int r2 = 0;
            if (ui > 1) 
            { 
                r2 = Convert.ToInt32(maskedTextBox4.Text);
                if (r2 > r1) (r1, r2) = (r2, r1);
            }
            double[,] mass1 = new double[w, h];
            for (int j = 0; j < h; ++j)
            {
                for (int i = 0; i < w; ++i)
                {
                    mass1[i, j] = rt;
                }
            }
            for (int fg = 1; fg <= povt; fg++)
            {
                if (ui > 3)
                {
                    double ug = 0; 
                    double rad = Math.PI / 180;
                    int hul = 0;
                    if (xc == 0) { xc = 1; hul = 1; }
                    if (yc <=0 && xc>=0) { ug = ((Math.Atan(Math.Abs(yc / xc)) * 180 / Math.PI)); }
                    if (yc <= 0 && xc <= 0) { ug = (180- (Math.Atan(Math.Abs(yc / xc)) * 180 / Math.PI)); }
                    if (yc >= 0 && xc <= 0) { ug = (180+ (Math.Atan(Math.Abs(yc / xc)) * 180 / Math.PI)); }
                    if (yc >= 0 && xc >= 0) { ug = (360- (Math.Atan(Math.Abs(yc / xc)) * 180 / Math.PI)); }
                    if (hul == 1) { xc = 0; hul = 0; }
                    povt = (int)numericUpDown4.Value;
                    grad = (((360 / (int)numericUpDown4.Value)*fg+ug)%360 )* rad;
                    x1 = (int)(Math.Abs(xc) * (Math.Cos(grad)) + widt2);
                    y1 = (int)(Math.Abs(xc) * (Math.Sin(grad)) + heit2);
                }

                int ys = (y1 - r1);if(ys<0) ys = 0;
                int yf = (y1 + r1);if (yf > h) yf = h;
                int xp = (x1 - r1);if (xp<0) xp = 0;
                int xv= (x1 + r1);if (xv>w) xv = w ;
                

                for (int j = ys; j < yf; ++j)
                {
                    int xf = 0, xs = 0;
                    if (j >= ys)
                    {
                        int jr = Math.Abs(y1 - j);
                        int re = (int)Math.Sqrt(r1 * r1 - jr * jr);
                        xs = Math.Abs(re - x1);
                        xf = re + x1;
                    }

                    for (int i = xp; i < xv; ++i)
                    {
                        mass1[i, j] = rt;
                        if (i > xs && i < xf) { mass1[i, j] = rb; }

                    }
                }
                if (ui > 1)
                {
                    for (int j = ys; j < yf; ++j)
                    {
                        int xf = 0, xs = 0;
                        if (j >= ys)
                        {
                            int jr = Math.Abs(y1 - j);
                            int re = (int)Math.Sqrt(r2 * r2 - jr * jr);
                            xs = Math.Abs(re - x1);
                            xf = re + x1;
                        }

                        for (int i = xp; i < xv; ++i)
                        {
                            if (i > xs && i < xf) { mass1[i, j] = rt; }
                        }
                    }
                }

                
               
                var iopl = pictureBox1;
                int wu = iopl.Width / w;
                int hu = iopl.Height / h;
                int sm = (wu + hu) / 2;
                if (wu < hu) { sm = wu; } else { sm = hu; }
                int xr = iopl.Width / 2 + sm * (x1-widt2);
                int yr = iopl.Height / 2 + sm * (y1-heit2);
                int rw1 = r1 * sm;
                int rm1 = r1 * sm;
                int rw2 = r2 * sm;
                int rm2 = r2 * sm;

                
                grGis = pictureBox1.CreateGraphics();
                if (r1 > 0) grGis.DrawEllipse(Pens.Red, xr - rw1, yr - rw1, rm1 * 2, rm1 * 2);
                if (r2 > 0) { grGis.DrawEllipse(Pens.Red, xr - rw2, yr - rw2, rm2 * 2, rm2 * 2); }
            }


            Bitmap NImg = new Bitmap(w, h);
            for (int j = 0; j < w; ++j)
            {
                for (int i = 0; i < h; ++i)
                {
                    int r = (int)mass1[j, i];
                    int b = (int)mass1[j, i];
                    int g = (int)mass1[j, i];
                    NImg.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            //Размещает по всей ширине объекта
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = NImg;
            Complex[,] mass2r = new Complex[h, w];
            Complex[,] mass2b = new Complex[h, w];
            Complex[,] mass2g = new Complex[h, w];

            int ci = 0;
            for (int i = 0; i < h; ++i) 
            {
               for (int j = 0; j < w; ++j)
               {
                    if (mass1[j, i] == 0)
                    {
                        mass2r[i, j] = 0;
                        mass2b[i, j] = 0;
                        mass2g[i, j] = 0;
                    }
                    else
                    {
                        mass2r[i, j] = fr1[i,j];
                        mass2b[i, j] = fb1[i,j];
                        mass2g[i, j] = fg1[i,j];
                    }
                    ci++;
                }
            }

            furie2(mass2r, mass2b, mass2g);
        }

        void furie2(Complex[,] mass2r, Complex[,] mass2b, Complex[,] mass2g)
        {
            double[,] nr = new double[w,h];
            double[,] ng = new double[w,h];
            double[,] nb = new double[w,h];
            Complex[,] fiznr = new Complex[h, w];
            Complex[,] fizng = new Complex[h, w];
            Complex[,] fiznb = new Complex[h, w];
            Complex[,] fiznr1 = new Complex[w, h];
            Complex[,] fizng1 = new Complex[w, h];
            Complex[,] fiznb1 = new Complex[w, h];
            for (int j = 0; j < w; ++j)
            {
                Complex[] diznr = new Complex[h];
                Complex[] dizng = new Complex[h];
                Complex[] diznb = new Complex[h];
                for (int i = 0; i < h; ++i)
                {
                    diznr[i] = mass2r[i, j];
                    dizng[i] = mass2g[i, j];
                    diznb[i] = mass2b[i, j];
                }
                diznr = diznr.Select(x1 => new Complex(x1.Real, x1.Imaginary*(-1.0))).ToArray();
                diznb = diznb.Select(x1 => new Complex(x1.Real, x1.Imaginary * (-1.0))).ToArray();
                dizng = dizng.Select(x1 => new Complex(x1.Real, x1.Imaginary * (-1.0))).ToArray();
                var fur = DFT(diznr, 1.0 );
                var fub = DFT(diznb, 1.0 );
                var fug = DFT(dizng, 1.0 );

                for (int i = 0; i <h; ++i)
                {
                    fiznr[i, j] = fur[i];
                    fizng[i, j] = fug[i];
                    fiznb[i, j] = fub[i];
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    fiznr1[i, j] = fiznr[j, i];
                    fiznb1[i, j] = fiznb[j, i];
                    fizng1[i, j] = fizng[j, i];
                }
            }

            for (int j = 0; j < h; ++j)
            {
                Complex[] diznr = new Complex[w];
                Complex[] diznb = new Complex[w];
                Complex[] dizng = new Complex[w];
                for (int i = 0; i < w; ++i)
                {
                    diznr[i] = fiznr1[i, j];
                    diznb[i] = fiznb1[i, j];
                    dizng[i] = fizng1[i, j];
                }

                var fur = DFT(diznr, 1.0 );
                var fub = DFT(diznb, 1.0 );
                var fug = DFT(dizng, 1.0 );

                for (int i = 0; i < w; ++i)
                {
                    nr[i , j] = fur[i].Real * Math.Pow(-1,i+j) ;
                    nb[i , j] = fub[i].Real * Math.Pow(-1, i + j);
                    ng[i , j] = fug[i].Real * Math.Pow(-1, i + j);
                }
            }

            Bitmap Ghimg = new Bitmap(w,h);
            for (int j = 0; j < w; ++j)
              {
                    for (int i = 0; i < h; ++i)
                    {
                        int r = (int)color(Math.Abs(nr[j, i]));
                        int b = (int)color(Math.Abs(nb[j, i]));
                        int g = (int)color(Math.Abs(ng[j, i]));
                        Ghimg.SetPixel(j, i, Color.FromArgb(r, g, b));
                    }
                }
                //Размещает по всей ширине объекта
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = Ghimg;


        }



    }
}
