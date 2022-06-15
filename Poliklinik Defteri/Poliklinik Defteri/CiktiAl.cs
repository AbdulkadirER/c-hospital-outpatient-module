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
    public partial class CiktiAl : Form
    {
        public CiktiAl()
        {
            InitializeComponent();
        }
        private string baglantiCumlesi = "Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
       
        public string HastaAdSoyad,TcNo;
        public string DosyaNo;
        Font Baslik = new Font("Verdana", 13, FontStyle.Bold);
        Font Govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void pdYazici_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Tc Kimlik Numarası : "+ TcNo, Govde,sb,70,60);
            e.Graphics.DrawString("Adı Soyadı : " + HastaAdSoyad, Govde, sb, 70, 100);
            e.Graphics.DrawString("Hasta Ad Soyad           Tanısı           Tetkik Sonuç           Doktor     ", Baslik, sb, 70, 230);
            e.Graphics.DrawString("------------------------------------------------------------------------------ -----", Baslik, sb, 70, 250);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                e.Graphics.DrawString(listView1.Items[i].SubItems[0].Text, Govde, sb, 70, 270 + (i*30));
                e.Graphics.DrawString(listView1.Items[i].SubItems[1].Text, Govde, sb, 280, 270 + (i * 30));
                e.Graphics.DrawString(listView1.Items[i].SubItems[2].Text, Govde, sb, 440, 270 + (i * 30));
                e.Graphics.DrawString(listView1.Items[i].SubItems[3].Text, Govde, sb, 605, 270 + (i * 30));
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------ -----", Baslik, sb, 70, 350+(listView1.Items.Count*30));
            e.Graphics.DrawString("Çıkış Tarihi : "+dateTimePicker1.Value.Date, Govde, sb, 500, 370 + (listView1.Items.Count * 30 + 30));
        }
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            ppdDiyalog.ShowDialog();
        }
        string Hasta, tani, tetkik, doktor;
        void vericek()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            //SELECT* FROM kategoriler INNER JOIN urunler ON kategoriler.kat_id = urunler.kat_id;
            SqlCommand cmd = new SqlCommand("select HastaAdSoyad,AnaTanisi,Doktor,Tetkik from TaburcuOlanHastalar where DosyaNo = '" + DosyaNo+"' and CikisTarihi= @Tarih", baglanti);
            cmd.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.Date);
            SqlDataReader dr;
            baglanti.Open();

            dr = cmd.ExecuteReader();
            
            DateTime tarih = dateTimePicker1.Value;
            while (dr.Read())
            {
                    Hasta = dr.GetString(0);
                    tani = dr.GetString(1);
                    tetkik = dr.GetString(3);
                    doktor = dr.GetString(2);
                    
                    ListViewItem Ivi = new ListViewItem();
                    Ivi.Text = Hasta;
                    Ivi.SubItems.Add(tani);
                    Ivi.SubItems.Add(tetkik);
                    Ivi.SubItems.Add(doktor);
                    listView1.Items.Add(Ivi);
            }
        }
        private void CiktiAl_Load(object sender, EventArgs e)
        {
            vericek();
        }
    }
}
