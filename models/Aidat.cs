using System;

namespace SiteYonetimSistemi.models
{
    public class Aidat
    {
        public int Id { get; set; }
        public int DaireNo { get; set; }
        public string AdSoyad { get; set; }
        public string Ay { get; set; }
        public int Yil { get; set; }
        public decimal Tutar { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public string Durum { get; set; }
    }
}