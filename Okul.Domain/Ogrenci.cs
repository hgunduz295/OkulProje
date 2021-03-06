using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.Domain
{
    public class Ogrenci:BaseEntity
    {
        public string   Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }

        public ICollection<Yoklama> Yoklamalar { get; set; }

    }
}
