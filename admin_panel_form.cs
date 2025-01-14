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
    public partial class admin_panel_form : Form
    {
        public admin_panel_form()
        {
            InitializeComponent();
        }

        private void btn_adminpanel_musteri_islemleri_Click(object sender, EventArgs e)
        {
            this.Close();
            adminpanelden_musteriislemleri adminpanelden_Musteriislemleri = new adminpanelden_musteriislemleri();
            adminpanelden_Musteriislemleri.Show();
        }

        private void btn_adminpanel_cihazislemleri_Click(object sender, EventArgs e)
        {
            this.Close();
            adminpanelden_cihazislemleri adminpanelden_Cihazislemleri= new adminpanelden_cihazislemleri();
            adminpanelden_Cihazislemleri.Show();
        }

        private void btn_adminpanel_cıkıs_Click(object sender, EventArgs e)
        {

            //admin_panel_form admin_Panel_Form= new admin_panel_form();
            //admin_Panel_Form.Close();
            //Form1 anasayfa = new Form1();
            //anasayfa.Show();

            this.Close();

            
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            



        }

        private void admin_panel_form_Load(object sender, EventArgs e)
        {

        }

        private void btn_siparisDetayı_Click(object sender, EventArgs e)
        {
            this.Close();
            Siparis_detayi siparis_Detayi=new Siparis_detayi();
            siparis_Detayi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL bağlantı dizesi
                string connectionString = "Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False";

                // Yedekleme dosyasının kaydedileceği konumu ayarlar.
                string backupFolder = @"C:\DatabaseBackups"; // Yedek dosyasının tutulacağı klasör
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder); // Klasör yoksa oluşturur.
                }
                string backupFileName = Path.Combine(backupFolder, $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                // SQL yedekleme komutu
                // "WITH INIT" parametresi kullanarak eski yedek dosyasının üzerine yazılmasını sağlar.
                string backupQuery = $"BACKUP DATABASE [Teknoloji_Magazası] TO DISK = '{backupFileName}' WITH INIT";

                // SQL bağlantısı ve komut çalıştırır.
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                // Başarılı mesajı
                MessageBox.Show($"Veritabanı başarıyla yedeklendi.\nDosya Konumu: {backupFileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Yedekleme sırasında bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL bağlantı dizesi
                string connectionString = "Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False";  // master veritabanını kullanıyoruz

                // Kullanıcıya yedek dosyasını seçtirmek için OpenFileDialog kullanıyoruz
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // openFileDialog.Filter = "Yedek Dosyaları (.bak)|.bak"; // sadece .bak dosyalarını gösterir.
                openFileDialog.Filter = "Yedek Dosyaları (*.bak)|*.bak|Tüm Dosyalar (*.*)|*.*";
                openFileDialog.Title = "Yedek Dosyasını Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFile = openFileDialog.FileName;  // Kullanıcının seçtiği dosya yolu

                    // Geri yükleme komutu
                    string restoreQuery = $"RESTORE DATABASE [Teknoloji_Magazası] FROM DISK = '{backupFile}' WITH REPLACE;";

                    // SQL bağlantısı ve komut çalıştırır.
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(restoreQuery, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    // Başarılı mesajı
                    MessageBox.Show($"Veritabanı başarıyla geri yüklendi.\nYedek Dosyası: {backupFile}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Yedekten dönme sırasında bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
