using SiteYonetimSistemi.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteYonetimSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            views.KullaniciPaneli yeniSayfa = new views.KullaniciPaneli();
            yeniSayfa.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblAidat_Click(object sender, EventArgs e)
        {
            AidatIslemleriForm form = new AidatIslemleriForm();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 247, 250);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            AnaSayfaTablosuDoldur();
        }
        private void AnaSayfaTablosuDoldur()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("DaireNo", "Daire No");
            dataGridView1.Columns.Add("AdSoyad", "Ad Soyad");
            dataGridView1.Columns.Add("BorcTutari", "Borç Tutarı");
            dataGridView1.Columns.Add("SonOdemeTarihi", "Son Ödeme Tarihi");
            dataGridView1.Columns.Add("Durum", "Durum");

            dataGridView1.Rows.Add("5", "Ahmet Yılmaz", "750 TL", "10.05.2026", "Gecikti");
            dataGridView1.Rows.Add("8", "Ayşe Demir", "500 TL", "10.05.2026", "Gecikti");
            dataGridView1.Rows.Add("12", "Mehmet Kaya", "900 TL", "10.05.2026", "Gecikti");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
