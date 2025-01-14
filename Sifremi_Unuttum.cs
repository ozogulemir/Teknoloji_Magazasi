using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknoloji_Magazasi
{
    public partial class Sifremi_Unuttum : Form
    {
        public Sifremi_Unuttum()
        {
            InitializeComponent();
        }

        private void btn_sifremiunuttumgerigel_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }

        private void btn_mailgönder_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=EMIR\\SQLEXPRESS;Initial Catalog=Teknoloji_Magazası;Integrated Security=True;Encrypt=False");
            string email = txt_email.Text.Trim(); // Kullanıcıdan alınan e-posta

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen e-posta adresinizi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT kullaniciAdi, sifre FROM loginTable WHERE emailAdres = @Email", con);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string kullaniciAdi = reader["kullaniciAdi"].ToString();
                    string sifre = reader["sifre"].ToString();

                    // E-posta gönderme
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                    mail.From = new MailAddress("duceng.tech.2024@gmail.com"); // Gönderen e-posta adresi
                    mail.To.Add(email); // Alıcı e-posta
                    mail.Subject = "Şifre Hatırlatma";
                    mail.Body = $"Merhaba {kullaniciAdi},\n\nŞifreniz: {sifre}\n\nİyi günler dileriz.";

                    smtpClient.Credentials = new NetworkCredential("duceng.tech.2024@gmail.com", "igwv ebao yebl thpm");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);

                    MessageBox.Show("Şifre e-posta adresinize gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bu e-posta adresine ait bir kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            this.Hide();
            Form1 anasayfa= new Form1();
            anasayfa.Show();
        }

        private void Sifremi_Unuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 }

