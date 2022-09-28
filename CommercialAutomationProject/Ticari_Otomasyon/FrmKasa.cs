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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            musterihareket();
            firmahareket();

            SqlCommand komut1 = new SqlCommand("select sum(TUTAR) from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplam.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("select Maaslar from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaas.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut4 = new SqlCommand("select  count(*) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut5 = new SqlCommand("select  count(*) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut6 = new SqlCommand("select count(*) from TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblPersonelSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut7 = new SqlCommand("select sum(ADET) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblStok.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

        }

        int sayac = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac>0 && sayac <= 5)
            {
                groupControl8.Text = "Elektrik";
                SqlCommand komut8 = new SqlCommand("select top 4 AY,ELEKTRIK FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac>5 &&sayac<=10)
            {
                groupControl8.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut9 = new SqlCommand("select top 4 AY,SU FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac>10 &&sayac<=15)
            {
                groupControl8.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut10 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 15 && sayac <= 20)
            {
                groupControl8.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut11 = new SqlCommand("select top 4 AY,INTERNET FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 20 && sayac <= 25)
            {
                groupControl8.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 AY,EKSTRA FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac==26)
            {
                sayac = 0;
            }
        }

        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl9.Text = "Elektrik";
                SqlCommand komut8 = new SqlCommand("select top 4 AY,ELEKTRIK FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl9.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut9 = new SqlCommand("select top 4 AY,SU FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl9.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut10 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl9.Text = "İnternet";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut11 = new SqlCommand("select top 4 AY,INTERNET FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl9.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 AY,EKSTRA FROM TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
