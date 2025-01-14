using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknoloji_Magazasi
{
    public partial class kayit_ol_form : Form
    {
        SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
        public kayit_ol_form()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_kayitol2_Click(object sender, EventArgs e)
        {

            //con.Open();
            //SqlCommand cmd = new SqlCommand("INSERT INTO loginTable (kullaniciAdi,kullaniciSoyad, sifre,emailAdres,adres) VALUES (@kullaniciAdi,@kullaniciSoyad, @sifre,@emailAdres,@adres)", con);
            //cmd.Parameters.AddWithValue("@kullaniciAdi", txt_kayitkullaniciadi.Text);
            //cmd.Parameters.AddWithValue("@kullaniciSoyad", txt_kullaniciSoyadi.Text);
            //cmd.Parameters.AddWithValue("@sifre", txt_kayitsifre.Text);
            //cmd.Parameters.AddWithValue("@emailAdres", txt_kayitemailadress.Text);
            //cmd.Parameters.AddWithValue("@adres", txt_adres.Text);


            //cmd.ExecuteNonQuery();
            //con.Close();

            //MessageBox.Show("DU'TECH teknoloji şirketine kaydınız başarıyla oluşturulmuştur.");
            if (string.IsNullOrWhiteSpace(txt_kayitkullaniciadi.Text) ||
            string.IsNullOrWhiteSpace(txt_kullaniciSoyadi.Text) ||
            string.IsNullOrWhiteSpace(txt_kayitsifre.Text) ||
            string.IsNullOrWhiteSpace(txt_kayitemailadress.Text) ||
            string.IsNullOrWhiteSpace(txt_adres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // Eğer tüm alanlar doluysa kayıt işlemi devam eder
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO loginTable (kullaniciAdi, kullaniciSoyad, sifre, emailAdres, adres) VALUES (@kullaniciAdi, @kullaniciSoyad, @sifre, @emailAdres, @adres)", con);

            cmd.Parameters.AddWithValue("@kullaniciAdi", txt_kayitkullaniciadi.Text);
            cmd.Parameters.AddWithValue("@kullaniciSoyad", txt_kullaniciSoyadi.Text);
            cmd.Parameters.AddWithValue("@sifre", txt_kayitsifre.Text);
            cmd.Parameters.AddWithValue("@emailAdres", txt_kayitemailadress.Text);
            cmd.Parameters.AddWithValue("@adres", txt_adres.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("DU-TECH teknoloji şirketine kaydınız başarıyla oluşturulmuştur.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_kayitkullaniciadi.Text = "";
            txt_kullaniciSoyadi.Text = "";
            txt_kayitsifre.Text = "";
            txt_kayitemailadress.Text = "";
            txt_adres.Text = "";
            this.Close();
            Form1 anasayfa =new Form1();
            anasayfa.Show();
        }

        private void btn_gerigellll_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }

        private void txt_kullaniciSoaydi_TextChanged(object sender, EventArgs e)
        {

        }

        private void kayit_ol_form_Load(object sender, EventArgs e)
        {

        }

        private void txt_kayitkullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
