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
    public partial class HastaKabul : Form
    {
        public HastaKabul()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public void PoliklinikListele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Klinikler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;

            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cbxPoliklinik.Items.Add(dr["KlinikAdi"]);
            }
            baglanti.Close();
        } //------------
        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Hastalar where TcNo like '" + txtTc.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                txtTc.Text = read["TcNo"].ToString();
                txtAd.Text = read["Ad"].ToString();
                txtSoyad.Text = read["Soyad"].ToString();
                lblDosyaNo.Text = read["DosyaNo"].ToString();
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into HastaKabul Values (@DosyaNo,@Tcno,@Ad,@Soyad,@GelisNedeni,@GelisTarihi,@Sikayeti,@Poliklinik)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@DosyaNo", lblDosyaNo.Text);
            komut.Parameters.AddWithValue("@Tcno", txtTc.Text);
            komut.Parameters.AddWithValue("@Ad",txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@GelisNedeni", txtSikayeti.Text);
            komut.Parameters.AddWithValue("@GelisTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Sikayeti", txtGelisNedeni.Text);
            komut.Parameters.AddWithValue("@Poliklinik",Convert.ToInt32(cbxPoliklinik.SelectedIndex));
            komut.ExecuteNonQuery();
            MessageBox.Show("Hasta Polikliniğe Kaydedildi");
        }
        private void HastaKabul_Load(object sender, EventArgs e)
        {
            PoliklinikListele();
        }
    }
}
