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
    public partial class PlanEkleme : Form
    {
        public PlanEkleme()
        {
            InitializeComponent();
        }
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
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public string TedaviAd;
        public string stokvar, stokyok;
        public string Malzeme;
        public string KullanimMiktar;
        public string BirimAd;
        public int HastaDosyaNo;
        void depoListele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From İlacDepo";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
        }
        void ilactedavilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From ilac_Tedavi where DosyaNo = '"+HastaDosyaNo+"'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }
        private void PlanEkleme_Load(object sender, EventArgs e)
        {
            adts(dataGridView1);
            adts(dataGridView2);
            depoListele();
            ilactedavilistele();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Malzeme = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        private void btnPlanEkle_Click(object sender, EventArgs e)
        {
            KullanimMiktar = txtPer.Text + "x" + txtMik.Text;
            TedaviAd = "İlaç Tedavisi";
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into ilac_Tedavi values (@Tedaviad,@IlacAd,@TedaviSüresi,@KullanimMiktar,@UygulamaSaati,@KullanimSekli,@AcTokDurum,@TedaviTarih,@Aciklama,@Birim_Adi,@DosyaNo)";
            SqlCommand komut = new SqlCommand(komutCumlesi , baglanti);
            komut.Parameters.AddWithValue("@Tedaviad",TedaviAd);
            komut.Parameters.AddWithValue("@IlacAd", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            komut.Parameters.AddWithValue("@TedaviSüresi",txtTedaviGünSüresi.Text);
            komut.Parameters.AddWithValue("@KullanimMiktar",KullanimMiktar);
            komut.Parameters.AddWithValue("@UygulamaSaati",txtUygSaat.Text);
            komut.Parameters.AddWithValue("@KullanimSekli",cbxKullanimSekli.SelectedItem);
            komut.Parameters.AddWithValue("@AcTokDurum",cbxAcTok.SelectedItem);
            komut.Parameters.AddWithValue("@TedaviTarih",dateTedaviTarih.Value);
            komut.Parameters.AddWithValue("@Aciklama",txtAciklama.Text);
            komut.Parameters.AddWithValue("@Birim_Adi",BirimAd);
            komut.Parameters.AddWithValue("@DosyaNo", HastaDosyaNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
            ilactedavilistele();
        }

        private void cbxUygSaat_SelectedIndexChanged(object sender, EventArgs e)
        {
              
                txtUygSaat.Text += cbxUygSaat.SelectedItem.ToString() + " ";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ilactedavilistele();
        }
        private void cbxDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokvar = "Mevcut";
            stokyok = "Yok";
            if(cbxDepo.SelectedIndex == 0 && checkBox1.Checked)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select * From İlacDepo where Depo = '"+cbxDepo.SelectedItem+"' and Stok = '"+stokvar+"'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if(cbxDepo.SelectedIndex == 0)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select * From İlacDepo where Depo = '" + cbxDepo.SelectedItem + "' and Stok = '" + stokyok + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            if(cbxDepo.SelectedIndex == 1 && checkBox1.Checked)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select * From İlacDepo where Depo = '" + cbxDepo.SelectedItem + "' and Stok = '"+stokvar+"'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
           else if (cbxDepo.SelectedIndex  == 1)
                {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select * From İlacDepo where Depo = '" + cbxDepo.SelectedItem + "' and Stok = '" + stokyok + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }
    }
}
