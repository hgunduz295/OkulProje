using System;

namespace Okul.Domain
{
    public class Ogrenci : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool Cinsiyet { get; set; }

        public DateTime DogumTarihi { get; set; }

    }
}
