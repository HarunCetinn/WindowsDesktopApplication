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
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TblKategori", cn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblKategori(KategoriAd) values (@p1)",cn);
            komut2.Parameters.AddWithValue("@p1", textBox2.Text);
            komut2.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kategori kaydedildi...");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TblKategori where KategoriId=@p1",cn);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kategori silindi...");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut4 = new SqlCommand("Update TblKategori set KategoriAd=@p1 where KategoriId=@p2", cn);
            komut4.Parameters.AddWithValue("@p1", textBox2.Text);
            komut4.Parameters.AddWithValue("@p2", textBox1.Text);
            komut4.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kategori güncellendi...");
        }
    }
}

//Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True
