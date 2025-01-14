using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknoloji_Magazasi
{
    public partial class btn_pdfdısakatar : Form
    {
        public btn_pdfdısakatar()
        {
            InitializeComponent();
        }

        private void dataGridView_ürünler_müsteripanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırın indeksi
            int selectedRowIndex = e.RowIndex;

            // Eğer tıklanan satır geçerliyse
            if (selectedRowIndex >= 0)
            {
                // DataGridView'deki satırı al
                DataGridViewRow selectedRow = dataGridView_ürünler_müsteripanel.Rows[selectedRowIndex];

                // Hücre değerlerini metin kutularına ata
                textBox1.Text = selectedRow.Cells["cihazid"].Value?.ToString();
                textBox2.Text = selectedRow.Cells["cihaz_marka"].Value?.ToString();
                textBox3.Text = selectedRow.Cells["cihaz_tür"].Value?.ToString();
                textBox4.Text = selectedRow.Cells["cihaz_model"].Value?.ToString();
                textBox5.Text = selectedRow.Cells["cihaz_fiyat"].Value?.ToString();
                textBox6.Text = selectedRow.Cells["kampanya"].Value?.ToString();

            }
        }

        private void Musteri_panel_form_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from cihaz_table", con);
            DataTable dataTable = new DataTable();
            cmd.Fill(dataTable);
            dataGridView_ürünler_müsteripanel.DataSource = dataTable;
            con.Close();
        }

        public void btn_sepeteekle_Click(object sender, EventArgs e)
        {
            if (dataGridView_ürünler_müsteripanel.CurrentRow != null)
            {
                // Seçilen satırdaki model ve fiyat sütunlarını al
                string urunMarka = dataGridView_ürünler_müsteripanel.CurrentRow.Cells["cihaz_marka"].Value.ToString();
                string urunAdi = dataGridView_ürünler_müsteripanel.CurrentRow.Cells["cihaz_model"].Value.ToString();
                string urunFiyati = dataGridView_ürünler_müsteripanel.CurrentRow.Cells["cihaz_fiyat"].Value.ToString();

                //// Ürünü ListBox'a ekle
                //listBox_sepet.Items.Add( urunMarka+"   " + urunAdi + "   " + urunFiyati + " TL");

                //// Toplam tutara ürünü ekle
                //decimal toplamTutar = string.IsNullOrEmpty(txt_toplamtutar.Text) ? 0 : Convert.ToDecimal(txt_toplamtutar.Text);
                //toplamTutar += Convert.ToDecimal(urunFiyati);
                //txt_toplamtutar.Text = toplamTutar.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçin!");
            }
        }

        private void btn_sepettemizle_Click(object sender, EventArgs e)
        {
            //listBox_sepet.Items.Clear();
            //txt_toplamtutar.Text = "0";
        }

        private void btn_sepettenSil_Click(object sender, EventArgs e)
        {

        }

        private void btn_gerigelll_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 anasayfa= new Form1();
            anasayfa.Show();
        }
        
        private void btn_siparisitamamla_Click(object sender, EventArgs e)
        {
            
            {
                try
                {
                    // Bağlantıyı using bloğuyla aç
                    using (SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        // DataGridView'den seçili cihazın cihazid'sini al
                        if (dataGridView_ürünler_müsteripanel.CurrentRow != null)
                        {
                            int cihazid = Convert.ToInt32(dataGridView_ürünler_müsteripanel.CurrentRow.Cells["cihazid"].Value);
                            
                            // Örnek: MusteriID oturumdan geliyor (bu kısmı giriş formunuza göre değiştirin)
                            int musteriID = GetCurrentMusteriID();

                            // SQL komutu: Siparisler tablosuna veri ekle
                            
                                string query = "INSERT INTO Siparisler (MusteriID, cihazid) VALUES (@musteriID, @cihazid)";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    // Parametreleri ata
                                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                                    cmd.Parameters.AddWithValue("@cihazid", cihazid);

                                    // Komutu çalıştır
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Sipariş başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                                    //listBox_sepet.Items.Clear();
                                }
                            }
                        else
                        {
                            MessageBox.Show("Lütfen bir cihaz seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Örnek MusteriID'yi döndüren metod
             int GetCurrentMusteriID()
            {
                // Giriş yapan kullanıcının MusteriID'sini buradan alın
                // Örneğin: bir global değişken veya giriş formundan dönen ID
                return Form1.CurrentMusteriID ; // Geçici olarak 1 döndürüyoruz
            }
            

        }

        
        private void FilterMusteriTumCihazlar(string filterValue) // Küçük harfle parametre adı düzeltilmiş
        {
            // SqlBaglanti sınıfı üzerinden bağlantıyı alıyoruz.
            SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
            con.Open();

            using (SqlCommand command = new SqlCommand("MusteriPanelCihazAra", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Stored procedure parametresini ekliyoruz.
                command.Parameters.AddWithValue("@FilterValue", filterValue); // Doğru parametre adı eşleşiyor

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt); // Veriyi DataTable'a dolduruyoruz.
                    dataGridView_ürünler_müsteripanel.DataSource = dt; // DataGridView'e bağlıyoruz.
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from cihaz_table", con);
            DataTable dataTable = new DataTable();
            cmd.Fill(dataTable);
            dataGridView_ürünler_müsteripanel.DataSource = dataTable;
            con.Close();
        }

        private void btn_cihazara_Click_1(object sender, EventArgs e)
        {
            string filtervalue = txt_cihazara.Text.Trim();

            if (string.IsNullOrEmpty(filtervalue))
            {
                MessageBox.Show("Lütfen bir arama kriteri giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterMusteriTumCihazlar(filtervalue);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from cihaz_table", con);
            DataTable dataTable = new DataTable();
            cmd.Fill(dataTable);
            dataGridView_ürünler_müsteripanel.DataSource = dataTable;
            con.Close();
            txt_cihazara.Text = "";
        }
        
        

private void txt_cihazara_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

