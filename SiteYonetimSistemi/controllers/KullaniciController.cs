using SiteYonetimSistemi.models;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SiteYonetimSistemi.controllers
{
    public class KullaniciController
    {
        private string baglantiCumlesi = "Server=localhost;Database=site_yonetim;Uid=root;Pwd=;";

        public DataTable Liste()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    string sorgu = "SELECT Id, AdSoyad, Eposta, Rol, Fotograf FROM Kullanicilar";
                    MySqlDataAdapter da = new MySqlDataAdapter(sorgu, baglanti);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Kullanıcılar listelenirken hata oluştu: " + ex.Message);
                }
            }

            return dt;
        }

        public bool Ekle(Kullanici kullanici)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    string sorgu = @"INSERT INTO Kullanicilar 
                                     (AdSoyad, Eposta, Sifre, Rol, Fotograf) 
                                     VALUES 
                                     (@AdSoyad, @Eposta, @Sifre, @Rol, @Fotograf)";

                    using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@AdSoyad", kullanici.AdSoyad);
                        cmd.Parameters.AddWithValue("@Eposta", kullanici.Eposta);
                        cmd.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                        cmd.Parameters.AddWithValue("@Rol", kullanici.Rol);
                        cmd.Parameters.AddWithValue("@Fotograf", kullanici.Fotograf);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Kullanıcı eklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        public bool Guncelle(Kullanici kullanici)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    string sorgu = @"UPDATE Kullanicilar 
                                     SET AdSoyad = @AdSoyad,
                                         Eposta = @Eposta,
                                         Sifre = @Sifre,
                                         Rol = @Rol,
                                         Fotograf = @Fotograf
                                     WHERE Id = @Id";

                    using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@Id", kullanici.Id);
                        cmd.Parameters.AddWithValue("@AdSoyad", kullanici.AdSoyad);
                        cmd.Parameters.AddWithValue("@Eposta", kullanici.Eposta);
                        cmd.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                        cmd.Parameters.AddWithValue("@Rol", kullanici.Rol);
                        cmd.Parameters.AddWithValue("@Fotograf", kullanici.Fotograf);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Kullanıcı güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }

        public bool Sil(int id)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    string sorgu = "DELETE FROM Kullanicilar WHERE Id = @Id";

                    using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Kullanıcı silinirken hata oluştu: " + ex.Message);
                }
            }
        }
    }
}