using SiteYonetimSistemi.models;
using SiteYonetimSistemi.controllers;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
namespace SiteYonetimSistemi.views

{
    public partial class SakinPaneli : Form
    {
        Kullanici girisYapanKullanici;

        public SakinPaneli()
        {
            InitializeComponent();

            ArayuzuDuzenle();

            dgvSakinAidatlar.AllowUserToAddRows = false;
            dgvSakinAidatlar.ReadOnly = true;
            dgvSakinAidatlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public SakinPaneli(Kullanici kullanici) : this()
        {
            girisYapanKullanici = kullanici;

            lblAdSoyad.Text = "Hoş geldiniz, " + kullanici.AdSoyad;
            lblDaireNo.Text = "Daire No: " + kullanici.DaireNo.ToString();

            AidatlariListele();
        }

        void AidatlariListele()
        {
            AidatController controller = new AidatController();

            dgvSakinAidatlar.DataSource = controller.DaireyeGoreListele(girisYapanKullanici.DaireNo);

            if (dgvSakinAidatlar.Columns["Id"] != null)
                dgvSakinAidatlar.Columns["Id"].Visible = false;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
        void ArayuzuDuzenle()
        {
            this.Text = "Site Sakini Paneli";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 10);
            this.Size = new Size(950, 550);

            lblAdSoyad.AutoSize = true;
            lblAdSoyad.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAdSoyad.ForeColor = Color.FromArgb(44, 62, 80);

            lblDaireNo.AutoSize = true;
            lblDaireNo.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblDaireNo.ForeColor = Color.FromArgb(52, 73, 94);

            dgvSakinAidatlar.EnableHeadersVisualStyles = false;
            dgvSakinAidatlar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvSakinAidatlar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSakinAidatlar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvSakinAidatlar.BackgroundColor = Color.White;
            dgvSakinAidatlar.BorderStyle = BorderStyle.None;
            dgvSakinAidatlar.RowHeadersVisible = false;
            dgvSakinAidatlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSakinAidatlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSakinAidatlar.MultiSelect = false;
            dgvSakinAidatlar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvSakinAidatlar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSakinAidatlar.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSakinAidatlar.RowTemplate.Height = 28;

            btnOdemeYap.FlatStyle = FlatStyle.Flat;
            btnOdemeYap.FlatAppearance.BorderSize = 0;
            btnOdemeYap.BackColor = Color.FromArgb(39, 174, 96);
            btnOdemeYap.ForeColor = Color.White;
            btnOdemeYap.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnOdemeYap.Size = new Size(130, 40);

            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.BackColor = Color.FromArgb(231, 76, 60);
            btnCikis.ForeColor = Color.White;
            btnCikis.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCikis.Size = new Size(130, 40);
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (dgvSakinAidatlar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen ödeme yapılacak aidatı seçiniz.");
                return;
            }

            int aidatId = Convert.ToInt32(dgvSakinAidatlar.CurrentRow.Cells["Id"].Value);

            string durum = dgvSakinAidatlar.CurrentRow.Cells["Durum"].Value.ToString();

            if (durum == "Ödendi")
            {
                MessageBox.Show("Bu aidat zaten ödenmiş.");
                return;
            }

            DialogResult cevap = MessageBox.Show(
                "Seçili aidatı ödemek istiyor musunuz?",
                "Ödeme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cevap == DialogResult.No)
                return;

            AidatController controller = new AidatController();
            controller.OdemeYap(aidatId);

            MessageBox.Show("Ödeme başarılı. Aidat durumu ödendi olarak güncellendi.");

            AidatlariListele();
        }
        private void SakinPaneli_Load(object sender, EventArgs e)
        {
            AidatTablosunaFaizEkle();
        }
        private int GecikenGunHesapla(DateTime sonOdemeTarihi)
        {
            int gecikenGun = (DateTime.Now.Date - sonOdemeTarihi.Date).Days;

            if (gecikenGun < 0)
            {
                return 0;
            }

            return gecikenGun;
        }
        private decimal FaizliTutarHesapla(decimal anaTutar, DateTime sonOdemeTarihi)
        {
            int gecikenGun = GecikenGunHesapla(sonOdemeTarihi);

            decimal faizOrani = 0;

            if (gecikenGun >= 10)
            {
                faizOrani = 2.00m; // %200
            }
            else if (gecikenGun >= 5)
            {
                faizOrani = 1.00m; // %100
            }
            else if (gecikenGun >= 2)
            {
                faizOrani = 0.10m; // %10
            }

            decimal faizliTutar = anaTutar + (anaTutar * faizOrani);

            return faizliTutar;
        }
        private void AidatTablosunaFaizEkle()
        {
            if (!dgvSakinAidatlar.Columns.Contains("GecikenGun"))
            {
                dgvSakinAidatlar.Columns.Add("GecikenGun", "Geciken Gün");
            }

            if (!dgvSakinAidatlar.Columns.Contains("FaizliTutar"))
            {
                dgvSakinAidatlar.Columns.Add("FaizliTutar", "Faizli Tutar");
            }

            int tutarKolonIndex = KolonIndexBul("Tutar");
            int sonOdemeKolonIndex = KolonIndexBul("Son");
            int durumKolonIndex = KolonIndexBul("Durum");

            foreach (DataGridViewRow row in dgvSakinAidatlar.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal tutar;

                bool tutarDogruMu = decimal.TryParse(
                    row.Cells[tutarKolonIndex].Value.ToString(),
                    System.Globalization.NumberStyles.Any,
                    new System.Globalization.CultureInfo("tr-TR"),
                    out tutar
                );

                if (!tutarDogruMu)
                {
                    MessageBox.Show("Tutar okunamadı: " + row.Cells[tutarKolonIndex].Value.ToString());
                    continue;
                }

                DateTime sonOdemeTarihi;

                bool tarihDogruMu = DateTime.TryParse(
                    row.Cells[sonOdemeKolonIndex].Value.ToString(),
                    new System.Globalization.CultureInfo("tr-TR"),
                    System.Globalization.DateTimeStyles.None,
                    out sonOdemeTarihi
                );

                if (!tarihDogruMu)
                {
                    MessageBox.Show("Son ödeme tarihi okunamadı: " + row.Cells[sonOdemeKolonIndex].Value.ToString());
                    continue;
                }

                int gecikenGun = GecikenGunHesapla(sonOdemeTarihi);
                decimal faizliTutar = FaizliTutarHesapla(tutar, sonOdemeTarihi);

                row.Cells["GecikenGun"].Value = gecikenGun;
                row.Cells["FaizliTutar"].Value = faizliTutar.ToString("0.00") + " TL";

                if (gecikenGun >= 2)
                {
                    row.Cells[durumKolonIndex].Value = "Gecikti";
                }
            }
        }
        private int KolonIndexBul(string arananBaslik)
        {
            for (int i = 0; i < dgvSakinAidatlar.Columns.Count; i++)
            {
                string baslik = dgvSakinAidatlar.Columns[i].HeaderText;

                if (baslik.Contains(arananBaslik))
                {
                    return i;
                }
            }

            MessageBox.Show(arananBaslik + " kolonu bulunamadı.");
            return -1;
        }

    }
}
