using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetimSistemi.models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public int DaireNo { get; set; }
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
        public string Fotograf { get; set; }
    }
}