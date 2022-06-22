using Okul.BL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BL.Concrete
{
    public class BransManager : ManagerBase<Brans>, IBransManager
    {
        public bool CheckForBransName(string bransAdi)
        {
            var entities = base.db.GetAll(x => x.BransAdi == bransAdi);
            if (entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
