using Okul.DAL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.EfCore
{
    public class BransRepository:OkulDbRepository<Brans>,IBransRepository
    {
        
        /*
         Brans ile ilgili temel CRUD metodlari OkulDbRepository icerisinde mevcuttur.
         Eger brans ile ilgili extra metodlara ihtiyacimiz olursa buraya eklenecek
         */
    }
}
