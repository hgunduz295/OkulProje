using Okul.DAL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.EfCore
{
    public class KullanicilarRepsitory:OkulDbRepository<Kullanici>,IKullanicilarRepository
    {
        /*
        Kullanici ile ilgili temel CRUD metodlari OkulDbRepository icerisinde mevcuttur.
        Eger Kullanici ile ilgili extra metodlara ihtiyacimiz olursa buraya eklenecek
        */
    }
}
