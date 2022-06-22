using Okul.BL.Abstract;
using Okul.Domain;
using System.Linq;

namespace Okul.BL.Concrete
{
    public class KullaniciManager : ManagerBase<Kullanici>, IKullaniciManager
    {



        public bool CheckForUserName(string username)
        {
            var entities = base.db.GetAll(x => x.UserName == username);
            if (entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
