using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dort_islem
{
    
    public partial class Form1 : Form
    {
        Random rastgele = new Random();
        int sayi1, sayi2, islem, skor;
        int a, b;
        int süre = 100;
        private void getir()
        {
            sayi1 = rastgele.Next(1, 100);
            sayi2 = rastgele.Next(1, 100);
            islem = rastgele.Next(1, 5);
            label1.Text = sayi1.ToString();
            label2.Text = sayi2.ToString();
            a = Convert.ToInt32(label1.Text);
            b = Convert.ToInt32(label2.Text);
            if (islem == 1)
            {
                label3.Text = "+";
                toplam = a + b;
                label5.Text = toplam.ToString();
            }
            if (islem == 2)
            {
                label3.Text = "-";
                cıkarma = a - b;
                label5.Text = cıkarma.ToString();

            }
            if (islem == 3)
            {
                label3.Text = "/";
                carpma = a /b;
                label5.Text = carpma.ToString();

            }
            if (islem == 4)
            {
                label3.Text = "*";
                bolme = a *b;
                label5.Text = bolme.ToString();
            }

        }
        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            süre--;
            label8.Text = süre.ToString();
            if (süre == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Visible = true;
                timer1.Stop();
                label4.Text = " ";
                MessageBox.Show("SÜRENİZ BİTTİ\n\n"+"SKORUNUZ= "+skor+ "");
               
                if (skor <= 150)
                {
                    MessageBox.Show("BAŞARI TESTİNDEN GEÇEMEDİNİZ SİZİN İÇİN OLUŞTURDUĞUM ÇARPIM TABLOSUNU GÖSTERE TIKLAYARAK DAHA İYİ BİR GELİŞME KAYDEDEBİLİRSİNİZ");
                    button4.Visible = true;
                }
                
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "0";
            label2.Text = "0";
            button2.Enabled = false;
            süre = 100;
            label8.Text = süre.ToString();
            button1.Enabled = true;
            
            skor = 0;
            label7.Text = skor.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            çarpım_tablosu frm2 = new çarpım_tablosu();
            frm2.Show();
            this.Hide();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label10.Text = label10.Text.Substring(1) + label10.Text.Substring(0, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = false;
            button2.Enabled = false;
            label5.Visible  = false;
            timer2.Enabled = true;
            label10.Text = "MATEMATİK İŞLEMLERİ PROGRAMIMIZA HOŞGELDİNİZ HER DĞRU CEVAP İÇİN 10 PUAN, YANLIŞ CEVAP İÇİNDE -15 ALACAKSINIZ BAŞARILAR DİLERİM                                                                                                          ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == label5.Text)
            {
                label4.Text = "TEBRİKLER DOĞRU CEVAP VERDİNİZ";
                skor += 10;
                label7.Text = skor.ToString();
                textBox1.Clear();


                getir();

            }
            else
            {
                skor -= 20;
                label7.Text = skor.ToString();
                label4.Text = "YANLIŞ CEVAP!!!";

                textBox1.Clear();
                getir();
            }

        }
        int toplam, cıkarma, carpma, bolme;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = true;
            button1.Enabled = false;
            getir();
        }
    }
}
