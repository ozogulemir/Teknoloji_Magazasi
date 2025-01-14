using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknoloji_Magazasi
{
    public partial class adminpanelden_musteriislemleri : Form
    {
        // Data Source=EMIR\SQLEXPRESS;Initial Catalog=Teknoloji_Magazasi;User ID=sa
        SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
        public adminpanelden_musteriislemleri()
        {
            InitializeComponent();

        }

        private void adminpanelden_musteriislemleri_Load(object sender, EventArgs e)
        {
            musterigetir();
        }
        public void musterigetir()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from loginTable", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_adminpanelden_musteriislemleri.DataSource = dt;
            con.Close();
        }
        public void guncellenmiskayitlar()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from uptade_loginTable", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_adminpanelden_musteriislemleri.DataSource = dt;
            con.Close();
        }
        public void silinmiskayitlar()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from deleted_loginTable", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_adminpanelden_musteriislemleri.DataSource = dt;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_kayitekle_apmi_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO loginTable (kullaniciAdi,kullaniciSoyad, sifre,emailAdres,adres) VALUES (@kullaniciAdi,@kullaniciSoyad, @sifre,@emailAdres,@adres)", con);
            cmd.Parameters.AddWithValue("@kullaniciAdi", txt_kullaniciadi_apmi.Text);
            cmd.Parameters.AddWithValue("@kullaniciSoyad", txt_kullanicisoyad.Text);
            cmd.Parameters.AddWithValue("@sifre", txt_sifre_apmi.Text);
            cmd.Parameters.AddWithValue("@emailAdres", txt_emailadres_apmi.Text);
            cmd.Parameters.AddWithValue("@adres", txt_adres.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            musterigetir();
            MessageBox.Show("Kayıt eklendi.");
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void btn_kayitsil_apmi_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("DELETE FROM loginTable WHERE MusteriID = @id", con);
            //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_id_apmi.Text));
            //int silinenkayit = cmd.ExecuteNonQuery();
            //con.Close();
            //if (silinenkayit > 0)
            //{

            //    musterigetir();
            //    MessageBox.Show("Kayıt silindi.", "Bilgilendirme");
            //}

            //else
            //{
            //    MessageBox.Show("Kayıt bulunamadı.");
            //}
            con.Open();
            SqlCommand deleteChildCmd = new SqlCommand("DELETE FROM Siparisler WHERE MusteriID = @id", con);
            deleteChildCmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_id_apmi.Text));
            deleteChildCmd.ExecuteNonQuery();

            // Ardından ana tabloyu sil
            SqlCommand deleteCmd = new SqlCommand("DELETE FROM loginTable WHERE MusteriID = @id", con);
            deleteCmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_id_apmi.Text));
            int silinenkayit = deleteCmd.ExecuteNonQuery();

            con.Close();

            if (silinenkayit > 0)
            {
                musterigetir();
                MessageBox.Show("Kayıt silindi.", "Bilgi");
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.");
            }
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void btn_gerigel_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_panel_form admin_Panel_Form = new admin_panel_form();
            admin_Panel_Form.Show();
        }

        private void txt_kullanicisoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_adminpanelden_musteriislemleri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Seçilen satırın indeksi
            int selectedRowIndex = e.RowIndex;

            // Eğer tıklanan satır geçerliyse
            if (selectedRowIndex >= 0)
            {
                // DataGridView'deki satırı al
                DataGridViewRow selectedRow = dataGridView_adminpanelden_musteriislemleri.Rows[selectedRowIndex];

                // Hücre değerlerini metin kutularına ata
                txt_id_apmi.Text = selectedRow.Cells["MusteriID"].Value?.ToString();
                txt_kullaniciadi_apmi.Text = selectedRow.Cells["KullaniciAdi"].Value?.ToString();
                txt_kullanicisoyad.Text = selectedRow.Cells["kullaniciSoyad"].Value?.ToString();
                txt_sifre_apmi.Text = selectedRow.Cells["sifre"].Value?.ToString();
                txt_emailadres_apmi.Text = selectedRow.Cells["emailAdres"].Value?.ToString();
                txt_adres.Text = selectedRow.Cells["adres"].Value?.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand komut = new SqlCommand("Update loginTable set kullaniciAdi=@kullaniciAdi,kullaniciSoyad=@kullaniciSoyad,sifre=@sifre,emailAdres=@emailAdres,adres=@adres where MusteriID=@MusteriID", con);
            komut.Parameters.AddWithValue("@kullaniciAdi", txt_kullaniciadi_apmi.Text);
            komut.Parameters.AddWithValue("@kullaniciSoyad", txt_kullanicisoyad.Text);
            komut.Parameters.AddWithValue("@sifre", txt_sifre_apmi.Text);
            komut.Parameters.AddWithValue("@emailAdres", txt_emailadres_apmi.Text);
            komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            komut.Parameters.AddWithValue("@MusteriID", txt_id_apmi.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musterigetir();
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void dataGridView_adminpanelden_musteriislemleri_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FilterAdminİsmeGöre(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("FilterAdminİsmeGöre", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_adminpanelden_musteriislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Bağlantıyı kapatıyoruz.

                }


            }

        }
        private void FilterAdminMusteriSoyad(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("FilterAdminMusteriSoyad", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_adminpanelden_musteriislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Bağlantıyı kapatıyoruz.

                }


            }

        }
        private void FilterAdminMusteriAdres(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("FilterAdminMusteriAdres", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_adminpanelden_musteriislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Bağlantıyı kapatıyoruz.

                }


            }
        }
        private void FilterAdminMusteriMail(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("FilterAdminMusteriMail", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_adminpanelden_musteriislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Bağlantıyı kapatıyoruz.

                }


            }
        }
        private void FilterAdminTumAboneler(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("FilterAdminTumAboneler", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_adminpanelden_musteriislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Bağlantıyı kapatıyoruz.

                }


            }
        }

        private void btn_genelarama_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_arama.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue)) { 
            MessageBox.Show("Lütfen bir arama kriteri giriniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            FilterAdminTumAboneler(filtervalue);
        }

        private void btn_ismegörearama_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_arama.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterAdminİsmeGöre(filtervalue);
        }

        private void btn_soyadagörearama_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_arama.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterAdminMusteriSoyad(filtervalue);
        }

        private void btn_mailegörearama_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_arama.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterAdminMusteriMail(filtervalue);
        }

        private void btn_adresegörearama_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_arama.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterAdminMusteriAdres(filtervalue);
        }

        private void btn_tumaboneler_Click(object sender, EventArgs e)
        {
            musterigetir();
            panel1.Visible = true;
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void btn_guncellenmisaboneler_Click(object sender, EventArgs e)
        {
            guncellenmiskayitlar();
            panel1.Visible = false;
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void btn_silinmismusteriler_Click(object sender, EventArgs e)
        {
            silinmiskayitlar();
            panel1.Visible = false;
            txt_id_apmi.Text = "";
            txt_kullaniciadi_apmi.Text = "";
            txt_kullanicisoyad.Text = "";
            txt_sifre_apmi.Text = "";
            txt_emailadres_apmi.Text = "";
            txt_adres.Text = "";
        }

        private void btn_pdfdısaaktar_Click(object sender, EventArgs e)
        {
            // SaveFileDialog ile kullanıcıdan dosya konumu alınır
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files|*.pdf";
            saveDialog.Title = "PDF Dosyası Kaydet";
            saveDialog.FileName = "Müşteriler.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // PDF Belgesi oluştur
                    Document pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveDialog.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // PDF içine başlık ekleyin
                    pdfDoc.Add(new Paragraph("Cihaz Listesi"));
                    pdfDoc.Add(new Paragraph("\n")); // Boşluk eklemek için

                    // Tabloyu oluştur ve kolon sayısını ayarla
                    PdfPTable pdfTable = new PdfPTable(dataGridView_adminpanelden_musteriislemleri.ColumnCount);

                    // Tablo başlıklarını ekle
                    foreach (DataGridViewColumn column in dataGridView_adminpanelden_musteriislemleri.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText));
                        headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfTable.AddCell(headerCell);
                    }

                    // DataGridView'deki verileri PDF tablosuna ekle
                    foreach (DataGridViewRow row in dataGridView_adminpanelden_musteriislemleri.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                            else
                            {
                                pdfTable.AddCell("");
                            }
                        }
                    }

                    // PDF tablosunu PDF belgesine ekle
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("PDF başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
