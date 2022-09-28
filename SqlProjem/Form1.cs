using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Db_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            Kategoriler Kategori1 = new Kategoriler();
            Kategori1.Show();
        }

        private void BtnMüsteriler_Click(object sender, EventArgs e)
        {
            Müşteriler müsteri1 = new Müşteriler();
            müsteri1.Show();

        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut = new SqlCommand("Select KategoriAd,count(*) from TblKategori INNER JOIN TblÜrünler on TblKategori.KategoriId=TblÜrünler.Kategori group by KategoriAd", cn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0],dr[1]);
            }
            cn.Close();
        }

        private void BtnÜrünler_Click(object sender, EventArgs e)
        {
            Ürünler ürün1 = new Ürünler();
            ürün1.Show();
        }

        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            Personeller personel1 = new Personeller();
            personel1.Show();
        }

        private void BtnKasa_Click(object sender, EventArgs e)
        {
            Kasamız kasa1 = new Kasamız();
            kasa1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            İstatistikler istatistik1 = new İstatistikler();
            istatistik1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hareketler hareket1 = new Hareketler();
            hareket1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buraya erişiminiz engellenmiştir...");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapılıyor...");
            Application.Exit();
        }
    }
}
