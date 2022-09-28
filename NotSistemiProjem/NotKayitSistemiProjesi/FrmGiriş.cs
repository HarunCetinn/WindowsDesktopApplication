using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotKayitSistemiProjesi
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frmogrenci = new FrmOgrenciDetay();
            frmogrenci.numara = maskedTextBox1.Text;
            frmogrenci.Show();


        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "0000")
            {
                FrmOgretmenDetay frmogretmen = new FrmOgretmenDetay();
                frmogretmen.Show();
            }
        }
    }
}
