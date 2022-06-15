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
    public partial class GecmisYakinma : Form
    {
        public GecmisYakinma()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public int HastaDosyaNo;
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
        public void isteklistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Yakinması,Tarih From HastaSikayetleri where DosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void GecmisYakinma_Load(object sender, EventArgs e)
        {
            adts(dataGridView1);
            isteklistele();
        }
    }
}
