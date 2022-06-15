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
    public partial class GecmisBulgular : Form
    {
        public GecmisBulgular()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = "Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public int HastaDosyaNo;
        public void Dts(DataGridView dataGridView)
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
        private void GecmisBulgular_Load(object sender, EventArgs e)
        {
            Dts(dataGridView1);
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Bulgusu,Aciklama From HastaBulgusu where DosyaNo = '" + HastaDosyaNo + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi,baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
