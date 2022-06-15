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
    public partial class ReçeteDetay : Form
    {
        public ReçeteDetay()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";

        public string HastaAdSoyad,HastaDosyaNo,PoliklinikAd,DoktorAdSoyad;
        public void adts(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ActiveCaption;
            dataGridView.DefaultCellStyle.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
        }
        void eklenenlistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select İlac_Adı,Kullanim_Sekli,Kac_Kez,Kac_Doz,Kutu,Periyod,Periyod_Birim,Ac_Tok,Rapor_Durum,Aciklama From Eklenenİlaclar where DosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        void ilaclistele ()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open ();
            SqlCommand cmd = new SqlCommand("select İlacAd from İlacListe", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxilacListe.Items.Add(dr["İlacAd"]);
            }
            baglanti.Close ();
        }
        void aciklamalistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();
            string komutCumlesi = "Select Türü,Aciklama From ReceteAciklamalar where DosyaNo = '"+HastaDosyaNo+"'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }
        void tanilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Tanimlar where DosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }
        public void rastgele()
        {
            Random rastgele = new Random();
            for (int i = 0; i < 5; i++)
            {
                int sayi = rastgele.Next(1000, 999999);
                txtReceteSeriNo.Text = sayi.ToString();
            }
        }
        //LOAD
        private void ReçeteDetay_Load(object sender, EventArgs e)
        {
            txtReceteSeriNo.ReadOnly = true;
            rastgele();
            adts(dataGridView1);
            adts(dataGridView2);
            adts(dataGridView3);
            tanilistele();
            aciklamalistele();
            ilaclistele();
            lblHastaAdSoyad.Text =HastaAdSoyad.ToUpper();
            cbxHastaTakip.Text = "Ayaktan Tedavi - Normal -";
            lblProvizyonTip.Text = "Normal";
            lblBrans.Text = PoliklinikAd.ToUpper();
        }
        private void cbxilacListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select Rapor from İlacListe where İlacAd = '"+cbxilacListe.Text+"'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxRaporDrm.Text = (dr["Rapor"]).ToString();
                cbxPeriyodikBirim.Text = cbxPeriyodikBirim.Items[2].ToString();
                txtKacKez.Text = "1";
                txtDoz.Text = "1";
                txtPeriyod.Text = "1";
                txtKutu.Text = "1";
                cbxAcTok.Text = cbxAcTok.Items[1].ToString();
            }
            baglanti.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtKacKez.Text = "1";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtKacKez.Text = "2";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtKacKez.Text = "3";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtKacKez.Text = "4";
        }
        private void btnTaniEkle_Click(object sender, EventArgs e)
        {
            TaniEkrani frmtaniekran = new TaniEkrani();
            frmtaniekran.ShowDialog();
        }
        private void btnAciklama_Click(object sender, EventArgs e)
        {
            ReceteAciklama frmaciklama = new ReceteAciklama();
            frmaciklama.DosyaNo =int.Parse (HastaDosyaNo);
            frmaciklama.ShowDialog();
        }
        private void btnİlacEkle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into Eklenenİlaclar values (@İlac_Adı,@Kullanim_Sekli,@Kac_Kez,@Kac_Doz,@Kutu,@Periyod,@Periyod_Birim,@Ac_Tok,@Rapor_Durum,@Aciklama,@Tarih,@DosyaNo)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@İlac_Adı",cbxilacListe.Text.ToString());
            komut.Parameters.AddWithValue("@Kullanim_Sekli",cbxKullanimSekli.Text.ToString());
            komut.Parameters.AddWithValue("@Kac_Kez",txtKacKez.Text.ToString());
            komut.Parameters.AddWithValue("@Kac_Doz",txtDoz.Text.ToString());
            komut.Parameters.AddWithValue("@Kutu",txtKutu.Text.ToString());
            komut.Parameters.AddWithValue("@Periyod",txtPeriyod.Text.ToString());
            komut.Parameters.AddWithValue("@Periyod_Birim",cbxPeriyodikBirim.Text.ToString());
            komut.Parameters.AddWithValue("@Ac_Tok",cbxAcTok.Text.ToString());
            komut.Parameters.AddWithValue("@Rapor_Durum",cbxRaporDrm.Text.ToString());
            komut.Parameters.AddWithValue("@Aciklama",txtAciklama.Text.ToString());
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@DosyaNo",Convert.ToInt32 (HastaDosyaNo));
            komut.ExecuteNonQuery();
            
            eklenenlistele();

            string eklekomutCumlesi = "Insert Into ReceteListe values (@AdSoyad,@Doktor_AdSoyad,@İlac_Adi,@Recete_Türü,@Recete_Tarih,@Recete_Durum,@Kullanim_Sekli,@Rapor_Durum,@DosyaNo,@SeriNo)";
            SqlCommand eklekomut = new SqlCommand(eklekomutCumlesi, baglanti);
            eklekomut.Parameters.AddWithValue("@AdSoyad", HastaAdSoyad.ToString());
            eklekomut.Parameters.AddWithValue("@Doktor_AdSoyad", DoktorAdSoyad.ToString());
            eklekomut.Parameters.AddWithValue("@İlac_Adi", cbxilacListe.Text.ToString());
            eklekomut.Parameters.AddWithValue("@Recete_Türü",cbxReceteTür.Text.ToString());
            eklekomut.Parameters.AddWithValue("@Recete_Tarih",dateTimePicker1.Value);
            eklekomut.Parameters.AddWithValue("@Recete_Durum",cbxReceteDurum.Text.ToString());
            eklekomut.Parameters.AddWithValue("@Kullanim_Sekli",cbxKullanimSekli.Text.ToString());
            eklekomut.Parameters.AddWithValue("@Rapor_Durum",cbxRaporDrm.Text.ToString());
            eklekomut.Parameters.AddWithValue("@DosyaNo", Convert.ToInt32(HastaDosyaNo));
            eklekomut.Parameters.AddWithValue("@SeriNo", txtReceteSeriNo.Text);
            eklekomut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void cbxKacKez_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKacKez.Text = cbxKacKez.Text;
        }
        private void cbxPeriyod_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPeriyod.Text = cbxPeriyod.Text;
        }
    }
}
