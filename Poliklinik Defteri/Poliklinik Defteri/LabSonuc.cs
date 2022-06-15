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
    public partial class LabSonuc : Form
    {
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public LabSonuc()
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

        private void LabSonuc_Load(object sender, EventArgs e)
        {
            adts(dataGridView1);
            adts(dataGridView2);
        }

        private void cbxUnite_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbxUnite.SelectedIndex == 0)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select AdSoyad,Hizmet_Adı,Doktor,Tarih From Tetkikler where Karşılayan_Birim = '" + cbxUnite.Text + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi,baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

            }
           else if (cbxUnite.SelectedIndex == 1)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select AdSoyad,Hizmet_Adı,Doktor,Tarih From Tetkikler where Karşılayan_Birim = '" + cbxUnite.Text + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
           else if (cbxUnite.SelectedIndex == 2)
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select AdSoyad,Hizmet_Adı,Doktor,Tarih From Tetkikler where Karşılayan_Birim = '" + cbxUnite.Text + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select AdSoyad,Hizmet_Adı,Doktor,Tarih From Tetkikler where Hizmet_Adı like '" + txtHizmet.Text + "' or TetkikYapilanDosyaNo like '" + txtDosyaNo.Text + "' or AdSoyad like '" + txtAdSoyad.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
