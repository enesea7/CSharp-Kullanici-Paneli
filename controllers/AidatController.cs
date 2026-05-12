using MySql.Data.MySqlClient;
using SiteYonetimSistemi.models;
using System.Data;


namespace SiteYonetimSistemi.controllers
{
    public class AidatController
    {
        private string baglantiCumlesi = "Server=localhost;Database=site_yonetim;Uid=root;Pwd=;";

        public DataTable Liste()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "SELECT Id, DaireNo, AdSoyad, Ay, Yil, Tutar, SonOdemeTarihi, Durum FROM aidatlar";

                MySqlDataAdapter da = new MySqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }
        public DataTable DaireyeGoreListele(int daireNo)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = @"SELECT Id, DaireNo, AdSoyad, Ay, Yil, Tutar, SonOdemeTarihi, Durum 
                         FROM aidatlar 
                         WHERE DaireNo = @DaireNo";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@DaireNo", daireNo);

                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                da.Fill(dt);
            }

            return dt;
        }
        public void OdemeYap(int aidatId)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "UPDATE aidatlar SET Durum = @Durum WHERE Id = @Id";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Durum", "Ödendi");
                komut.Parameters.AddWithValue("@Id", aidatId);

                komut.ExecuteNonQuery();
            }
        }
        public bool Ekle(Aidat aidat)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = @"INSERT INTO aidatlar
                (DaireNo, AdSoyad, Ay, Yil, Tutar, SonOdemeTarihi, Durum)
                VALUES
                (@DaireNo, @AdSoyad, @Ay, @Yil, @Tutar, @SonOdemeTarihi, @Durum)";

                using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@DaireNo", aidat.DaireNo);
                    cmd.Parameters.AddWithValue("@AdSoyad", aidat.AdSoyad);
                    cmd.Parameters.AddWithValue("@Ay", aidat.Ay);
                    cmd.Parameters.AddWithValue("@Yil", aidat.Yil);
                    cmd.Parameters.AddWithValue("@Tutar", aidat.Tutar);
                    cmd.Parameters.AddWithValue("@SonOdemeTarihi", aidat.SonOdemeTarihi);
                    cmd.Parameters.AddWithValue("@Durum", aidat.Durum);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Guncelle(Aidat aidat)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = @"UPDATE aidatlar SET
                DaireNo = @DaireNo,
                AdSoyad = @AdSoyad,
                Ay = @Ay,
                Yil = @Yil,
                Tutar = @Tutar,
                SonOdemeTarihi = @SonOdemeTarihi,
                Durum = @Durum
                WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@Id", aidat.Id);
                    cmd.Parameters.AddWithValue("@DaireNo", aidat.DaireNo);
                    cmd.Parameters.AddWithValue("@AdSoyad", aidat.AdSoyad);
                    cmd.Parameters.AddWithValue("@Ay", aidat.Ay);
                    cmd.Parameters.AddWithValue("@Yil", aidat.Yil);
                    cmd.Parameters.AddWithValue("@Tutar", aidat.Tutar);
                    cmd.Parameters.AddWithValue("@SonOdemeTarihi", aidat.SonOdemeTarihi);
                    cmd.Parameters.AddWithValue("@Durum", aidat.Durum);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Sil(int id)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "DELETE FROM aidatlar WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool OdemeAl(int id)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "UPDATE aidatlar SET Durum = 'Ödendi' WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public string KullaniciEpostaBul(string adSoyad)
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "SELECT Eposta FROM kullanicilar WHERE AdSoyad = @AdSoyad LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@AdSoyad", adSoyad);

                    object sonuc = cmd.ExecuteScalar();

                    if (sonuc != null)
                        return sonuc.ToString();

                    return "";
                }
            }
        }


    }

}