using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.DAL.EfCore
{
    public class BransDal
    {
        OkulDbContext context = new OkulDbContext();
        public Brans Get(int id)
        {
            return context.Branslar.Find(id);
        }
        public List<Brans>GetAll()
        {
            return context.Branslar.ToList();
        }
        public int Create(Brans entity)
        {
          
            context.Branslar.Add(entity);
            return 0;
        }
        public void Update(Brans entity)
        {
            context.Update(entity);
        }
        public void Delete(Brans entity)
        {
            context.Update(entity);
        }
    }
    
}
