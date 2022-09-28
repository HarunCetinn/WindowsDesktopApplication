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
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TblPersonel", cn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblPersonel(PersonelAdSoyad) values (@p1)", cn);
            komut2.Parameters.AddWithValue("@p1", textBox2.Text);
            komut2.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Personel kaydedildi...");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TblPersonel where PersonelId=@p1", cn);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Personel silindi...");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut4 = new SqlCommand("Update TblPersonel set PersonelAdSoyad=@p1 where PersonelId=@p2", cn);
            komut4.Parameters.AddWithValue("@p1", textBox2.Text);
            komut4.Parameters.AddWithValue("@p2", textBox1.Text);
            komut4.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Personel güncellendi...");
        }
    }
}
