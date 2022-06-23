using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.Domain
{
    public class Brans:BaseEntity
    {
        public string BransAdi { get; set; }

        public ICollection<Ogretmen> Ogretmenler { get; set; }
        public ICollection<Plan> Planlar { get; set; }

    }
}
