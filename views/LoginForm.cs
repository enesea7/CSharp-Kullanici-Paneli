using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteYonetimSistemi.views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = txtEposta.Text;
            string sifre = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(eposta) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen e-posta ve şifre alanlarını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            SiteYonetimSistemi.controllers.GirisController kontrolcu = new SiteYonetimSistemi.controllers.GirisController();
            SiteYonetimSistemi.models.Kullanici girisYapan = kontrolcu.GirisYap(eposta, sifre);

            if (girisYapan != null)
            {
                
                
                MessageBox.Show($"Hoşgeldiniz, {girisYapan.AdSoyad}!\nRolünüz: {girisYapan.Rol}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (girisYapan.Rol == "Yonetici")
                {
                    
                    Form1 yoneticiPaneli = new Form1();
                    yoneticiPaneli.Show();

                    
                    this.Hide();
                }
                else if (girisYapan.Rol.Trim().ToLower() == "sakin")
                {
                    SakinPaneli sakinPaneli = new SakinPaneli(girisYapan);
                    sakinPaneli.Show();

                    this.Hide();
                }

            }
            else
            {
                
                MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void linkSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttumForm frm = new SifremiUnuttumForm();
            frm.Show();
        }
    }
}
