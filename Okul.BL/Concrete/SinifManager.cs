using Okul.BL.Abstract;
using Okul.Domain;

namespace Okul.BL.Concrete
{
    public class SinifManager : ManagerBase<Sinif>, ISinifManager
    {
        public bool CheckForSinifName(string SinifAdi)
        {
            var entities = base.db.GetAll(x => x.SinifAdi == SinifAdi);
            if (entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
