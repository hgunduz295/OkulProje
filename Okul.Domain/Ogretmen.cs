using System;
using System.Collections.Generic;

namespace Okul.Domain
{
    public class Ogretmen : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

        public decimal Maas { get; set; }

        public int BransId { get; set; }
        public Brans Brans { get; set; }

        public ICollection<Plan> Planlar { get; set; }

    }
}
