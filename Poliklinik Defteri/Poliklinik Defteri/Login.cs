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
namespace Poliklinik_Defteri
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
       
        private void txtKullaniciAdi_MouseClick(object sender, MouseEventArgs ez)
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
        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Şifreniz")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Şifreniz";
                txtPassword.ForeColor = Color.Gray;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotfrm = new ForgotPassword();
            forgotfrm.Show();
            this.Hide();
        }
        private void txtGiris_Click(object sender, EventArgs e)
        {
            giris();
            //CagrilanHasta frmcagrilan = new CagrilanHasta();

            //frmcagrilan.Show();
            //frmcagrilan.timer1.Stop();
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                giris();
                //CagrilanHasta frmcagrilan = new CagrilanHasta();
                //frmcagrilan.Show();
            }
        }
        public void giris()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Doktorlar where KullaniciAdi= '" + txtKullaniciAdi.Text + "' and Sifre= '" + txtPassword.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                Form1 form = new Form1();
                form.ID = Convert.ToInt32 (reader ["DoktorId"]);
                form.DoktorKlinik = reader["Klinik"].ToString();
                form.Doktorad = reader["Ad"].ToString() + " " + reader["Soyad"].ToString();
                
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı !");
            }
            baglanti.Close();
        }
    }
}
