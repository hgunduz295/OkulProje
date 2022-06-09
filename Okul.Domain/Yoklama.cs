using System;

namespace Okul.Domain
{
    public class Yoklama : BaseEntity
    {
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }

        public DateTime Tarih { get; set; }

        public DateTime Saat { get; set; }

        public int PlanID { get; set; }
        public Plan Plan { get; set; }
    }
}
