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
    public partial class ReceteAciklama : Form
    {
        public ReceteAciklama()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";

        private void cbxTür_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
        }
        public int DosyaNo;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into ReceteAciklamalar values (@Aciklama,@Türü,@DosyaNo)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@Türü", cbxTür.Text);
            komut.Parameters.AddWithValue("@DosyaNo", DosyaNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
