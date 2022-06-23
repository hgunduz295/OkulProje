using Okul.BL.Abstract;
using Okul.Domain;
using System;
using System.Linq;

namespace Okul.BL.Concrete
{
    public class OgretmenManager : ManagerBase<Ogretmen>, IOgretmenManager
    {
        public bool CheckForTckimlik(string tcno)
        {
            bool sonuc = true;

            if (tcno.Length != 11)
                throw new Exception($" {tcno} TC Kimlik Numarasi 11 Karakter olmalidir");


            foreach (char item in tcno)
            {
                if (!char.IsDigit(item))
                    throw new Exception($" {tcno}  TC Kimlik Numarasi Sayilardan Olusmalidir");
            }

            var ogrenci = base.db.GetAll(x => x.TcNo == tcno).FirstOrDefault();
            if (ogrenci != null)
                throw new Exception($" {tcno} TC Kimlik Numarasi Daha Onceden Kaydedilmistir");

            sonuc = false;

            return sonuc;
        }

        public bool CheckForGsm(string Gsm)
        {
            var ogrenci = base.db.GetAll(x => x.Gsm == Gsm).FirstOrDefault();

            if (ogrenci != null)
                throw new Exception($"{Gsm} Numarasi Daha Onceden Kaydedilmistir");

            return false;
        }

    }
}
