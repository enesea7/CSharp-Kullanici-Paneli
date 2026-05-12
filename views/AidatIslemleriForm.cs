using SiteYonetimSistemi.controllers;
using SiteYonetimSistemi.models;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Org.BouncyCastle.Crypto.Macs;

namespace SiteYonetimSistemi.views
{
    public partial class AidatIslemleriForm : Form
    {

        string gonderenMail = "enesars200412@gmail.com";
        string uygulamaSifresi = "berxajmjxfcjetwo";

        
        AidatController controller = new AidatController();
        int seciliId = -1;

        public AidatIslemleriForm()
        {
            InitializeComponent();
            btnOdemeAl.Enabled = false;
            dgvAidatlar.AllowUserToAddRows = false;

            dgvAidatlar.CellClick += dgvAidatlar_CellClick;
        }
       
        private void AidatIslemleriForm_Load(object sender, EventArgs e)
        {
           
            

            cmbDurum.SelectedIndex = 0;

            Listele();
        }

        void Listele()
        {
            dgvAidatlar.DataSource = controller.Liste();
        }

        void Temizle()
        {
            txtDaireNo.Clear();
            txtAdSoyad.Clear();
            txtTutar.Clear();

            dtpAyYil.Value = DateTime.Now;
            dtpSonOdeme.Value = DateTime.Now;

            cmbDurum.SelectedIndex = 0;
            cmbDurum.SelectedIndex = 0;

            seciliId = -1;

            dgvAidatlar.ClearSelection();
        }
        private void dgvAidatlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow satir = dgvAidatlar.Rows[e.RowIndex];

            if (satir.IsNewRow)
                return;

            if (satir.Cells["Id"].Value == null)
                return;

            seciliId = Convert.ToInt32(satir.Cells["Id"].Value);

            txtDaireNo.Text = satir.Cells["DaireNo"].Value?.ToString();
            txtAdSoyad.Text = satir.Cells["AdSoyad"].Value?.ToString();
            txtTutar.Text = satir.Cells["Tutar"].Value?.ToString();
            cmbDurum.Text = satir.Cells["Durum"].Value?.ToString();

            string ay = satir.Cells["Ay"].Value.ToString();
            int yil = Convert.ToInt32(satir.Cells["Yil"].Value);

            int ayNo = DateTime.ParseExact(
                ay,
                "MMMM",
                new CultureInfo("tr-TR")
            ).Month;

            dtpAyYil.Value = new DateTime(yil, ayNo, 1);

            if (satir.Cells["SonOdemeTarihi"].Value != null)
            {
                dtpSonOdeme.Value = Convert.ToDateTime(satir.Cells["SonOdemeTarihi"].Value);
            }
        }

        private void btnAidatEkle_Click(object sender, EventArgs e)
        {
            string ay = dtpAyYil.Value.ToString("MMMM", new CultureInfo("tr-TR"));
            int yil = dtpAyYil.Value.Year;

            Aidat a = new Aidat()
            {
                DaireNo = int.Parse(txtDaireNo.Text),
                AdSoyad = txtAdSoyad.Text,
                Ay = ay,
                Yil = yil,
                Tutar = decimal.Parse(txtTutar.Text),
                SonOdemeTarihi = dtpSonOdeme.Value,
                Durum = cmbDurum.Text
            };

            controller.Ekle(a);
            Listele();
            Temizle();
        }

        

        private void btnAidatGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliId == -1) return;

            string ay = dtpAyYil.Value.ToString("MMMM", new CultureInfo("tr-TR"));
            int yil = dtpAyYil.Value.Year;

            Aidat a = new Aidat()
            {
                Id = seciliId,
                DaireNo = int.Parse(txtDaireNo.Text),
                AdSoyad = txtAdSoyad.Text,
                Ay = ay,
                Yil = yil,
                Tutar = decimal.Parse(txtTutar.Text),
                SonOdemeTarihi = dtpSonOdeme.Value,
                Durum = grpAidatBilgileri.Text
            };

            controller.Guncelle(a);
            Listele();
            Temizle();
        }

        private void btnAidatSil_Click(object sender, EventArgs e)
        {
            if (dgvAidatlar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek kaydı seçin.");
                return;
            }

            int id = Convert.ToInt32(dgvAidatlar.CurrentRow.Cells["Id"].Value);

            DialogResult sonuc = MessageBox.Show(
                "Bu aidat kaydı silinsin mi?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (sonuc == DialogResult.Yes)
            {
                controller.Sil(id);
                Listele();
                Temizle();
                MessageBox.Show("Kayıt silindi.");
            }
        }
        private void AidatMailGonder(string aliciMail, string adSoyad, string tutar, string sonOdeme)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gonderenMail);
            mail.To.Add(aliciMail);
            mail.Subject = "Aidat Ödeme Hatırlatması";

            mail.Body =
                "Sayın " + adSoyad + ",\n\n" +
                "Aidat ödemeniz bekliyor görünmektedir.\n\n" +
                "Aidat Tutarı: " + tutar + " TL\n" +
                "Son Ödeme Tarihi: " + sonOdeme + "\n\n" +
                "Lütfen ödemenizi gerçekleştiriniz.\n\n" +
                "Site Yönetimi";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(gonderenMail, uygulamaSifresi);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            if (seciliId == -1) return;

            controller.OdemeAl(seciliId);
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void dgvAidatlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void MailGonder(string aliciMail, string adSoyad, string tutar, string sonOdeme)
        {
            string gonderenMail = "enesars200412@gmail.com";
            string uygulamaSifresi = "berxajmjxfcjetwo";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gonderenMail);
            mail.To.Add(aliciMail);
            mail.Subject = "Aidat Ödeme Hatırlatması";

            mail.Body =
                "Sayın " + adSoyad + ",\n\n" +
                "Aidat ödemeniz henüz yapılmamış görünmektedir.\n\n" +
                "Aidat Tutarı: " + tutar + " TL\n" +
                "Son Ödeme Tarihi: " + sonOdeme + "\n\n" +
                "Lütfen en kısa sürede ödemenizi gerçekleştiriniz.\n\n" +
                "Site Yönetimi";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(gonderenMail, uygulamaSifresi);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

        private void btnMailGonder_Click(object sender, EventArgs e)
        {
            if (dgvAidatlar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen mail gönderilecek aidat kaydını seçin.");
                return;
            }

            string adSoyad = dgvAidatlar.CurrentRow.Cells["AdSoyad"].Value.ToString();
            string tutar = dgvAidatlar.CurrentRow.Cells["Tutar"].Value.ToString();
            string sonOdeme = dgvAidatlar.CurrentRow.Cells["SonOdemeTarihi"].Value.ToString();
            string durum = dgvAidatlar.CurrentRow.Cells["Durum"].Value.ToString();

            if (durum == "Ödendi")
            {
                MessageBox.Show("Bu aidat zaten ödenmiş.");
                return;
            }

            string aliciMail = controller.KullaniciEpostaBul(adSoyad);

            if (string.IsNullOrWhiteSpace(aliciMail))
            {
                MessageBox.Show("Bu kullanıcıya ait e-posta adresi bulunamadı.");
                return;
            }

            try
            {
                MailGonder(aliciMail, adSoyad, tutar, sonOdeme);
                MessageBox.Show("Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnOdemeAl_Click_1(object sender, EventArgs e)
        {

        }

        private void dtpAyYil_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnAidatGuncelle_Click_1(object sender, EventArgs e)
        {
            if (seciliId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek aidat kaydını seçiniz.");
                return;
            }

            if (txtDaireNo.Text == "" || txtAdSoyad.Text == "" || txtTutar.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            Aidat aidat = new Aidat();

            aidat.Id = seciliId;
            aidat.DaireNo = Convert.ToInt32(txtDaireNo.Text);
            aidat.AdSoyad = txtAdSoyad.Text;
            aidat.Ay = dtpAyYil.Value.ToString("MMMM", new CultureInfo("tr-TR"));
            aidat.Yil = dtpAyYil.Value.Year;
            aidat.Tutar = Convert.ToDecimal(txtTutar.Text);
            aidat.SonOdemeTarihi = dtpSonOdeme.Value;
            aidat.Durum = cmbDurum.Text;

            controller.Guncelle(aidat);

            MessageBox.Show("Aidat bilgisi güncellendi.");

            Listele();
            Temizle();
        }
    }
}