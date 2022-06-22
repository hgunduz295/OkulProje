using Okul.DAL.Abstract;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.EfCore
{
    public class OgretmenlerRepository:OkulDbRepository<Ogretmen>,IOgretmenlerRepository
    {
    }
}
