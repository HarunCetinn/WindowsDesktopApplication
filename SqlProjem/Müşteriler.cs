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
    public partial class Müşteriler : Form
    {
        public Müşteriler()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("select * from TblMüsteri", cn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Müşteriler_Load(object sender, EventArgs e)
        {
            Listele();

            cn.Open();
            SqlCommand komut1 = new SqlCommand("select * from TblSehirler", cn);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read()) {
                CmbSehir.Items.Add(dr["Şehirİsim"]);
            };
            cn.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtMüsId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtMüsAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMüsSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut = new SqlCommand("insert into TblMüsteri(MüsteriAd,MüsteriSoyad,MüsteriSehir,MüsteriBakiye) values (@p1,@p2,@p3,@p4)",cn);
            komut.Parameters.AddWithValue("@p1", TxtMüsAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMüsSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtBakiye.Text));
            komut.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Müşteri kaydedildi...");
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut = new SqlCommand("delete from TblMüsteri where MüsteriId = @p1", cn);
            komut.Parameters.AddWithValue("@p1", TxtMüsId.Text);
            komut.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Müşteri silindi...");
            Listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand komut = new SqlCommand("update TblMüsteri set MüsteriAd = @p1, MüsteriSoyad=@p2, MüsteriSehir=@p3,MüsteriBakiye=@p4 where MüsteriId=@p5",cn);
            komut.Parameters.AddWithValue("@p1",TxtMüsAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMüsSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtBakiye.Text));
            komut.Parameters.AddWithValue("@p5", TxtMüsId.Text);
            komut.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Müşteri güncellendi...");
            Listele();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TblMüsteri where MüsteriAd=@p1",cn);
            komut.Parameters.AddWithValue("@p1",TxtMüsAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
