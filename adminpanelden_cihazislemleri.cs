using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;

namespace Teknoloji_Magazasi
{
    public partial class adminpanelden_cihazislemleri : Form
    {
        SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
        public adminpanelden_cihazislemleri()
        {
            InitializeComponent();
        }

        private void adminpanelden_cihazislemleri_Load(object sender, EventArgs e)
        {
            cihaz_listele();



        }

        private void btn_cihazekle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO cihaz_Table (cihaz_marka, cihaz_tür,cihaz_model,cihaz_fiyat,kampanya) VALUES (@cihaz_marka, @cihaz_tür,@cihaz_model,@cihaz_fiyat,@kampanya)", con);
            cmd.Parameters.AddWithValue("@cihaz_marka", txt_cihazmarka.Text);
            cmd.Parameters.AddWithValue("@cihaz_tür", txt_cihaztürü.Text);
            cmd.Parameters.AddWithValue("@cihaz_model", txt_cihazmodel.Text);
            cmd.Parameters.AddWithValue("@cihaz_fiyat", txt_cihazücret.Text);
            cmd.Parameters.AddWithValue("@kampanya", txt_cihazkampanya.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            cihaz_listele();
            MessageBox.Show("Cihaz eklendi.");
            txt_cihazid.Text = "";
            txt_cihazmarka.Text = "";
            txt_cihaztürü.Text = "";
            txt_cihazmodel.Text = "";
            txt_cihazücret.Text = "";
            txt_cihazkampanya.Text = "";

        }





        public void cihaz_listele()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from cihaz_table", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_apcihazislemleri.DataSource = dt;
            con.Close();
        }

        private void btn_cihazsil_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("DELETE FROM cihaz_Table WHERE cihazid = @id", con);
            //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_cihazid.Text));
            //int silinenkayit = cmd.ExecuteNonQuery();
            //con.Close();
            //if (silinenkayit > 0)
            //{

            //    cihaz_listele();
            //    MessageBox.Show("Cihaz silindi.", "Bilgilendirme");
            //}

            //else
            //{
            //    MessageBox.Show("Cihaz bulunamadı.");
            //}
            //txt_cihazid.Text = "";
            //txt_cihazmarka.Text = "";
            //txt_cihaztürü.Text = "";
            //txt_cihazmodel.Text = "";
            //txt_cihazücret.Text = "";
            //txt_cihazkampanya.Text = "";
            try
            {
                con.Open();

                // 1. Adım: Siparisler tablosundan ilişkili kayıtları sil
                SqlCommand cmdDeleteSiparisler = new SqlCommand("DELETE FROM dbo.Siparisler WHERE cihazid = @id", con);
                cmdDeleteSiparisler.Parameters.AddWithValue("@id", Convert.ToInt32(txt_cihazid.Text));
                cmdDeleteSiparisler.ExecuteNonQuery();

                // 2. Adım: cihaz_Table tablosundan cihazı sil
                SqlCommand cmdDeleteCihaz = new SqlCommand("DELETE FROM cihaz_Table WHERE cihazid = @id", con);
                cmdDeleteCihaz.Parameters.AddWithValue("@id", Convert.ToInt32(txt_cihazid.Text));
                int silinenKayit = cmdDeleteCihaz.ExecuteNonQuery();

                con.Close();

                // 3. Adım: Kullanıcıya bilgi ver
                if (silinenKayit > 0)
                {
                    cihaz_listele(); // Silme sonrası listeyi yenile
                    MessageBox.Show("Cihaz ve ilişkili siparişler silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cihaz bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 4. Adım: TextBox'ları temizle
                txt_cihazid.Text = "";
                txt_cihazmarka.Text = "";
                txt_cihaztürü.Text = "";
                txt_cihazmodel.Text = "";
                txt_cihazücret.Text = "";
                txt_cihazkampanya.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        private void btn_gerigell_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_panel_form admin_Panel_Form = new admin_panel_form();
            admin_Panel_Form.Show();
        }

        private void btn_silinmiscihazlar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from deleted_cihaz_Table", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_apcihazislemleri.DataSource = dt;
            con.Close();
            txt_cihazid.Text = "";
            txt_cihazmarka.Text = "";
            txt_cihaztürü.Text = "";
            txt_cihazmodel.Text = "";
            txt_cihazücret.Text = "";
            txt_cihazkampanya.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cihaz_listele();
            txt_cihazid.Text = "";
            txt_cihazmarka.Text = "";
            txt_cihaztürü.Text = "";
            txt_cihazmodel.Text = "";
            txt_cihazücret.Text = "";
            txt_cihazkampanya.Text = "";
        }

        private void btn_cihazara_Click(object sender, EventArgs e)
        {
            string filtervalue = txt_cihazara.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterAdminTumCihazlar(filtervalue);
        }
        private void FilterAdminTumCihazlar(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            con.Open();

            using (SqlCommand command = new SqlCommand("AdminPanelCihazAra", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_apcihazislemleri.DataSource = dt; // DataGridView'e bağlıyoruz.
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

        private void btn_pdfdısaaktar_Click(object sender, EventArgs e)
        {
            // SaveFileDialog ile kullanıcıdan dosya konumu alınır
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files|*.pdf";
            saveDialog.Title = "PDF Dosyası Kaydet";
            saveDialog.FileName = "Cihazlar.pdf";

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
                    PdfPTable pdfTable = new PdfPTable(dataGridView_apcihazislemleri.ColumnCount);

                    // Tablo başlıklarını ekle
                    foreach (DataGridViewColumn column in dataGridView_apcihazislemleri.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText));
                        headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfTable.AddCell(headerCell);
                    }

                    // DataGridView'deki verileri PDF tablosuna ekle
                    foreach (DataGridViewRow row in dataGridView_apcihazislemleri.Rows)
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

        private void btn_cihazimport_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            //openFileDialog.Title = "Excel Dosyası Seç";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        // Excel uygulamasını başlat
            //        Excel.Application excelApp = new Excel.Application();
            //        Excel.Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
            //        Excel._Worksheet worksheet = workbook.Sheets[1];
            //        Excel.Range range = worksheet.UsedRange;

            //        // DataTable oluştur
            //        DataTable dt = new DataTable();

            //        // Excel'den sütun başlıklarını oku
            //        for (int col = 1; col <= range.Columns.Count; col++)
            //        {
            //            dt.Columns.Add((range.Cells[1, col] as Excel.Range).Value2.ToString());
            //        }

            //        // Excel'den verileri oku
            //        for (int row = 2; row <= range.Rows.Count; row++) // 2. satırdan itibaren veriler başlıyor
            //        {
            //            DataRow dr = dt.NewRow();
            //            for (int col = 1; col <= range.Columns.Count; col++)
            //            {
            //                dr[col - 1] = (range.Cells[row, col] as Excel.Range).Value2?.ToString();
            //            }
            //            dt.Rows.Add(dr);
            //        }

            //        // DataTable'ı DataGridView'e bağla
            //        dataGridView_apcihazislemleri.DataSource = dt;

            //        // Excel'i kapat
            //        workbook.Close(false);
            //        excelApp.Quit();

            //        MessageBox.Show("Veriler başarıyla import edildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Excel Dosyası Seç";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Excel uygulamasını başlat
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
                    Excel._Worksheet worksheet = workbook.Sheets[1];
                    Excel.Range range = worksheet.UsedRange;

                    // DataTable oluştur
                    DataTable dt = new DataTable();

                    // Excel'den sütun başlıklarını oku
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        dt.Columns.Add((range.Cells[1, col] as Excel.Range).Value2.ToString());
                    }

                    // Excel'den verileri oku
                    for (int row = 2; row <= range.Rows.Count; row++) // 2. satırdan itibaren veriler başlıyor
                    {
                        DataRow dr = dt.NewRow();
                        for (int col = 1; col <= range.Columns.Count; col++)
                        {
                            dr[col - 1] = (range.Cells[row, col] as Excel.Range).Value2?.ToString();
                        }
                        dt.Rows.Add(dr);
                    }

                    // Veritabanına bağlan ve verileri ekle
                    string connectionString = "Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False"; // Burada bağlantı dizesini ayarlayın
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (DataRow row in dt.Rows)
                        {
                            string query = "INSERT INTO cihaz_Table ( cihaz_marka, cihaz_tür,cihaz_model,cihaz_fiyat,kampanya) VALUES ( @col2, @col3,@col4,@col5,@col6)"; // Sütun isimlerini veritabanı tablonuzla eşleştirin

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                // Excel verilerini SQL parametrelerine bağla
                                 // Eğer boş değer varsa DBNull.Value kullanılır
                                cmd.Parameters.AddWithValue("@col2", row["cihaz_marka"] ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@col3", row["cihaz_tür"] ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@col4", row["cihaz_model"] ?? DBNull.Value); // Eğer boş değer varsa DBNull.Value kullanılır
                                cmd.Parameters.AddWithValue("@col5", row["cihaz_fiyat"] ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@col6", row["kampanya"] ?? DBNull.Value);
                                // Diğer sütunlar için benzer şekilde parametre ekleyin

                                cmd.ExecuteNonQuery(); // Sorguyu çalıştır
                            }
                        }

                        conn.Close();
                    }

                    // DataTable'ı DataGridView'e bağla (isteğe bağlı)
                    dataGridView_apcihazislemleri.DataSource = dt;

                    // Excel'i kapat
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Veriler başarıyla import edildi ve veritabanına kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txt_cihazid.Text = "";
            txt_cihazmarka.Text = "";
            txt_cihaztürü.Text = "";
            txt_cihazmodel.Text = "";
            txt_cihazücret.Text = "";
            txt_cihazkampanya.Text = "";





















        }

        private void btn_cihazexport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            saveFileDialog.Title = "Excel Dosyası Kaydet";
            saveFileDialog.FileName = "Cihazlar.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Excel uygulamasını başlat
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.Sheets[1];
                    worksheet.Name = "Cihazlar";

                    // Sütun başlıklarını yazdır
                    for (int i = 1; i <= dataGridView_apcihazislemleri.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView_apcihazislemleri.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Font.Bold = true;
                    }

                    // DataGridView'deki verileri Excel'e yazdır
                    for (int i = 0; i < dataGridView_apcihazislemleri.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView_apcihazislemleri.Columns.Count; j++)
                        {
                            if (dataGridView_apcihazislemleri.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView_apcihazislemleri.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Excel dosyasını kaydet
                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Veriler başarıyla Excel'e aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txt_cihazid.Text = "";
            txt_cihazmarka.Text = "";
            txt_cihaztürü.Text = "";
            txt_cihazmodel.Text = "";
            txt_cihazücret.Text = "";
            txt_cihazkampanya.Text = "";
        }

        private void dataGridView_apcihazislemleri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            // Eğer tıklanan satır geçerliyse
            if (selectedRowIndex >= 0)
            {
                // DataGridView'deki satırı al
                DataGridViewRow selectedRow = dataGridView_apcihazislemleri.Rows[selectedRowIndex];

                // Hücre değerlerini metin kutularına ata
                txt_cihazid.Text = selectedRow.Cells["cihazid"].Value?.ToString();
                txt_cihazmarka.Text = selectedRow.Cells["cihaz_marka"].Value?.ToString();
                txt_cihaztürü.Text = selectedRow.Cells["cihaz_tür"].Value?.ToString();
                txt_cihazmodel.Text = selectedRow.Cells["cihaz_model"].Value?.ToString();
                txt_cihazücret.Text = selectedRow.Cells["cihaz_fiyat"].Value?.ToString();
                txt_cihazkampanya.Text = selectedRow.Cells["kampanya"].Value?.ToString();
            }

            //private void txt_cihazara_TextChanged(object sender, EventArgs e)
            //{

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
