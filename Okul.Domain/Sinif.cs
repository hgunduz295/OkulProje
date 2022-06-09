using System.Collections.Generic;

namespace Okul.Domain
{
    public class Sinif : BaseEntity
    {
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }

        public ICollection<Plan> Planlar { get; set; }


    }
}
