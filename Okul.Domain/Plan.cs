using System;
using System.Collections.Generic;

namespace Okul.Domain
{
    public class Plan : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }


        public int BransId { get; set; }
        public Brans Brans { get; set; }


        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; }

        public ICollection<Yoklama> Yoklamalar { get; set; }

    }
}
