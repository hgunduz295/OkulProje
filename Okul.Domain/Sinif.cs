using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.Domain
{
    public class Sinif:BaseEntity
    {
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }

        public ICollection<Plan> Planlar { get; set; }

    }
}
