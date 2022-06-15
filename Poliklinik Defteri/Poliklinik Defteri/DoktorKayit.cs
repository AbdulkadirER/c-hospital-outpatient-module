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
    public partial class DoktorKayit : Form
    {
        public DoktorKayit()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into Doktorlar Values (@Ad,@Soyad,@DogumTarihi,@Cinsiyet,@Email,@Telefon,@KlinikAd,@KullaniciAd,@Sifre)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@DogumTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Cinsiyet", cbxCinsiyet.SelectedItem);
            komut.Parameters.AddWithValue("@Email", txtMail.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Klinikad", cbxKlinikler.SelectedIndex);
            komut.Parameters.AddWithValue("@KullaniciAd", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@Sifre", txtSifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Doktor Başarıyla Eklendi");
        }
        public void KlinikCekme()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM Klinikler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cbxKlinikler.Items.Add(dr["KlinikAdi"]);
            }
            baglanti.Close();
        }
        private void DoktorKayit_Load(object sender, EventArgs e)
        {
            KlinikCekme();
        }
    }
}
