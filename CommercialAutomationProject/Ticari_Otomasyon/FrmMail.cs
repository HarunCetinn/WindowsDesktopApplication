using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;

        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail;
        }

        private void BtnGönder_Click(object sender, EventArgs e)
        {
            MailMessage mymessage = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mymessage.To.Add(RchMesaj.Text);
            mymessage.From = new MailAddress("Mail");
            mymessage.Subject = TxtKonu.Text;
            mymessage.Body = RchMesaj.Text;
            istemci.Send(mymessage);
        }
    }
}
