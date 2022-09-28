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
    public partial class Hareketler : Form
    {
        public Hareketler()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=SatışVT;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TblHareket", cn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
