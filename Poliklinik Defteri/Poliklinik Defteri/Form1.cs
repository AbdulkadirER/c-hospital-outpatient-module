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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string DoktorId;
        public string Doktorad;
        public string DoktorKlinik;
        public string gönderilcekdoktor;
        public string KullanimMiktar;
        public string Hastad,buguntarih;
        public string HastaDosyaNo;
        public int ID;
        
        İstekEkranı istekfrm = new İstekEkranı();

        TaniEkrani taniekranifrm = new TaniEkrani();

        ReçeteDetay recetedetayfrm = new ReçeteDetay();

        LabSonuc labsonucfrm = new LabSonuc();

        DoktorKayit doktorfrm = new DoktorKayit();

        HastaKabul hastakabulfrm = new HastaKabul();

        GecmisYakinma gecmisyakinmafrm = new GecmisYakinma();
        
        void Temizle ()
        {
            txtPer.Clear();cbxSarfDepo.Text = "";
            cbxSarfMalzemeTür.Text = ""; txtTc.Clear();txtAd.Clear();txtSoyad.Clear();
            cbxReceteDurum.Text = "";cbxReceteTür.Text = "";txtDoktor.Clear(); cbxCikisTani.Text = "";txtCikisHali.Clear();txtKararNotu.Clear();
            txtTetkikSonuc.Clear();txtKararAciklama.Clear();dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();dataGridView4.Columns.Clear();
            dataGridView5.Columns.Clear();dataGridView6.Columns.Clear();dataGridView7.Columns.Clear();dataGridView8.Columns.Clear(); dataGridView9.Columns.Clear();dataGridView10.Columns.Clear();txtMik.Clear();
            cbxKullanimSekli.Text = "";cbxAcTok.Text = "";
            numericAdet.Value = 1;txtDonörID.Clear();txtAciklama.Clear();cbxislemyapanPersonel.Text = "";cbxHizmet.Text = "";numericUpDown1.Value = 1;lblFiyat.Text = ""; lblTutar.Text = "";txtMüdahaleAciklama.Clear(); txtYakinmasi.Clear(); cbxBulguTipi.Text = "";  txtBulguAciklama.Clear();
        }

        private string baglantiCumlesi = @"Data Source=.;Initial Catalog=PoliklinikDefteri;Integrated Security=True";
        public void DataGridSettings (DataGridView dataGridView)
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
        public void CikisListe()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select AnaTanisi,CikisTarihi,KararNotu,Doktor From TaburcuOlanHastalar where DosyaNo = '"+lblBasvuruNo.Text+"'";
            SqlCommand komut = new SqlCommand(komutCumlesi,baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView10.DataSource = dt;
            baglanti.Close();
        }

        public void kararaciklamaliste()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Karar_Aciklamasi,Doktor From KararAciklamalari where DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView9.DataSource = dt;
            baglanti.Close();
        }

        public void cikislistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Tanı From Tanimlar where DosyaNo = '"+lblBasvuruNo.Text+"' AND Tarih = @tarih";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tarih",dateTimePicker1.Value.Date);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cbxCikisTani.Items.Add(dr["Tanı"]);
            }
            baglanti.Close();
            txtDoktor.Text = lblDoktorAdSoyad.Text;

        }
        public void tclistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select TcNo,GelisNedeni,Sikayeti From HastaKabul where DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblTcNo.Text = (dr["TcNo"].ToString());
                lblGelisNedeni.Text = (dr["GelisNedeni"].ToString());
                lblSikayeti.Text = (dr["Sikayeti"].ToString());
            }
            baglanti.Close();
        }

        public void hizmetlistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            SqlCommand doldur = new SqlCommand("SELECT HizmetAdı,Ücret FROM Hizmetler", baglanti);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                cbxHizmet.Items.Add(dr["HizmetAdı"]);
                //lblFiyat.Text=(dr["Ücret"].ToString());
            }

            baglanti.Close();
        }
        public void personellistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Personeller";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            cbxislemyapanPersonel.DataSource = dt;
            cbxislemyapanPersonel.DisplayMember = "AdSoyad";
        }
        public void ilactedavilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From ilac_Tedavi where DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            baglanti.Close();
        }
        public void KlinikBelirleme()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();
            
            
            string komutCumlesi = "Select KlinikAdi From Klinikler Inner Join Doktorlar on Klinikler.KlinikId = Doktorlar.Klinik where '"+DoktorKlinik +"' = Klinikler.KlinikId";
            SqlCommand komut = new SqlCommand(komutCumlesi,baglanti);
            SqlDataReader read;
            read = komut.ExecuteReader();
            if(read.Read())
            {
               txtDoktorKlinik.Text = read["KlinikAdi"].ToString();
                lblPoliklinikAd.Text = read["KlinikAdi"].ToString();
            }
            else
            {
                MessageBox.Show("KlinikAdı Çekilemedi");
            }
        }
        void tanimlitanilistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From Tanimlar where DosyaNo = '" + lblBasvuruNo.Text + "' and Tarih= @tarih ";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }
       public void isteklistele()
        {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select Hizmet_Adı,Karşılayan_Birim,İstek_Durumu,Doktor From Tetkikler where TetkikYapilanDosyaNo = '" + lblBasvuruNo.Text + "' and Tarih=@tarih ";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
                baglanti.Close();
        }

        // --------- FORM1 LOAD -----
        private void Form1_Load(object sender, EventArgs e)
        {
            txtDoktorKlinik.ReadOnly = true;
            txtDoktorAd.ReadOnly = true;
            
            DataGridSettings(dataGridView1);
            DataGridSettings(dataGridView2);
            DataGridSettings(dataGridView3);
            DataGridSettings(dataGridView4);
            DataGridSettings(dataGridView5);
            DataGridSettings(dataGridView6);
            DataGridSettings(dataGridView7);
            DataGridSettings(dataGridView8);
            DataGridSettings(dataGridView9);
            DataGridSettings(dataGridView10);
            
            if (ID == 3)
            {
                doktorEklemeToolStripMenuItem.Visible = true;
            }
            İlacsarfListele();
            cbxSarfMalzemeTür.Enabled = false;
            personellistele();
            hizmetlistele();
            txtMüdahaleDoktorAd.Text = Doktorad;
            txtDoktorAd.Text = Doktorad;
            lblDoktorAdSoyad.Text = Doktorad;
            isteklistele();
            tanimlitanilistele();
            KlinikBelirleme();
            
        }
        private void btnMudahaleEkle_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Insert Into Mudahale Values (@Hizmet_Tarih,@Hizmet,@Adet,@Fiyat,@Tutar,@Aciklama,@Doktor,@İslemYapanPersonel,@DosyaNo)";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@Hizmet_Tarih", dateTimePickerHizmetTarih.Value);
                komut.Parameters.AddWithValue("@Hizmet", cbxHizmet.Text);
                komut.Parameters.AddWithValue("@Adet", Convert.ToInt32(numericAdet.Value));
                komut.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(lblFiyat.Text));
                komut.Parameters.AddWithValue("@Tutar", Convert.ToInt32(lblTutar.Text));
                komut.Parameters.AddWithValue("@Aciklama", txtMüdahaleAciklama.Text);
                komut.Parameters.AddWithValue("@Doktor", txtDoktorAd.Text);
                komut.Parameters.AddWithValue("@İslemYapanPersonel", cbxislemyapanPersonel.Text);
                komut.Parameters.AddWithValue("@DosyaNo", int.Parse(lblBasvuruNo.Text));
                komut.ExecuteNonQuery();

                baglanti.Close();
                mudahalelistele();
            }
            
        }
        private void btnPlanEkle_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PlanEkleme planekle = new PlanEkleme();
                planekle.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                planekle.BirimAd = txtDoktorKlinik.Text;
                planekle.ShowDialog();
            }
            

        }
        private void btnReceteEkle_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                recetedetayfrm.DoktorAdSoyad = lblDoktorAdSoyad.Text;
                recetedetayfrm.PoliklinikAd = lblPoliklinikAd.Text;
                recetedetayfrm.HastaAdSoyad = lblAdSoyad.Text;
                recetedetayfrm.HastaDosyaNo = lblBasvuruNo.Text;
                recetedetayfrm.ShowDialog();
            }
            
        }

        private void btnIstekEkle_Click(object sender, EventArgs e)
        {
            İstekEkranı istekekranıfrm = new İstekEkranı();
            if(lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                istekekranıfrm.HastaAd = lblAdSoyad.Text;
                istekekranıfrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                istekekranıfrm.DoktorAdi = Doktorad;
                istekekranıfrm.ShowDialog();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                taniekranifrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                taniekranifrm.ShowDialog();
            }
            
        }
        private void btnR_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ReçeteDetay recetefrm = new ReçeteDetay();
                recetefrm.DoktorAdSoyad = lblDoktorAdSoyad.Text;
                recetefrm.PoliklinikAd = lblPoliklinikAd.Text;
                recetefrm.HastaAdSoyad = lblAdSoyad.Text;
                recetefrm.HastaDosyaNo = lblBasvuruNo.Text;
                recetefrm.ShowDialog();
            }
            
        }

        private void btnIstekSonuc_Click(object sender, EventArgs e)
        {
            labsonucfrm.ShowDialog();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                İstekEkranı istekekranıfrm = new İstekEkranı();
                if (lblBasvuruNo.Text == "")
                {
                    MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    istekekranıfrm.HastaAd = lblAdSoyad.Text;
                    istekekranıfrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                    istekekranıfrm.DoktorAdi = Doktorad;
                    istekekranıfrm.ShowDialog();
                }

            }
            if (e.KeyData == Keys.F2)
            {
                if (lblBasvuruNo.Text == "")
                {
                    MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    taniekranifrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                    taniekranifrm.ShowDialog();
                }

            }
            if(e.KeyData == Keys.F3)
            {
                if (lblBasvuruNo.Text == "")
                {
                    MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    recetedetayfrm.DoktorAdSoyad = lblDoktorAdSoyad.Text;
                    recetedetayfrm.PoliklinikAd = lblPoliklinikAd.Text;
                    recetedetayfrm.HastaAdSoyad = lblAdSoyad.Text;
                    recetedetayfrm.HastaDosyaNo = lblBasvuruNo.Text;
                    recetedetayfrm.ShowDialog();
                }

            }
            if(e.KeyData == Keys.F4)
            {
                labsonucfrm.ShowDialog(this);
            }
        }
        private void btnLab_Click(object sender, EventArgs e)
        {

            labsonucfrm.ShowDialog();
        }
        void hastalistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select DosyaNo,Ad,Soyad From HastaKabul where GelisTarihi BETWEEN @tarih1 and @tarih2 and Poliklinik = '" + DoktorKlinik + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@tarih1", dateTime1.Value);
            komut.Parameters.AddWithValue("@tarih2", dateTime2.Value);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hastalistele();
        }

        private void doktorEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doktorfrm.ShowDialog();
        }

        private void hastaKabulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hastakabulfrm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
           baglanti.Open();

            string komutCumlesi = "Select DosyaNo,Ad,Soyad From HastaKabul where TcNo like '" + txtTc.Text + "' or Ad like '"+txtAd.Text+"' or Soyad like '"+txtSoyad.Text+"'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            //baglanti.Open();

            //string komutCumlesi = "Select BaşvuruNo,Ad,Soyad From HastaKabul where TcNo like '" + txtTc.Text + "'";
            //SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            //SqlDataAdapter adapter = new SqlDataAdapter(komut);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //dataGridView1.DataSource = dt;
            //baglanti.Close();
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            //baglanti.Open();
            
            //string komutCumlesi = "Select BaşvuruNo,Ad,Soyad From HastaKabul where Ad like '" + txtAd.Text + "'";
            //SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            //SqlDataAdapter adapter = new SqlDataAdapter(komut);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //dataGridView1.DataSource = dt;
            //baglanti.Close();
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            //baglanti.Open();

            //string komutCumlesi = "Select BaşvuruNo,Ad,Soyad From HastaKabul where Soyad like '" + txtSoyad.Text + "'";
            //SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            //SqlDataAdapter adapter = new SqlDataAdapter(komut);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //dataGridView1.DataSource = dt;
            //baglanti.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CagrilanHasta frmcagrilan = new CagrilanHasta();
            
            lblBasvuruNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblLcdCagrilan.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblAdSoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frmcagrilan.HastaAd = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frmcagrilan.HastaSoyad = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            Hastad = lblAdSoyad.Text;
            HastaDosyaNo = lblBasvuruNo.Text;
            tanimlitanilistele();
            tclistele();
            isteklistele();

            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select AnaTanisi From TaburcuOlanHastalar where DosyaNo = '" + lblBasvuruNo.Text + "' and AnaTanisi like '" + lblKorona.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show("Hastada " + (dr["AnaTanisi"].ToString()) + " Tehlikesi Var Dikkatli Olunuz !", "Bulaşıcı Hastalık Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglanti.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtYakinmasi.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Hizmet_Adı,Karşılayan_Birim,İstek_Durumu,Doktor From Tetkikler where TetkikYapilanDosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }
        private void btnT_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                taniekranifrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                taniekranifrm.ShowDialog();
            }
            
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Insert Into HastaSikayetleri Values (@Yakinmasi,@Tarih,@DosyaNo)";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@Yakinmasi", txtYakinmasi.Text);
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                komut.Parameters.AddWithValue("@DosyaNo", int.Parse(lblBasvuruNo.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            

        }
        private void btnGecmisyakinmalar_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                gecmisyakinmafrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                gecmisyakinmafrm.ShowDialog();
            }
            
        }
        private void cbxHizmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            SqlCommand doldur = new SqlCommand("SELECT Ücret FROM Hizmetler where HizmetAdı = '"+cbxHizmet.Text+"'", baglanti);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {   
                lblFiyat.Text=(dr["Ücret"].ToString());
            }
            baglanti.Close();
        }
        private void numericAdet_ValueChanged(object sender, EventArgs e)
        {
            int fiyat, adet,tutar;
            fiyat = int.Parse(lblFiyat.Text);
            adet = Convert.ToInt32(numericAdet.Value);
            tutar = adet * fiyat;
            lblTutar.Text = tutar.ToString();
        }
        public void mudahalelistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Hizmet_Tarih,Hizmet,Adet,Fiyat,Tutar,Aciklama,Doktor,İslemYapanPersonel From Mudahale where DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView5.DataSource = dt;
            baglanti.Close();
        }
        public void İlacsarfListele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From İlacSarfCikis where DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView7.DataSource = dt;
            baglanti.Close();
        }
        private void cbxSarfDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSarfMalzemeTür.Enabled = true;
            if(cbxSarfDepo.SelectedItem.ToString() == "Eczane Deposu")
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select * From SarfDepo where Depo = '" + cbxSarfDepo.SelectedItem + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
                baglanti.Close();
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Select Malzeme_ID,Malzeme_Adı,Kritik_Miktar,Minimum_Miktar,SonKullanmaTarihi,Stok_Miktarı,Depo,Malzeme_tip From SarfDepo where Depo = '" + cbxSarfDepo.SelectedItem + "'";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
                baglanti.Close();
            }
        }
        private void btnSarfEkle_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                KullanimMiktar = txtPer.Text + "x" + txtMik.Text;
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Insert Into İlacSarfCikis values (@MalzemeId,@Adı,@Tarih,@Adet,@KullanimMiktar,@BirimAdi,@Doktor,@DonörId,@Kullanim_Sekli,@Ac_Tok,@Aciklama,@DosyaNo)";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@MalzemeId", dataGridView6.CurrentRow.Cells[0].Value.ToString());
                komut.Parameters.AddWithValue("@Adı", Hastad);
                komut.Parameters.AddWithValue("@Tarih", dateTedaviTarih.Value);
                komut.Parameters.AddWithValue("@Adet", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@KullanimMiktar", KullanimMiktar);
                komut.Parameters.AddWithValue("@BirimAdi", DoktorKlinik);
                komut.Parameters.AddWithValue("@Doktor", Doktorad);
                komut.Parameters.AddWithValue("@DonörId", txtDonörID.Text);
                komut.Parameters.AddWithValue("@Kullanim_Sekli", cbxKullanimSekli.SelectedItem);
                komut.Parameters.AddWithValue("@Ac_Tok", cbxAcTok.SelectedItem);
                komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                İlacsarfListele();
            }
            
        }
        private void cbxSarfMalzemeTür_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From SarfDepo where Depo = '" + cbxSarfDepo.SelectedItem + "' and Malzeme_Tip = '" + cbxSarfMalzemeTür.SelectedItem + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView6.DataSource = dt;
            baglanti.Close();
        }
        private void btnBulguKaydet_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Insert Into HastaBulgusu Values (@Bulgusu,@Aciklama,@DosyaNo)";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@Bulgusu", cbxBulguTipi.SelectedItem);
                komut.Parameters.AddWithValue("@Aciklama", txtBulguAciklama.Text);
                komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            
        }

        private void btnReceteVerildi_Click(object sender, EventArgs e)
        {
            txtKararAciklama.Text = btnReceteVerildi.Text;
        }

        private void btnKontroleGelecek_Click(object sender, EventArgs e)
        {
            txtKararAciklama.Text=btnKontroleGelecek.Text;
        }

        private void btnÖneri_Click(object sender, EventArgs e)
        {
            txtKararAciklama.Text = btnÖneri.Text;
        }

        private void btnAciklamaKaydet_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtKararAciklama.Text == "")
                {
                    MessageBox.Show("Karar Açıklama Kısmı Boş Bırakılamaz ! ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                    baglanti.Open();

                    string komutCumlesi = "Insert Into KararAciklamalari values (@Karar_Aciklamasi,@Doktor,@DosyaNo)";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@Karar_Aciklamasi", txtKararAciklama.Text);
                    komut.Parameters.AddWithValue("@Doktor", lblDoktorAdSoyad.Text);
                    komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    tetkiklistele();
                    kararaciklamaliste();
                    cikislistele();
                }
            }
            
        }
        private void btnBulguTemizle_Click(object sender, EventArgs e)
        {
            txtBulguAciklama.Clear();
            cbxBulguTipi.Text = "";
        }
        void tetkiklistele()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select Hizmet_Adı From Tetkikler where TetkikYapilanDosyaNo = '" + lblBasvuruNo.Text + "' AND Tarih = @tarih";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtTetkikSonuc.Text = (dr["Hizmet_Adı"].ToString());
            }
            baglanti.Close();
        }
        void Cikis()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string deletekomutCumlesi = "Delete from HastaKabul where DosyaNo = '" + Convert.ToInt32(lblBasvuruNo.Text) + "'";
            SqlCommand deletekomut = new SqlCommand(deletekomutCumlesi, baglanti);
            deletekomut.ExecuteNonQuery();
            baglanti.Close();
            Receteliste();
        }
        private void btnCikisKaydet_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtTetkikSonuc.Text == "")
                {
                    SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                    baglanti.Open();

                    string komutCumlesi = "Insert Into TaburcuOlanHastalar Values (@HastaAdSoyad,@AnaTanisi,@Tetkik,@CikisTarihi,@CikisHali,@KararNotu,@Doktor,@DosyaNo)";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@HastaAdSoyad", lblAdSoyad.Text);
                    komut.Parameters.AddWithValue("@AnaTanisi", cbxCikisTani.Text);
                    komut.Parameters.AddWithValue("@Tetkik", null);
                    komut.Parameters.AddWithValue("@CikisTarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@CikisHali", txtCikisHali.Text);
                    komut.Parameters.AddWithValue("@KararNotu", txtKararNotu.Text);
                    komut.Parameters.AddWithValue("@Doktor", lblDoktorAdSoyad.Text);
                    komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Cikis();
                    hastalistele();
                    Temizle();
                }
                else
                {
                    SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                    baglanti.Open();

                    string komutCumlesi = "Insert Into TaburcuOlanHastalar Values (@HastaAdSoyad,@AnaTanisi,@Tetkik,@CikisTarihi,@CikisHali,@KararNotu,@Doktor,@DosyaNo)";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@HastaAdSoyad", lblAdSoyad.Text);
                    komut.Parameters.AddWithValue("@AnaTanisi", cbxCikisTani.Text);
                    komut.Parameters.AddWithValue("@Tetkik", txtTetkikSonuc.Text);
                    komut.Parameters.AddWithValue("@CikisTarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@CikisHali", txtCikisHali.Text);
                    komut.Parameters.AddWithValue("@KararNotu", txtKararNotu.Text);
                    komut.Parameters.AddWithValue("@Doktor", lblDoktorAdSoyad.Text);
                    komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Cikis();
                    hastalistele();
                    Temizle();
                }
                CikisListe();
            }
            
        }
        private void txtKararNotu_TextChanged(object sender, EventArgs e)
        {
            if (txtKararNotu.Text =="" )
            {
                btnYatisOnay.Enabled = false;
                btnCikisKaydet.Enabled = false;
            }
            else
            {
                btnYatisOnay.Enabled = true;
                btnCikisKaydet.Enabled = true;
            }
        }
        private void btnYatisOnay_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                string komutCumlesi = "Insert Into YatisVerilenHastalar Values (@HastaAdSoyad,@AnaTanisi,@YatisOnayTarihi,@KararNotu,@Doktor,@DosyaNo)";
                SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                komut.Parameters.AddWithValue("@HastaAdSoyad", lblAdSoyad.Text);
                komut.Parameters.AddWithValue("@AnaTanisi", cbxCikisTani.Text);
                komut.Parameters.AddWithValue("@YatisOnayTarihi", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@KararNotu", txtKararNotu.Text);
                komut.Parameters.AddWithValue("@Doktor", lblDoktorAdSoyad.Text);
                komut.Parameters.AddWithValue("@DosyaNo", lblBasvuruNo.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Cikis();
                hastalistele();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CiktiAl frmCiktiAl = new CiktiAl();
                frmCiktiAl.DosyaNo = lblBasvuruNo.Text;
                frmCiktiAl.TcNo = lblTcNo.Text;
                frmCiktiAl.HastaAdSoyad = lblAdSoyad.Text;
                frmCiktiAl.ShowDialog();
            }
            
        }
        void Receteliste()
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string komutCumlesi = "Select * From ReceteListe where Recete_Tarih BETWEEN @tarih1 and @tarih2 or DosyaNo = '" + lblBasvuruNo.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tarih1", dateTimePicker3.Value.Date);
            komut.Parameters.AddWithValue("@tarih2", dateTimePicker4.Value.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView8.DataSource = dt;
            baglanti.Close();
        }
        private void btnReceteAra_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
                baglanti.Open();

                if (cbxReceteTür.Text == "" && cbxReceteDurum.Text == "")
                {
                    string tekkomutCumlesi = "Select * From ReceteListe where DosyaNo = '" + lblBasvuruNo.Text + "' and Recete_Tarih BETWEEN @tarih1 and @tarih2 ";
                    SqlCommand tekkomut = new SqlCommand(tekkomutCumlesi, baglanti);
                    tekkomut.Parameters.AddWithValue("@tarih1", dateTimePicker3.Value.Date);
                    tekkomut.Parameters.AddWithValue("@tarih2", dateTimePicker4.Value.Date);
                    SqlDataAdapter tekadapter = new SqlDataAdapter(tekkomut);
                    DataTable tekdt = new DataTable();
                    tekadapter.Fill(tekdt);
                    dataGridView8.DataSource = tekdt;
                    baglanti.Close();
                }
                else
                {
                    string komutCumlesi = "Select * From ReceteListe where DosyaNo = '" + lblBasvuruNo.Text + "' and Recete_Tarih BETWEEN @tarih1 and @tarih2 and Recete_Türü like '" + cbxReceteTür.Text + "' and Recete_Durum like '" + cbxReceteDurum.Text + "'";
                    SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
                    komut.Parameters.AddWithValue("@tarih1", dateTimePicker3.Value.Date);
                    komut.Parameters.AddWithValue("@tarih2", dateTimePicker4.Value.Date);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView8.DataSource = dt;
                    baglanti.Close();
                }
            }
            
        }
        private void btnGecmisKararlar_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GecmisKararlar frmGecmisKararlar = new GecmisKararlar();
                frmGecmisKararlar.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                frmGecmisKararlar.ShowDialog();
            }
        }
        private void btnGecmisCikisKayit_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GecmisCikislar frmGecmisCikislar = new GecmisCikislar();
                frmGecmisCikislar.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                frmGecmisCikislar.ShowDialog();
            }
        }
        private void btnReceteSil_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
            baglanti.Open();

            string deletekomutCumlesi = "Delete from ReceteListe where ReceteID = '" + lblSil.Text + "'";
            SqlCommand deletekomut = new SqlCommand(deletekomutCumlesi, baglanti);
            deletekomut.ExecuteNonQuery();
            baglanti.Close();
            Receteliste();
        }
        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSil.Text = dataGridView8.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Temizle();
        }
        private void btnSarfSil_Click(object sender, EventArgs e)
        {
            txtPer.Clear();
            txtMik.Clear();cbxKullanimSekli.Text = "";cbxAcTok.Text = "";numericUpDown1.Value = 1;txtDonörID.Clear();txtAciklama.Clear();
        }
        public VeriGonder veri = new VeriGonder();
        private void btnHastaCagir_Click(object sender, EventArgs e)
        {
            //CagrilanHasta frmCagrilan = new CagrilanHasta();
            //frmCagrilan.Name = "deneme";

            //frmCagrilan.verial.HastaAdSoyad = lblAdSoyad.Text;
            //CagrilanHasta abc = (CagrilanHasta)Application.OpenForms["deneme"];
            //abc.lblHastaAdSoyad.Text = lblAdSoyad.Text;
            //frmCagrilan.timer1.Enabled = true;
            //frmCagrilan.timer1.Start();
            //lblAdSoyad.Text = veri.HastaAdSoyad;
            
            //frmCagrilan.lblHastaAdSoyad.Text = lblAdSoyad.Text;
            //frmCagrilan.lblPoliklinik.Text = lblPoliklinikAd.Text;
            //frmCagrilan.lblDoktorAd.Text = lblDoktorAdSoyad.Text;
        }

        private void btnİstekEkle_Click(object sender, EventArgs e)
        {
            İstekEkranı istekekranıfrm = new İstekEkranı();
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                istekekranıfrm.HastaAd = lblAdSoyad.Text;
                istekekranıfrm.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                istekekranıfrm.DoktorAdi = Doktorad;
                istekekranıfrm.ShowDialog();
            }
        }

        private void btnGecmisBulgular_Click(object sender, EventArgs e)
        {
            if (lblBasvuruNo.Text == "")
            {
                MessageBox.Show("Hasta Seçmeden İşlem Yapamazsınız !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GecmisBulgular frmGecmisBulgu = new GecmisBulgular();
                frmGecmisBulgu.HastaDosyaNo = int.Parse(lblBasvuruNo.Text);
                frmGecmisBulgu.ShowDialog();
            }
        }
    }
}
