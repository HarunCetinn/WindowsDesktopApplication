﻿using System;
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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",8);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 12);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);


            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            SqlCommand komut = new SqlCommand("select URUNAD,SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                fr.ad = dr["URUNAD"].ToString();
            }
            fr.Show();
        }
    }
}
