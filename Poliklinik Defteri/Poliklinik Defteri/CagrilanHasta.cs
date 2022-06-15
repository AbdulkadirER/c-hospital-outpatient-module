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
    public partial class CagrilanHasta : Form
    {
        public CagrilanHasta()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";

        public string DoktorAd;
        public string Poliklinik;
        public string HastaAd;
        public string HastaSoyad;
        public int SiraNo;
        
        public VeriGonder verial = new VeriGonder();
        private void CagrilanHasta_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Ad,Soyad From HastaKabul where Ad = '" + HastaAd + "' and Soyad = '" + HastaSoyad + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                lblHastaAdSoyad.Text = HastaAd + "" + HastaSoyad;
            }
            baglanti.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Ad,Soyad From HastaKabul where Ad = '" + HastaAd + "' and Soyad = '" + HastaSoyad + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                lblHastaAdSoyad.Text = HastaAd + "" + HastaSoyad;
            }
            baglanti.Close();
            timer1.Start();
        }
    }
}
