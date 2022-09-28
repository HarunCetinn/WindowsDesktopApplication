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
    public partial class İstatistikler : Form
    {
        public İstatistikler()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut = new SqlCommand("Select KategoriAd,count(*) from TblKategori INNER JOIN TblÜrünler on TblKategori.KategoriId=TblÜrünler.Kategori group by KategoriAd", cn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            cn.Close();
        }
    }
}
