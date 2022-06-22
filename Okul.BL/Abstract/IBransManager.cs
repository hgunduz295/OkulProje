using Okul.Domain;

namespace Okul.BL.Abstract
{
    public interface IBransManager : IManager<Brans>
    {

        public bool CheckForBransName(string bransAdi);
    }
}
