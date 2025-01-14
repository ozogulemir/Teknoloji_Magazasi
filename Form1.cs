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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_kayitol_Click(object sender, EventArgs e)
        {
            kayit_ol_form kayıt_ol_form = new kayit_ol_form();
            kayıt_ol_form.Show();
        }
        public static int CurrentMusteriID; //Global Değişken
        private void btn_girisyap_Click(object sender, EventArgs e)
        {
            {
                // Veritabanına bağlan
                SqlConnection baglanti = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
                baglanti.Open();
                // Kullanıcıdan alınan giriş bilgileri
                string kullaniciAdi = txt_kullaniciAdı.Text;
                string sifre = txt_şifre.Text;

                

                // Sorgu
                string sorgu = "SELECT yetki FROM loginTable WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                // Sorguyu çalıştır ve sonuç al
                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read()) // Eğer kayıt bulunursa
                {
                    string yetki = reader["yetki"].ToString();

                    if (yetki == "admin")
                    {
                        MessageBox.Show("Admin girişi başarılı! Admin paneline yönlendiriliyorsunuz.","Bilgilendirme");
                        admin_panel_form adminPanel = new admin_panel_form();
                        
                        adminPanel.Show();
                        
                    }
                    else if (yetki == "müşteri")
                    {
                        SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
                        con.Open();

                        string query = "SELECT MusteriID FROM loginTable WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@kullaniciAdi",txt_kullaniciAdı.Text);
                        cmd.Parameters.AddWithValue("@sifre", txt_şifre.Text);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            CurrentMusteriID = Convert.ToInt32(dr["MusteriID"]); // Giriş yapan kullanıcının ID'si
                            MessageBox.Show("Müşteri girişi başarılı! Müşteri paneline yönlendiriliyorsunuz.", "Bilgilendirme");
                            btn_pdfdısakatar musteriPanel = new btn_pdfdısakatar();

                            musteriPanel.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı! Tekrar deneyiniz.","Hata");
                }

                // Bağlantıyı kapat
                reader.Close();
                baglanti.Close();
                
            }
        }

        private void lbl_sifremiunuttum_Click(object sender, EventArgs e)
        {
            Sifremi_Unuttum sifremi_Unuttum = new Sifremi_Unuttum();
            sifremi_Unuttum.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
