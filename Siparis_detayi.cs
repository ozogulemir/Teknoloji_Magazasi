using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknoloji_Magazasi
{
    public partial class Siparis_detayi : Form
    {
        public Siparis_detayi()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
        
        private void Siparis_detayi_Load(object sender, EventArgs e)
        {
            try
            {
                using (con) // Bağlantı nesnesi
                {
                    // SQL sorgusu
                    string query = @"
        SELECT 
    Siparisler.SiparisID,
    loginTable.MusteriID,
    loginTable.kullaniciAdi, 
    loginTable.kullaniciSoyad, 
    cihaz_Table.cihaz_marka, 
    cihaz_Table.cihaz_tür, 
    cihaz_Table.cihaz_model, 
    cihaz_Table.cihaz_fiyat, 
    cihaz_Table.kampanya
FROM 
    Siparisler
INNER JOIN 
    loginTable ON Siparisler.MusteriID = loginTable.MusteriID
INNER JOIN 
    cihaz_Table ON Siparisler.cihazid = cihaz_Table.cihazid;";


                    // SqlDataAdapter ile veriyi al
                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    // DataTable oluştur ve veriyi doldur
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGridView'e veriyi ata
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_tumsiparisdetayara_Click(object sender, EventArgs e)
        {
            
        }
        

        private void btn_geriDön_Click(object sender, EventArgs e)
        {
            admin_panel_form admin_Panel_Form= new admin_panel_form();
            admin_Panel_Form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_tumsiparisdetay_Click(object sender, EventArgs e)
        {
            try
            {
                using (con) // Bağlantı nesnesi
                {
                    // SQL sorgusu
                    string query = @"
        SELECT 
    Siparisler.SiparisID,
    loginTable.MusteriID,
    loginTable.kullaniciAdi, 
    loginTable.kullaniciSoyad, 
    cihaz_Table.cihaz_marka, 
    cihaz_Table.cihaz_tür, 
    cihaz_Table.cihaz_model, 
    cihaz_Table.cihaz_fiyat, 
    cihaz_Table.kampanya
FROM 
    Siparisler
INNER JOIN 
    loginTable ON Siparisler.MusteriID = loginTable.MusteriID
INNER JOIN 
    cihaz_Table ON Siparisler.cihazid = cihaz_Table.cihazid;";


                    // SqlDataAdapter ile veriyi al
                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    // DataTable oluştur ve veriyi doldur
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGridView'e veriyi ata
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
    }
}
