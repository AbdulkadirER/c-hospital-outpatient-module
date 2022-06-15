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
using System.Net;
using System.Net.Mail;

namespace Poliklinik_Defteri
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
           SqlBaglanti baglan = new SqlBaglanti();
            SqlCommand komut = new SqlCommand("Select * From Doktorlar where KullaniciAdi='"+ txtKullaniciAdi.Text.ToString() +"' and Email = '" + txtMail.Text.ToString() + "'",baglan.baglanti());

            SqlDataReader oku  = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (baglan.baglanti().State == ConnectionState.Closed)
                    {
                        baglan.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresi = ("ahmtmaraba08@gmail.com");
                    string sifre = ("Ahmetmaraba-08");
                    string smptsrvr = "smtp.gmail.com";
                    string kime = (oku["Email"].ToString());
                    string konu = ("Şifre Hatırlatma");
                    string yazi = ("Sayın, " + oku["Ad"].ToString() + "\n" + "Bizden" + tarih + "Tarihinde Şifre Hatırlatma İsteğinde Bulundunuz." +
                        "\n" + "Parolanız : " + oku["Sifre"].ToString());
                    smtpserver.Credentials = new NetworkCredential(mailadresi, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresi);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yazi;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    MessageBox.Show("Şifreniz Mail Adresinize Gönderilmiştir.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mail Gönderilemedi ! ");
                }
            }
        }
        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adınız")
            {
                txtKullaniciAdi.Text = "";
                txtKullaniciAdi.ForeColor = Color.White;
            }
        }
        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
            {
                txtKullaniciAdi.Text = "Kullanıcı Adınız";
                txtKullaniciAdi.ForeColor = Color.Gray;
            }
        }
        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Mail Adresiniz")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.White;
            }
        }
        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "Mail Adresiniz";
                txtMail.ForeColor = Color.Gray;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
