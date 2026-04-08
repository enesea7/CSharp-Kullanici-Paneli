using SiteYonetimSistemi.controllers;
using SiteYonetimSistemi.models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SiteYonetimSistemi.views
{
    public partial class KullaniciPaneli : Form
    {
        private int? _seciliId = null;
        private string _fotoYolu = "";
        private KullaniciController _kullaniciController = new KullaniciController();

        public KullaniciPaneli()
        {
            InitializeComponent();

            // Genel görünüm
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(245, 246, 250);

            // DataGrid görünüm
            dgvKullanicilar.EnableHeadersVisualStyles = false;
            dgvKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKullanicilar.RowTemplate.Height = 35;
            dgvKullanicilar.BorderStyle = BorderStyle.None;
            dgvKullanicilar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKullanicilar.MultiSelect = false;
            dgvKullanicilar.ReadOnly = true;
            dgvKullanicilar.AllowUserToAddRows = false;
            dgvKullanicilar.AllowUserToDeleteRows = false;
            dgvKullanicilar.RowHeadersVisible = false;
            dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // PictureBox görünüm
            pbFotograf.SizeMode = PictureBoxSizeMode.Zoom;
            pbFotograf.BorderStyle = BorderStyle.FixedSingle;

            // Buton görünüm
            btnKullaniciEkle.FlatStyle = FlatStyle.Flat;
            btnKullaniciEkle.FlatAppearance.BorderSize = 0;
            btnKullaniciEkle.ForeColor = Color.White;
            btnKullaniciEkle.BackColor = Color.SeaGreen;

            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.FlatAppearance.BorderSize = 0;
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.BackColor = Color.RoyalBlue;

            btnKullaniciSil.FlatStyle = FlatStyle.Flat;
            btnKullaniciSil.FlatAppearance.BorderSize = 0;
            btnKullaniciSil.ForeColor = Color.White;
            btnKullaniciSil.BackColor = Color.IndianRed;

            btnFotografSec.FlatStyle = FlatStyle.Flat;
            btnFotografSec.FlatAppearance.BorderSize = 0;
            btnFotografSec.BackColor = Color.WhiteSmoke;

            btnFotografSil.FlatStyle = FlatStyle.Flat;
            btnFotografSil.FlatAppearance.BorderSize = 0;
            btnFotografSil.BackColor = Color.WhiteSmoke;

            // Event bağlama
            dgvKullanicilar.CellClick += dgvKullanicilar_CellClick;
            btnKullaniciEkle.Click += btnKullaniciEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnKullaniciSil.Click += btnKullaniciSil_Click;
            btnFotografSec.Click += btnFotografSec_Click;
            btnFotografSil.Click += btnFotografSil_Click;
            txtAra.TextChanged += txtAra_TextChanged;

            // Placeholder
            txtAra.Text = "Ara...";
            txtAra.ForeColor = Color.Gray;

            txtAra.Enter += (s, e) =>
            {
                if (txtAra.Text == "Ara...")
                {
                    txtAra.Text = "";
                    txtAra.ForeColor = Color.Black;
                }
            };

            txtAra.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtAra.Text))
                {
                    txtAra.Text = "Ara...";
                    txtAra.ForeColor = Color.Gray;
                }
            };

            ListeyiYenile();
        }

        private void ListeyiYenile()
        {
            // BURAYI GEREKİRSE DEĞİŞTİRECEĞİZ
            dgvKullanicilar.DataSource = _kullaniciController.Liste();
        }

        private void Temizle()
        {
            txtAdSoyad.Clear();
            txtEposta.Clear();
            txtSifre.Clear();
            cmbRol.SelectedIndex = -1;
            pbFotograf.Image = null;
            _seciliId = null;
            _fotoYolu = "";
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow satir = dgvKullanicilar.Rows[e.RowIndex];

            _seciliId = Convert.ToInt32(satir.Cells["Id"].Value);

            txtAdSoyad.Text = satir.Cells["AdSoyad"].Value?.ToString();
            txtEposta.Text = satir.Cells["Eposta"].Value?.ToString();
            cmbRol.Text = satir.Cells["Rol"].Value?.ToString();
            txtSifre.Text = "********";

            if (satir.Cells["Fotograf"].Value != null)
            {
                _fotoYolu = satir.Cells["Fotograf"].Value.ToString();

                ResmiYukle(_fotoYolu);
            }
            else
            {
                _fotoYolu = "";
                pbFotograf.Image = null;
            }
        }

        private void ResmiYukle(string yol)
        {
            if (!string.IsNullOrWhiteSpace(yol) && File.Exists(yol))
            {
                using (Image temp = Image.FromFile(yol))
                {
                    pbFotograf.Image = new Bitmap(temp);
                }
            }
            else
            {
                pbFotograf.Image = null;
            }
        }


        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Ad Soyad boş olamaz.");
                return;
            }

            Kullanici yeniKullanici = new Kullanici
            {
                AdSoyad = txtAdSoyad.Text,
                Eposta = txtEposta.Text,
                Sifre = txtSifre.Text,
                Rol = cmbRol.Text,
                Fotograf = _fotoYolu
            };

            // BURAYI GEREKİRSE DEĞİŞTİRECEĞİZ
            _kullaniciController.Ekle(yeniKullanici);

            ListeyiYenile();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_seciliId == null)
            {
                MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin.");
                return;
            }

            Kullanici guncelKullanici = new Kullanici
            {
                Id = _seciliId.Value,
                AdSoyad = txtAdSoyad.Text,
                Eposta = txtEposta.Text,
                Sifre = txtSifre.Text,
                Rol = cmbRol.Text,
                Fotograf = _fotoYolu
            };

            // BURAYI GEREKİRSE DEĞİŞTİRECEĞİZ
            _kullaniciController.Guncelle(guncelKullanici);

            ListeyiYenile();
            Temizle();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (_seciliId == null)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.");
                return;
            }

            DialogResult sonuc = MessageBox.Show(
                "Bu kullanıcı silinsin mi?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (sonuc == DialogResult.Yes)
            {
                // BURAYI GEREKİRSE DEĞİŞTİRECEĞİZ
                _kullaniciController.Sil(_seciliId.Value);

                ListeyiYenile();
                Temizle();
            }
        }

        private void btnFotografSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Fotoğraf Seç";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _fotoYolu = ofd.FileName;
                ResmiYukle(_fotoYolu);
            }
        }

        private void btnFotografSil_Click(object sender, EventArgs e)
        {
            _fotoYolu = "";
            pbFotograf.Image = null;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAra.Text == "Ara...") return;

            try
            {
                var dt = dgvKullanicilar.DataSource as System.Data.DataTable;
                if (dt != null)
                {
                    dt.DefaultView.RowFilter =
                        $"AdSoyad LIKE '%{txtAra.Text.Replace("'", "''")}%' OR Eposta LIKE '%{txtAra.Text.Replace("'", "''")}%' ";
                }
            }
            catch
            {
            }
        }

        private void lblEposta_Click(object sender, EventArgs e)
        {

        }
    }
}