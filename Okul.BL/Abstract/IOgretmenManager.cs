using Okul.Domain;

namespace Okul.BL.Abstract
{
    public interface IOgretmenManager : IManager<Ogretmen>
    {
        public bool CheckForTckimlik(string tcno);
        public bool CheckForGsm(string Gsm);

        public bool TCDogrula(string tcno);
    }
}
