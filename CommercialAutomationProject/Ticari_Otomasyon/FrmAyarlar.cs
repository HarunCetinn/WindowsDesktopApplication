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

namespace Ticari_Otomasyon
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADMIN",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            TxtKullanıcı.Text = "";
            TxtSifre.Text = "";
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("iNSERT iNTO TBL_ADMIN values (@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullanıcı.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Rol Sisteme Kaydedildi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                TxtKullanıcı.Text = dr["KullaniciAd"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();
            }


        }

        private void TxtKullanıcı_TextChanged(object sender, EventArgs e)
        {
            if (TxtKullanıcı.Text!=null)
            {
                BtnIslem.Text = "Güncelle";
            }
            else
            {
                BtnIslem.Text = "Kaydet";
            }
        }
    }
}
