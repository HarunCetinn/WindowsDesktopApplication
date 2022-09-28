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
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void Ürünler_Load(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from TblÜrünler", cn);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblÜrünler(ÜrünAd) values (@p1)", cn);
            komut2.Parameters.AddWithValue("@p1", textBox2.Text);
            komut2.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Ürün kaydedildi...");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TblÜrünler where ÜrünId=@p1", cn);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Ürün silindi...");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut4 = new SqlCommand("Update TblÜrünler set ÜrünSatısFiyat=@p1 where ÜrünId=@p2", cn);
            komut4.Parameters.AddWithValue("@p1", textBox5.Text);
            komut4.Parameters.AddWithValue("@p2", textBox1.Text);
            komut4.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Ürün güncellendi...");
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("select * from TblÜrünler where ÜrünAd=@p1", cn);
            komut5.Parameters.AddWithValue("@p1", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
