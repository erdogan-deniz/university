using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace LW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
//======================================Создание элементов=======================================================
        int iter = -1;
        List<Panel> PL = new List<Panel>();
        List<PictureBox> PB1 = new List<PictureBox>();
        List<PictureBox> PB2 = new List<PictureBox>();
        List<CheckBox> CBR = new List<CheckBox>();
        List<CheckBox> CBG = new List<CheckBox>();
        List<CheckBox> CBB = new List<CheckBox>();
        List<ComboBox> CB = new List<ComboBox>();
        List<TrackBar> TB = new List<TrackBar>();
        List<Button> BCl = new List<Button>();
        List<Button> BTop = new List<Button>();
        List<Button> BDown = new List<Button>();
        List<Label> Lab = new List<Label>();

        void NewPanel()  // Динамическое добавление объектов
        {
            panel1.Visible = true;
            pictureBox1.Visible = true;

            Panel nP = Clone(panel1);
            PL.Add(nP);
            flowLayoutPanel1.Controls.Add(nP);

            PictureBox nPB1 = new PictureBox();
            nPB1 = Clone(pictureBox1);
            nPB1.BackColor = Color.Transparent;
            PB1.Add(nPB1);
            this.panel2.Controls.Add(nPB1);
            nPB1.Parent = this.panel2;
            nPB1.BringToFront();


            PictureBox nPB2 = Clone(pictureBox2);
            PB2.Add(nPB2);
            nP.Controls.Add(nPB2);

            CheckBox nCBR = Clone(checkBox1);
            CBR.Add(nCBR);
            nP.Controls.Add(nCBR);
            CBR[iter].CheckedChanged += new System.EventHandler(this.CBR_CheckedChanged);

            CheckBox nCBG = Clone(checkBox2);
            CBG.Add(nCBG);
            nP.Controls.Add(nCBG);
            CBG[iter].CheckedChanged += new System.EventHandler(this.CBG_CheckedChanged);

            CheckBox nCBB = Clone(checkBox3);
            CBB.Add(nCBB);
            nP.Controls.Add(nCBB);
            CBB[iter].CheckedChanged += new System.EventHandler(this.CBB_CheckedChanged);


            ComboBox nCB = Clone(comboBox1);
            nCB.Items.AddRange(new string[] { "Нет", "Сумма", "Умножение", "Макс", "Мин", "Среднее" });
            nCB.SelectedIndex = 0;
            CB.Add(nCB);
            nP.Controls.Add(nCB);
            CB[iter].SelectedIndexChanged += new System.EventHandler(this.CB_SelectedIndexChanged);

            TrackBar nTB = Clone(trackBar1);
            TB.Add(nTB);
            nP.Controls.Add(nTB);
            TB[iter].Scroll += new System.EventHandler(this.TB_CheckedChanged);

            Button nBCl = Clone(button6);
            BCl.Add(nBCl);
            nP.Controls.Add(nBCl);
            BCl[iter].Click += new System.EventHandler(this.BCl_Click);

            Button nBTop = Clone(button5);
            BTop.Add(nBTop);
            nP.Controls.Add(nBTop);
            BTop[iter].Click += new System.EventHandler(this.BTop_Click);

            Button nBDown = Clone(button4);
            BDown.Add(nBDown);
            nP.Controls.Add(nBDown);
            BDown[iter].Click += new System.EventHandler(this.BDown_Click);

            Label nLab = Clone(label1);
            Lab.Add(nLab);
            nP.Controls.Add(nLab);

            panel1.Visible = false;
            pictureBox1.Visible = false;
        }

        public static T Clone<T>(T controlToClone) where T : Control
        {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo[] props = controlToClone.GetType().GetProperties();

            foreach (PropertyInfo pi in props)
            {
                if ((pi.CanWrite) && !(pi.Name == "WindowTarget") && !(pi.Name == "Capture"))
                {
                    pi.SetValue(instance, pi.GetValue(controlToClone, null), null);
                }
            }
            return instance;
        }
//======================================Обработка изображения, самописные коды===================================

        void new2sliv( int ju) //растягивает и увеличивает 2 изображения
        {
            if (ju > 0)
            {
                    int k, x, y, l = ju - 1;
                    if (ju == 3) 
                    { 
                        var tl = 0; 
                    }

                    var NImg1 = (Bitmap)PB1[ju].Image;
                    var NImg2 = (Bitmap)PB1[l].Image;
                    var w1 = NImg1.Width;
                    var h1 = NImg1.Height;
                    var w2 = NImg2.Width;
                    var h2 = NImg2.Height;
                    var pix = NImg1.GetPixel(1, 1);
                    
                if (w2 + h2 > w1 + h1) { k = (int)((w2 + h2) / (w1 + h1)); x = 2; } else { k = (int)((w1 + h1) / (w2 + h2)); x = 1; };
                    
                if(k>1)
                    {
                        var w3 = NImg1.Width;
                        var h3 = NImg1.Height;//
                        var w4 = NImg1.Width;
                        var h4 = NImg1.Height;
                        if (k > 0)
                        {
                            if (x == 1) { w3 = w2 * k; h3 = h2 * k; w4 = NImg2.Width; h4 = NImg2.Height; }//NImg1>NImg2
                            if (x == 2) { w3 = w1 * k; h3 = h1 * k; }// NImg2>NImg1
                            var PImg = new Bitmap(w3, h3);

                            for (int i = 0; i < h4; ++i)
                            {
                                for (int j = 0; j < w4; ++j)
                                {
                                    //считывыем пиксель картинки и получаем его цвет
                                    var pix1 = Color.FromArgb(0, 0, 0, 0);
                                    if (x == 1) { pix1 = NImg2.GetPixel(j, i); } else { pix1 = NImg1.GetPixel(j, i); }
                                    for (int hi = 0; hi < k; ++hi)
                                    {
                                        for (int lo = 0; lo < k; ++lo)
                                        {
                                            PImg.SetPixel((lo + j * k), (hi + i * k), pix1);
                                        }
                                    }
                                }
                            }
                            if (x == 1) { PB1[l].Image = PImg; }
                            if (x == 2) { PB1[ju].Image = PImg; }
                        }
                    }

                      var HImg1 = (Bitmap)PB1[ju].Image;
                      var HImg2 = (Bitmap)PB1[l].Image;
                      w1 = HImg1.Width;
                      h1 = HImg1.Height;
                      w2 = HImg2.Width;
                      h2 = HImg2.Height;
                      var wm = w1;
                      var hm = h1;
                      if (w1 < w2) { wm = w2; } else { wm = w1; }
                      if (h1 < h2) { hm = h2; } else { hm = h1; }

                        if (w2 < wm)
                        {
                            HImg2 = (Bitmap)PB1[l].Image;
                            w2 = HImg2.Width;
                            h2 = HImg2.Height;
                            var wr = (wm - w2) / 2;
                            var ZImg = new Bitmap(wm, h2);
                            for (int i = 0; i < h2; ++i)
                            {

                                for (int j = 0; j < wr; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0); ZImg.SetPixel(j, i, pix);
                                }
                            }
                            for (int i = 0; i < h2; ++i)
                            {
                                for (int j = 0; j < w2; ++j)
                                {
                                    pix = HImg2.GetPixel(j, i); ZImg.SetPixel(j + wr, i, pix);
                                }
                            }
                            for (int i = 0; i < h2; ++i)
                            {

                                for (int j = w2 + wr; j < wm; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0); ZImg.SetPixel(j, i, pix);
                                }
                            }
                            PB1[l].Image = ZImg;
                        }

                        if (h2 < hm)
                        {
                            HImg2 = (Bitmap)PB1[l].Image;
                            w2 = HImg2.Width;
                            h2 = HImg2.Height;
                            var hr = (hm - h2) / 2;
                            var ZImg = new Bitmap(w2, hm);

                            for (int i = 0; i < hr; ++i)
                            {
                                for (int j = 0; j < w2; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0); ZImg.SetPixel(j, i, pix);
                                }
                            }

                            for (int i = 0; i < h2; ++i)
                            {
                                for (int j = 0; j < w2; ++j)
                                {
                                    pix = HImg2.GetPixel(j, i); 
                                    ZImg.SetPixel(j, i + hr, pix);
                                }
                            }

                            for (int i = h2 + hr; i < hm; ++i)
                            {
                                for (int j = 0; j < w2; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0); 
                                    ZImg.SetPixel(j, i, pix);
                                }
                            }
                            PB1[l].Image = ZImg;
                        }

                        if (h1 < hm)
                        {
                            HImg1 = (Bitmap)PB1[ju].Image;
                            w1 = HImg1.Width;
                            h1 = HImg1.Height;
                            var hr = (hm - h1) / 2;
                            var ZImg = new Bitmap(w1, hm);

                            for (int i = 0; i < hr; ++i)
                            {
                                for (int j = 0; j < w1; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0);
                                    ZImg.SetPixel(j, i, pix);
                                }
                            }

                            for (int i = 0; i < h1; ++i)
                            {
                                for (int j = 0; j < w1; ++j)
                                {
                                    pix = HImg1.GetPixel(j, i);
                                    ZImg.SetPixel(j, i + hr, pix);
                                }
                            }

                            for (int i = h1 + hr; i < hm; ++i)
                            {
                                for (int j = 0; j < w1; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0);
                                    ZImg.SetPixel(j, i, pix);
                                }
                            }
                            PB1[ju].Image = ZImg;
                        }
                            
                        if (w1 < wm)
                        {
                            HImg1 = (Bitmap)PB1[ju].Image;
                            w1 = HImg1.Width;
                            h1 = HImg1.Height;
                            var wr = (wm - w1) / 2;
                            var ZImg = new Bitmap(wm, h1);
                            
                            for (int i = 0; i < h1; ++i)
                            {
                                for (int j = 0; j < wr; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0);
                                    ZImg.SetPixel(j, i, pix);
                                }
                            }

                            for (int i = 0; i < h1; ++i)
                            {
                                for (int j = 0; j < w1; ++j)
                                {
                                    pix = HImg1.GetPixel(j, i);
                                    ZImg.SetPixel(j + wr, i, pix);
                                }
                            }

                            for (int i = 0; i < h1; ++i)
                            {
                                for (int j = w1 + wr; j < wm; ++j)
                                {
                                    pix = Color.FromArgb(0, 0, 0, 0);
                                    ZImg.SetPixel(j, i, pix);
                                }
                            }
                            PB1[ju].Image = ZImg;
                        }
            }
        }

        void sum(int k, int ju) //comboBox: сумма произведение среднее и тд
        {
            if (ju>0)
            {
                int l = ju-1;
                var w1 = ((Bitmap)PB1[ju].Image).Width;
                var h1 = ((Bitmap)PB1[ju].Image).Height;
                var w2 = ((Bitmap)PB1[l].Image).Width;
                var h2 = ((Bitmap)PB1[l].Image).Height;
                if (w1 == w2 && h1 == h2)
                {
                    var NImg1 = (Bitmap)PB1[ju].Image;
                    var NImg2 = (Bitmap)PB1[l].Image;
                    w1 = NImg1.Width;
                    h1 = NImg1.Height;
                    w2 = NImg2.Width;
                    h2 = NImg2.Height;
                    var ZImg3 = new Bitmap(w1, h1);

                    for (int i = 0; i < h1; ++i)
                    {
                        for (int j = 0; j < w1; ++j)
                        {
                            var pix1 = NImg1.GetPixel(j, i);
                            var pix2 = NImg2.GetPixel(j, i);
                            if (pix1.A == 0)
                            {
                                ZImg3.SetPixel(j, i, pix2);
                            }
                            else
                            {
                                if (k == 0)
                                {
                                    { ZImg3.SetPixel(j, i, pix1); }
                                }
                                if (k == 1)
                                {
                                    int a = pix1.A;
                                    int r = pix1.R + pix2.R;
                                    int g = pix1.G + pix2.G;
                                    int b = pix1.B + pix2.B;

                                    if (r > 255) { r = 255; }
                                    if (g > 255) { g = 255; }
                                    if (b > 255) { b = 255; }

                                    //записываем пиксель в изображение
                                    var pix = Color.FromArgb(a, r, g, b);

                                    ZImg3.SetPixel(j, i, pix);
                                }
                                if (k == 2)
                                {
                                    int a = pix1.A;
                                    int r = pix1.R * pix2.R / 255;
                                    int g = pix1.G * pix2.G / 255;
                                    int b = pix1.B * pix2.B / 255;

                                    if (r > 255) { r = 255; }
                                    if (g > 255) { g = 255; }
                                    if (b > 255) { b = 255; }

                                    //записываем пиксель в изображение
                                    var pix = Color.FromArgb(a, r, g, b);

                                    ZImg3.SetPixel(j, i, pix);
                                }
                                if (k == 3)
                                {
                                    int r, g, b;
                                    int a = pix1.A;
                                    if (pix1.R >= pix2.R) { r = pix1.R; } else { r = pix2.R; }
                                    if (pix1.G >= pix2.G) { g = pix1.G; } else { g = pix2.G; }
                                    if (pix1.B >= pix2.R) { b = pix1.B; } else { b = pix2.B; }


                                    //записываем пиксель в изображение
                                    var pix = Color.FromArgb(a, r, g, b);

                                    ZImg3.SetPixel(j, i, pix);
                                }
                                if (k == 4)
                                {
                                    int r, g, b;
                                    int a = pix1.A;
                                    if (pix1.R <= pix2.R) { r = pix1.R; } else { r = pix2.R; }
                                    if (pix1.G <= pix2.G) { g = pix1.G; } else { g = pix2.G; }
                                    if (pix1.B <= pix2.R) { b = pix1.B; } else { b = pix2.B; }

                                    //записываем пиксель в изображение
                                    var pix = Color.FromArgb(a, r, g, b);

                                    ZImg3.SetPixel(j, i, pix);
                                }
                                if (k == 5)
                                {
                                    int a = pix1.A;
                                    int r = (pix1.R + pix2.R) / 2;
                                    int g = (pix1.G + pix2.G) / 2;
                                    int b = (pix1.B + pix2.B) / 2;

                                    if (r > 255) { r = 255; }
                                    if (g > 255) { g = 255; }
                                    if (b > 255) { b = 255; }

                                    //записываем пиксель в изображение
                                    var pix = Color.FromArgb(a, r, g, b);

                                    ZImg3.SetPixel(j, i, pix);
                                }
                            }
                        }
                    }
                    PB1[ju].Image = ZImg3;
                }
            
            }
        }

        void MaskCicle(int opg)//Работа с маской
        {
            if (button3.FlatStyle == FlatStyle.Standard || button2.FlatStyle == FlatStyle.Standard)
            {
                int k, r, x, y, m=iter+1;

                //this.panel2.Controls.Add(pictureBox3);
                //pictureBox3.Parent = this.panel2;
                PB1[m].BringToFront();
                PB1[m].BackColor = Color.Transparent;
                PB1[m].SizeMode = PictureBoxSizeMode.Zoom;
                if (opg == 1) { PB1[m].Image = Properties.Resources.Circle; }
               // if (opg == 2) { PB1[m].Image = Properties.Resources.Mask; }
                

                
                var NImg1 = (Bitmap)PB1[m].Image;
                var NImg2 = (Bitmap)PB1[iter].Image;
                var pixn= NImg1.GetPixel(1, 1);
                var w1 = NImg1.Width;
                var h1 = NImg1.Height;
                var w2 = NImg2.Width;
                var h2 = NImg2.Height;
                if (w1 < w2) { k = (int)(w2 / w1); x = 2; } else { k = (int)(w1 / w2); x = 1; };
                if (h1 < h2) { r = (int)(h2 / h1); y = 2; } else { r = (int)(h1 / h2); y = 1; };
                if (r > k) { k = r; }
                if (k > 1)
                {
                    var w3 = NImg1.Width;
                    var h3 = NImg1.Height;
                    var w4 = NImg1.Width;
                    var h4 = NImg1.Height;

                    if (x == 1) { w3 = w2 * k; h3 = h2 * k; w4 = NImg2.Width; h4 = NImg2.Height; }
                    if (x == 2) { w3 = w1 * k; h3 = h1 * k; }
                    var PImg = new Bitmap(w3, h3);
                    for (int i = 0; i < h4; ++i)
                    {
                        for (int j = 0; j < w4; ++j)
                        {
                            var pix1 = Color.FromArgb(0, 0, 0, 0);
                            if (x == 1) { pix1 = NImg2.GetPixel(j, i); } else { pix1 = NImg1.GetPixel(j, i); }
                            for (int hi = 0; hi < k; ++hi)
                            {
                                for (int lo = 0; lo < k; ++lo)
                                {
                                    PImg.SetPixel((lo + j * k), (hi + i * k), pix1);
                                }
                            }
                        }
                    }
                    if (x == 1) { PB1[iter].Image = PImg; }
                    if (x == 2) { PB1[m].Image = PImg; }

                }
                
                var HImg1 = (Bitmap)PB1[m].Image;
                var pix = NImg2.GetPixel(1, 1);
                var HImg2 = (Bitmap)PB1[iter].Image;
                w1 = HImg1.Width;
                h1 = HImg1.Height;
                w2 = HImg2.Width;
                h2 = HImg2.Height;
                var wm = w1;
                var hm = h1;
                if (w1 < w2) { wm = w2; } else { wm = w1; }
                if (h1 < h2) { hm = h2; } else { hm = h1; }

                {
                    int h = 0, w = 0;
                    var wr = (wm - w2) / 2; if (wr ==0) { wr = w2; w = 1; }
                    var hr = (hm - h2) / 2; if (hr ==0) { hr = h2; h = 1; }
                    var ZImg = new Bitmap(wm, hm);
                    for (int i = 0; i < hr; ++i)
                    {
                        for (int j = 0; j < wr; ++j)
                        {
                            pix = Color.FromArgb(0, 0, 0, 0); ZImg.SetPixel(j, i, pix);
                        }
                    }
                    if (h == 1) { hr = 0; }
                    if (w == 1) { wr = 0; }
                    for (int i = 0; i < h2; ++i)
                    {
                        for (int j = 0; j < w2; ++j)
                        {
                            pix = HImg2.GetPixel(j, i); ZImg.SetPixel(j + wr, i + hr, pix);
                        }
                    }
                    if (h == 1) { h2 = 0; }
                    if (w == 1) { w2 = 0; }
                    for (int i = h2 + hr; i < hm; ++i)
                    {

                        for (int j = w2 + wr; j < wm; ++j)
                        {
                            pix = Color.FromArgb(0, 0, 0, 0); ZImg.SetPixel(j, i, pix);
                        }
                    }
                    PB1[iter].Image = ZImg;
                }
                {
                    w1 = HImg1.Width;
                    h1 = HImg1.Height;
                    w2 = HImg2.Width;
                    h2 = HImg2.Height;
                    int h = 0, w = 0;
                    var wr = (wm - w1) / 2; if (wr == 0) { wr = w1; w = 1; }
                    var hr = (hm - h1) / 2; if (hr == 0) { hr = h1; h = 1; }
                    var ZImg = new Bitmap(wm, hm);

                    for (int i = 0; i < hr; ++i)
                    {

                        for (int j = 0; j < wr; ++j)
                        {
                            pix = Color.FromArgb(1, 1, 1, 1); ZImg.SetPixel(j, i, pixn);
                        }
                    }
                    if (h == 1) { hr = 0; }
                    if (w == 1) { wr = 0; }
                    for (int i = 0; i < h1; ++i)
                    {
                        for (int j = 0; j < w1; ++j)
                        {
                            pix = HImg1.GetPixel(j, i); ZImg.SetPixel(j + wr, i + hr, pix);
                        }
                    }
                    if (h == 1) { h1 = 0; }
                    if (w == 1) { w1 = 0; }

                    for (int i = h1 + hr; i < hm; ++i)
                    {
                        for (int j = w1 + wr; j < wm; ++j)
                        {
                            pix = Color.FromArgb(1, 1, 1, 1); ZImg.SetPixel(j, i, pixn);
                        }
                    }
                    PB1[m].Image = ZImg;
                }
                NImg1 = (Bitmap)PB1[m].Image;
                NImg2 = (Bitmap)PB1[iter].Image;
                w1 = NImg1.Width;
                h1 = NImg1.Height;
                w2 = NImg2.Width;
                h2 = NImg2.Height;
                var ZImg3 = new Bitmap(w1, h1);

                for (int i = 0; i < h1; ++i)
                {
                    for (int j = 0; j < w1; ++j)
                    {
                        var pix1 = NImg1.GetPixel(j, i);
                        var pix2 = NImg2.GetPixel(j, i);
                        if (pix1.A == 0)
                        {
                            ZImg3.SetPixel(j, i, pix2);
                        }
                        else
                        {
                            
                                if (pixn == pix1)
                                {
                                    ZImg3.SetPixel(j, i,Color.FromArgb(0, 0, 0, 0));//
                                }
                                else { ZImg3.SetPixel(j, i, pix1); }
                            
                        }
                    }
                }
                PB1[m].Image = ZImg3;
            }
        }

        void RGB1( int lm) //цвет и прозрачность работа с иконой
        {
            int r1 = 0, g1 = 0, b1 = 0;
            if (CBR[lm].Checked == false) { r1 = 0; } else { r1 = 1; }
            if (CBG[lm].Checked == false) { g1 = 0; } else { g1 = 1; }
            if (CBB[lm].Checked == false) { b1 = 0; } else { b1 = 1; }


            var NImg = (Bitmap)PB2[lm].Image;
            var w = NImg.Width;
            var h = NImg.Height;
            var a1 = TB[lm].Value;
            int a = (int)(2.55 * (int)a1);
            var ZImg = new Bitmap(w, h);

            //попиксельно обрабатываем картинку 
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    //считывыем пиксель картинки и получаем его цвет
                    var pix = NImg.GetPixel(j, i);

                    //получаем цветовые компоненты цвета
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;

                    if (r1 == 0) { r = 0; } else { r = pix.R; }
                    if (g1 == 0) { g = 0; } else { g = pix.G; }
                    if (b1 == 0) { b = 0; } else { b = pix.B; }

                    //записываем пиксель в изображение
                    pix = Color.FromArgb(a, r, g, b);
                    ZImg.SetPixel(j, i, pix);

                }
            }
            PB1[lm].Image = ZImg;//Присваиваем Главной картинке получившее ся изображение
            
        }

        void StandartControl (int j, object sender, EventArgs e)
        {
           RGB1(j);
            if (j > 0)
            {
                for (int jp = 1; jp <= iter; jp++)
                {
                    var ty = jp; j = jp;
                    new2sliv(j);
                    if (CB[ty].SelectedIndex == 0) { sum(0, j); }
                    if (CB[ty].SelectedIndex == 1) { sum(1, j); }
                    if (CB[ty].SelectedIndex == 2) { sum(2, j); }
                    if (CB[ty].SelectedIndex == 3) { sum(3, j); }
                    if (CB[ty].SelectedIndex == 4) { sum(4, j); }
                    if (CB[ty].SelectedIndex == 5) { sum(5, j); }
                    if (CB[ty].SelectedIndex == 6) { sum(6, j); }
                }
            }
           

        }
//======================================События на кнопках======================================================

        private void button1_Click(object sender, EventArgs e)///////////////////////////Вход..........................................
        {
            iter++;
            NewPanel();
            var opd = new OpenFileDialog();// Создает окно открытия файла
            PB2[iter].SizeMode = PictureBoxSizeMode.Zoom;//Размещает по всей ширине объекта
            PB1[iter].SizeMode = PictureBoxSizeMode.Zoom;//Размещает по всей ширине объекта
            if (opd.ShowDialog() == DialogResult.OK)
            {
                PB1[iter].Image = Image.FromFile(opd.FileName);
                PB1[iter].BackColor = Color.Transparent;
                PB2[iter].Image = Image.FromFile(opd.FileName);
            }
            StandartControl(iter, sender, e);
            button2.Visible = true;
            button3.Visible = true;
            pictureBox1.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
            flowLayoutPanel1.Visible = true;
        }

        private void CBR_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (CBR[i] == sender)
                { j = i; }
            RGB1(j);
            //StandartControl(j, sender, e);
            CB_SelectedIndexChanged(sender, e);
        }
        private void CBG_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (CBG[i] == sender)
                { j = i; }
            RGB1(j);
            //StandartControl(j, sender, e);
            CB_SelectedIndexChanged(sender, e);
        }

        private void CBB_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (CBB[i] == sender)
                { j = i; }
            RGB1(j);
    
            CB_SelectedIndexChanged(sender, e);
        }
        private void TB_CheckedChanged(object sender, EventArgs e)
        {
            int j = 100;
            for (int i = 0; i <= iter; i++)
                if (TB[i] == sender)
                { j = i; }
            RGB1(j);
            CB_SelectedIndexChanged(sender, e);
        }

        private void CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(iter>0)
            {
                int j = 100;
                for (int i = 0; i <= iter; i++)
                    if (CB[i] == sender)
                    { j = i; }
                for (int jp=1; jp <= iter; jp++)
                {
                    var ty = jp; j = jp;
                    RGB1(jp);
                    new2sliv(j);

                    if (CB[ty].SelectedIndex == 0) { sum(0, j); }
                    if (CB[ty].SelectedIndex == 1) { sum(1, j); }
                    if (CB[ty].SelectedIndex == 2) { sum(2, j); }
                    if (CB[ty].SelectedIndex == 3) { sum(3, j); }
                    if (CB[ty].SelectedIndex == 4) { sum(4, j); }
                    if (CB[ty].SelectedIndex == 5) { sum(5, j); }
                    if (CB[ty].SelectedIndex == 6) { sum(6, j); }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (iter >= 0)
            {
                if (button3.FlatStyle == FlatStyle.Popup)
                {
                    int yu = iter + 1;
                    int hj = PB1.Count;
                    if (hj==iter)
                    {
                        PB1[yu].Visible = false;
                        PB1.RemoveAt(yu);
                    }    
                    button2.FlatStyle = FlatStyle.Popup;
                    button3.FlatStyle = FlatStyle.Standard;
                    pictureBox1.Visible = true;
                    PictureBox mask67 = new PictureBox();
                    mask67 = Clone(pictureBox1);
                    PB1.Add(mask67);
                    this.panel2.Controls.Add(mask67);
                    mask67.Parent = this.panel2;
                    mask67.BringToFront();
                    mask67.BackColor = Color.Transparent;
                    pictureBox1.Visible = false;
                    MaskCicle(1);
                }
                else
                {
                    int yu = iter + 1;
                    PB1[yu].Visible = false;
                    PB1.RemoveAt(yu);
                    button3.FlatStyle = FlatStyle.Popup;
                    CB_SelectedIndexChanged(sender, e);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if (iter >= 0)
          {
                if (button2.FlatStyle == FlatStyle.Popup)
                {
                    int yu = iter + 1;
                    int hj = PB1.Count;

                    if (hj==iter)
                    {
                        PB1[yu].Visible = false;
                        PB1.RemoveAt(yu);
                    }
                    
                    button3.FlatStyle = FlatStyle.Popup;
                    button2.FlatStyle = FlatStyle.Standard;
                    pictureBox1.Visible = true;
                    PictureBox mask67 = new PictureBox();
                    mask67 = Clone(pictureBox1);
                    PB1.Add(mask67);
                    this.panel2.Controls.Add(mask67);
                    mask67.Parent = this.panel2;
                    mask67.BringToFront();
                    pictureBox1.Visible = false;
                    MaskCicle(2);
                }
                else
                {
                    int yu = iter + 1;
                    PB1[yu].Visible = false;
                    PB1.RemoveAt(yu);
                    button2.FlatStyle = FlatStyle.Popup;
                    CB_SelectedIndexChanged(sender, e);
                }
          }
        }

        private void BTop_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (BTop[i] == sender)
                { j = i; }
            DubBtop(j, 1);
            CB_SelectedIndexChanged(sender, e);

        }

        private void BDown_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (BDown[i] == sender)
                { j = i; }
            DubBtop(j, 2);
            CB_SelectedIndexChanged(sender, e);
        }

        private void BCl_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= iter; i++)
                if (BCl[i] == sender)
                j = i;
            DubBtop(j, 3);
        }
//======================================Управление панелями===============================================
        void DubBtop( int lm, int h)
        {
            int rt = 0; int ym = 0;

            PictureBox nPB1 = Clone (PB1[lm]);
            PictureBox nPB2 = Clone(PB2[lm]);
            CheckBox nCBR = Clone(CBR[lm]);
            CheckBox nCBG = Clone(CBG[lm]);
            CheckBox nCBB = Clone(CBB[lm]);
            var nCB = CB[lm].SelectedIndex;
            TrackBar nTB = Clone(TB[lm]);

            if (h==1)
            {
                ym = lm - 1;
                rt = 0;
            }

            if (h == 2)
            {
                ym = lm + 1;
                rt = iter;
            }

            if(h==1 || h==2)
            {
                if ((lm < iter && h==2)|| (lm > 0 && h == 1))
                {
                    CB[lm].SelectedIndex = CB[ym].SelectedIndex;
                    CB[ym].SelectedIndex = nCB;
                    PB1[lm].Image = PB1[ym].Image;
                    PB1[ym].Image = nPB1.Image;
                    PB2[lm].Image = PB2[ym].Image;
                    PB2[ym].Image = nPB2.Image;
                    CBR[lm].Checked = CBR[ym].Checked;
                    CBR[ym].Checked = nCBR.Checked;
                    CBG[lm].Checked = CBG[ym].Checked;
                    CBG[ym].Checked = nCBG.Checked;
                    CBB[lm].Checked = CBB[ym].Checked;
                    CBB[ym].Checked = nCBB.Checked;
                    TB[lm].Value = TB[ym].Value;
                    TB[ym].Value = nTB.Value;
                }

            }

            if (h == 3)
            {
                PL[lm].Visible = false;
                PB1[lm].Visible = false;
                PL.RemoveAt(lm);
                PB2.RemoveAt(lm);
                PB1.RemoveAt(lm);
                CB.RemoveAt(lm);
                CBR.RemoveAt(lm);
                CBG.RemoveAt(lm);
                CBB.RemoveAt(lm);
                TB.RemoveAt(lm);
                BCl.RemoveAt(lm);
                BTop.RemoveAt(lm);
                BDown.RemoveAt(lm);
                Lab.RemoveAt(lm);
                iter = iter - 1;

                if (iter < 0)
                { 
                    button2.Visible= false;
                    button3.Visible= false;
                }
            }
        }
        
        #region
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        #endregion
    }
}
