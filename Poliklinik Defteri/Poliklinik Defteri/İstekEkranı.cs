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
    public partial class İstekEkranı : Form
    {
        public İstekEkranı()
        {
            InitializeComponent();
        }
        public string HastaAd;
        public int HastaDosyaNo;
        public string DoktorAdi;
        public string İstekDurum = "İstek Yapıldı";
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public string biyokimya = "Biyokimya Laboratuvarı";
        public string idrar = "İdrar Laboratuvarı";
        public string radyoloji = "Radyoloji Laboratuvarı";
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
        void listele ()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Hizmet_Adı,Karşılayan_Birim,İsteyenDoktor From Tetkikler where TetkikYapilanDosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void İstekEkranı_Load(object sender, EventArgs e)
        {
            adts(dataGridView1);
            listele();
        }
        private void btnİstekEkle_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            foreach (object item in chcbxBiyoKimya.CheckedItems)
            {
                string checkedItem = item.ToString();
                if(checkedItem.Count() > 1)

                {
                    label1.Text = checkedItem;
                    SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                    baglanti.Open();

                    string komutCumlesi = "Insert Into Tetkikler Values (@AdSoyad,@TetkikYapilanDosyaNo,@Hizmet_ad,@KarsilayanBirim,@İstekDurum,@Doktor,@İsteyendoktor,@Tarih)";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@AdSoyad", HastaAd);
                    komut.Parameters.AddWithValue("@TetkikYapilanDosyaNo", HastaDosyaNo);
                    komut.Parameters.AddWithValue("@Hizmet_ad", label1.Text);
                    komut.Parameters.AddWithValue("@KarsilayanBirim", biyokimya);
                    komut.Parameters.AddWithValue("@İstekDurum", İstekDurum);
                    komut.Parameters.AddWithValue("@Doktor", DoktorAdi);
                    komut.Parameters.AddWithValue("@İsteyendoktor", DoktorAdi);
                    komut.Parameters.AddWithValue("Tarih", dateTimePicker1.Value.Date);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                }
                else
                {
                    label1.Text = label1.Text + checkedItem + ",";
                    SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                    baglanti.Open();

                    string komutCumlesi = "Insert Into Tetkikler Values (@AdSoyad,@TetkikYapilanDosyaNo,@Hizmet_ad,@KarsilayanBirim,@İstekDurum,@Doktor,@İsteyendoktor,@Tarih)";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@AdSoyad", HastaAd);
                    komut.Parameters.AddWithValue("@TetkikYapilanDosyaNo", HastaDosyaNo);
                    komut.Parameters.AddWithValue("@Hizmet_ad", label1.Text);
                    komut.Parameters.AddWithValue("@KarsilayanBirim", biyokimya);
                    komut.Parameters.AddWithValue("@İstekDurum", İstekDurum);
                    komut.Parameters.AddWithValue("@Doktor", DoktorAdi);
                    komut.Parameters.AddWithValue("@İsteyendoktor", DoktorAdi);
                    komut.Parameters.AddWithValue("Tarih", dateTimePicker1.Value.Date);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                }
               
                
            }
            foreach (object itemradyo in chcbxRadyoloji.CheckedItems)
            {
                string checkedItem = itemradyo.ToString();
                label1.Text = label1.Text + checkedItem + ",";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string radyokomutCumlesi = "Insert Into Tetkikler Values (@AdSoyad,@TetkikYapilanDosyaNo,@Hizmet_ad,@KarsilayanBirim,@İstekDurum,@Doktor,@İsteyendoktor,@Tarih)";
                SqlCommand komutradyo = new SqlCommand(radyokomutCumlesi, baglanti);
                komutradyo.Parameters.AddWithValue("@AdSoyad", HastaAd);
                komutradyo.Parameters.AddWithValue("@TetkikYapilanDosyaNo", HastaDosyaNo);
                komutradyo.Parameters.AddWithValue("@Hizmet_ad", label1.Text);
                komutradyo.Parameters.AddWithValue("@KarsilayanBirim", radyoloji);
                komutradyo.Parameters.AddWithValue("@İstekDurum", İstekDurum);
                komutradyo.Parameters.AddWithValue("@Doktor", DoktorAdi);
                komutradyo.Parameters.AddWithValue("@İsteyendoktor", DoktorAdi);
                komutradyo.Parameters.AddWithValue("Tarih", dateTimePicker1.Value.Date);
                komutradyo.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            foreach (object itemidrar in chcbxİdrar.CheckedItems)
            {
                string checkedItem = itemidrar.ToString();
                label1.Text = label1.Text + checkedItem + ",";
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string idrarkomutCumlesi = "Insert Into Tetkikler Values (@AdSoyad,@TetkikYapilanDosyaNo,@Hizmet_ad,@KarsilayanBirim,@İstekDurum,@Doktor,@İsteyendoktor,@Tarih)";
                SqlCommand komutidrar = new SqlCommand(idrarkomutCumlesi, baglanti);
                komutidrar.Parameters.AddWithValue("@AdSoyad",HastaAd);
                komutidrar.Parameters.AddWithValue("@TetkikYapilanDosyaNo", HastaDosyaNo);
                komutidrar.Parameters.AddWithValue("@Hizmet_ad", label1.Text);
                komutidrar.Parameters.AddWithValue("@KarsilayanBirim", idrar);
                komutidrar.Parameters.AddWithValue("@İstekDurum", İstekDurum);
                komutidrar.Parameters.AddWithValue("@Doktor", DoktorAdi);
                komutidrar.Parameters.AddWithValue("@İsteyendoktor", DoktorAdi);
                komutidrar.Parameters.AddWithValue("Tarih", dateTimePicker1.Value.Date);
                komutidrar.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
        }
    }
}
