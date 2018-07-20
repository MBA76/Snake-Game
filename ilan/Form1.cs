using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ilan.yilan;

namespace ilan
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();
        }
        yilan yilan1 =new yilan();
        Yon yonumuz;
        bool yem = false;
        Random rast = new Random();
        PictureBox pb_yem;
        int skor = 0;

        PictureBox[] pb_yparcalari;
         
        private void Form1_Load(object sender, EventArgs e)
        {
            YeniO();
        }


        private void YeniO()
        {
            yem = false;
            skor = 0;
            yilan1 = new yilan();
            yonumuz = new Yon(-10, 0);
            pb_yparcalari = new PictureBox[0];
            for(int i=0;i<3;i++)
            {
                Array.Resize(ref pb_yparcalari, pb_yparcalari.Length + 1);
                pb_yparcalari[i] = Pb_ekle();
            }
            timer1.Start();
            button1.Enabled = false;

        }

        private PictureBox Pb_ekle()
        {
           
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.White;
            pb.Location = yilan1.Gpos((pb_yparcalari.Length) - 1);
            panel1.Controls.Add(pb);
            return pb;
        }

        private void Pbgun()
        {
            for(int i=0; i<pb_yparcalari.Length;i++)
            {
                pb_yparcalari[i].Location = yilan1.Gpos(i);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Skor:" + skor.ToString();
            yilan1.ilerle(yonumuz);
            Pbgun();
            Yem_olustur();
            Yem_yedi_mi();
            Yilan_kendine_Carpti();
            Duvarlara_Carpti();
         }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                yonumuz = new Yon(0, -10);
           else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                yonumuz = new Yon(0, 10);
           else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                yonumuz = new Yon(-10, 0);
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                yonumuz = new Yon(10, 0);
        }

        public void Yem_olustur()
        {
            if (!yem)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Red;
                pb.Size = new Size(10, 10);
                pb.Location = new Point(rast.Next(panel1.Width / 10) * 10, rast.Next(panel1.Height / 10) * 10);
                pb_yem = pb;
                yem = true;
                panel1.Controls.Add(pb);
            }
        }


        public void Yem_yedi_mi()
        {
            if (yilan1.Gpos(0) == pb_yem.Location)
            {
                skor += 10;
                yilan1.Buyu();
                Array.Resize(ref pb_yparcalari, pb_yparcalari.Length + 1);
                pb_yparcalari[pb_yparcalari.Length - 1] = Pb_ekle();
                yem = false;
                panel1.Controls.Remove(pb_yem);
            }
        }

        public void Yilan_kendine_Carpti()
        {
            for (int i = 1; i < yilan1.Yilan_buyuklugu;i++)
            {
                if (yilan1.Gpos(0) == yilan1.Gpos(i))
                {
                    Yenildi();
                }
            }
        }
        public void Duvarlara_Carpti()
        {
            Point p = yilan1.Gpos(0);
            if (p.X < 0 || p.X > panel1.Width - 10 || p.Y < 0 || p.Y > panel1.Height - 10)
            {
                Yenildi();
            }
        }

        private void Yenildi()
        {
            timer1.Stop();
            MessageBox.Show("Oyun Bitti.Yenildin");
            button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            YeniO();
        }
    }
}
