using System;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SiteYonetimSistemi
{
    public partial class SifremiUnuttumForm : Form
    {
        string dogrulamaKodu = "";
        DateTime kodZamani;

        string connectionString = "Server=localhost;Database=site_yonetim;Uid=root;Pwd=";

        public SifremiUnuttumForm()
        {
            InitializeComponent();
        }

        private void SifremiUnuttumForm_Load(object sender, EventArgs e)
        {
        }

        private string KodUret()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private void MailGonder(string aliciMail, string kod)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("enesars200412@gmail.com", "berxajmjxfcjetwo");
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("enesars200412@gmail.com");
            mail.To.Add(aliciMail);
            mail.Subject = "Doğrulama Kodu";
            mail.Body = "Şifre değiştirme doğrulama kodunuz: " + kod;

            smtp.Send(mail);
        }

        private void btnKodGonder_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();

                if (email == "")
                {
                    MessageBox.Show("Lütfen e-posta adresinizi girin.");
                    return;
                }

                if (!email.Contains("@"))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi girin.");
                    return;
                }

                dogrulamaKodu = KodUret();
                kodZamani = DateTime.Now;

                MailGonder(email, dogrulamaKodu);

                MessageBox.Show("Doğrulama kodu mail adresinize gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string girilenKod = txtKod.Text.Trim();
                string yeniSifre = txtYeniSifre.Text.Trim();
                string yeniSifreTekrar = txtYeniSifreTekrar.Text.Trim();

                if (email == "" || girilenKod == "" || yeniSifre == "" || yeniSifreTekrar == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                if (dogrulamaKodu == "")
                {
                    MessageBox.Show("Önce kod gönder butonuna basın.");
                    return;
                }

                if ((DateTime.Now - kodZamani).TotalMinutes > 3)
                {
                    MessageBox.Show("Kodun süresi doldu. Lütfen yeniden kod isteyin.");
                    return;
                }

                if (girilenKod != dogrulamaKodu)
                {
                    MessageBox.Show("Doğrulama kodu yanlış.");
                    return;
                }

                if (yeniSifre != yeniSifreTekrar)
                {
                    MessageBox.Show("Yeni şifreler aynı değil.");
                    return;
                }

                 MySqlConnection conn = new MySqlConnection(connectionString);
                {
                    conn.Open();

                    MySqlCommand guncelle = new MySqlCommand("UPDATE kullanicilar SET Sifre=@sifre WHERE Eposta=@mail", conn);
                    guncelle.Parameters.AddWithValue("@sifre", yeniSifre);
                    guncelle.Parameters.AddWithValue("@mail", email);

                    int sonuc = guncelle.ExecuteNonQuery();

                    if (sonuc > 0)
                    {
                        MessageBox.Show("Şifreniz başarıyla güncellendi.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Şifre güncellenemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}