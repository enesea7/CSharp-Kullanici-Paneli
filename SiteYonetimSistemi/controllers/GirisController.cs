using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SiteYonetimSistemi.models;
namespace SiteYonetimSistemi.controllers
{
    internal class GirisController
    {
        
        private string baglantiCumlesi = "Server=localhost;Database=site_yonetim;Uid=root;Pwd=;";

        public Kullanici GirisYap(string eposta, string sifre)
        {
            Kullanici aktifKullanici = null;

            try
            {
                
                using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
                {
                    baglanti.Open();
                    
                    string sorgu = "SELECT * FROM kullanicilar WHERE Eposta=@eposta AND Sifre=@sifre";

                    using (MySqlCommand komut = new MySqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@eposta", eposta);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        using (MySqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read()) 
                            {
                                aktifKullanici = new Kullanici();
                                aktifKullanici.Id = Convert.ToInt32(okuyucu["ID"]);
                                aktifKullanici.AdSoyad = okuyucu["AdSoyad"].ToString();
                                aktifKullanici.Eposta = okuyucu["Eposta"].ToString();
                                aktifKullanici.Rol = okuyucu["Rol"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                System.Windows.Forms.MessageBox.Show("Veri tabanı hatası: " + ex.Message);
            }

            return aktifKullanici; 
        }
    }
}
