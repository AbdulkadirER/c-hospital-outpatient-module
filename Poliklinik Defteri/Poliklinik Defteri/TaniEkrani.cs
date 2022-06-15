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
    public partial class TaniEkrani : Form
    {
        public TaniEkrani()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
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
        public DateTime TaniTarih;
        public string TaniAdı,TaniTipi;
        public int HastaDosyaNo;
        void tanilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Tanilar";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            cbxTanilar.DataSource = dt;
            cbxTanilar.DisplayMember = "Tanı_Adı";
        }
       void tanimlitanilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Tanimlar where DosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void TaniEkrani_Load(object sender, EventArgs e)
        {
            txtTaniID.ReadOnly = true;
            adts(dataGridView1);
            tanimlitanilistele();
            TaniTarih = dateTimePicker1.Value;
            tanilistele();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Insert Into Tanimlar Values (@Tarih,@Tani_Tipi,@Tanı,@DosyaNo)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@Tarih", TaniTarih);
            komut.Parameters.AddWithValue("@Tani_Tipi", cbxTaniTip.SelectedItem);
            komut.Parameters.AddWithValue("@Tanı", TaniAdı);
            komut.Parameters.AddWithValue("@DosyaNo", HastaDosyaNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tanimlitanilistele();
        }
        private void txtTaniID_TextChanged(object sender, EventArgs e)
        {
            TaniAdı = txtTaniID.Text + " " + cbxTanilar.Text;
        }
        void TaniSildir()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string deletekomutCumlesi = "Delete from Tanimlar where ID = '" + label4.Text + "'";
            SqlCommand deletekomut = new SqlCommand(deletekomutCumlesi, baglanti);
            deletekomut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnAnaTaniKaldır_Click(object sender, EventArgs e)
        {
            TaniSildir();
            tanimlitanilistele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void cbxTanilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTanilar.ValueMember = "ID";
            string ID = Convert.ToString(cbxTanilar.SelectedValue);
            txtTaniID.Text = ID.ToString();
        }
    }
}
