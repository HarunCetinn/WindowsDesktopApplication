using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (frana == null || frana.IsDisposed)
            {
                frana = new FrmAnaSayfa();
                frana.MdiParent = this;
                frana.Show();
            }
        }

        FrmUrunler frurun;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frurun == null ||frurun.IsDisposed)
            {
                frurun = new FrmUrunler();
                frurun.MdiParent = this;
                frurun.Show();
            }

        }

        FrmMusteriler frmus;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmus == null ||frmus.IsDisposed)
            {
                frmus = new FrmMusteriler();
                frmus.MdiParent = this;
                frmus.Show();
            }
        }

        FrmFirmalar frfir;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frfir== null ||frfir.IsDisposed)
            {
                frfir = new FrmFirmalar();
                frfir.MdiParent = this;
                frfir.Show();
            }
        }

        FrmPersonel frper;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frper== null ||frper.IsDisposed)
            {
                frper = new FrmPersonel();
                frper.MdiParent = this;
                frper.Show();
            }
        }

        FrmRehber frreh;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frreh== null ||frreh.IsDisposed)
            {
                frreh = new FrmRehber();
                frreh.MdiParent = this;
                frreh.Show();
            }
        }

        FrmGiderler frgid;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frgid== null || frgid.IsDisposed)
            {
                frgid = new FrmGiderler();
                frgid.MdiParent = this;
                frgid.Show();
            }
        }

        FrmBankalar frbank;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frbank== null ||frbank.IsDisposed)
            {
                frbank = new FrmBankalar();
                frbank.MdiParent = this;
                frbank.Show();
            }
        }

        FrmFaturalar frfat;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frfat== null ||frfat.IsDisposed)
            {
                frfat = new FrmFaturalar();
                frfat.MdiParent = this;
                frfat.Show();
            }
        }

        FrmNotlar frnot;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frnot== null ||frnot.IsDisposed)
            {
                frnot = new FrmNotlar();
                frnot.MdiParent = this;
                frnot.Show();
            }
        }

        FrmHareketler frhar;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frhar== null ||frhar.IsDisposed)
            {
                frhar = new FrmHareketler();
                frhar.MdiParent = this;
                frhar.Show();
            }
        }

        FrmStoklar frstok;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frstok== null ||frstok.IsDisposed)
            {
                frstok = new FrmStoklar();
                frstok.MdiParent = this;
                frstok.Show();
            }
        }

        FrmAyarlar fray;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fray== null || fray.IsDisposed)
            {
                fray = new FrmAyarlar();
                fray.Show();
            }
        }

        FrmKasa frkasa;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frkasa== null ||frkasa.IsDisposed)
            {
                frkasa = new FrmKasa();
                frkasa.MdiParent = this;
                frkasa.Show();
            }
        }

        FrmAnaSayfa frana;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frana== null ||frana.IsDisposed)
            {
                frana = new FrmAnaSayfa();
                frana.MdiParent = this;
                frana.Show();
            }
        }
    }
}
