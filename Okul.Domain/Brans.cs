using System.Collections.Generic;

namespace Okul.Domain
{
    public class Brans : BaseEntity
    {
        public string BransAdi { get; set; }
        public ICollection<Ogretmen> Ogretmenler { get; set; }
        public ICollection<Plan> Planlar { get; set; }
    }
}
