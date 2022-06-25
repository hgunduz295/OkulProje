using Okul.Domain;

namespace Okul.BL.Abstract
{
    public interface ISinifManager : IManager<Sinif>
    {
        public bool CheckForSinifName(string SinifAdi);

    }
}
