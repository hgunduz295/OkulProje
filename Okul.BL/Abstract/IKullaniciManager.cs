using Okul.Domain;

namespace Okul.BL.Abstract
{
    public interface IKullaniciManager : IManager<Kullanici>
    {
        public bool CheckForUserName(string username);

    }
}
