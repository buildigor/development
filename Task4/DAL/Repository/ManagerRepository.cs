using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Manager = DAL.Models.Manager;

namespace DAL.Repository
{
   public class ManagerRepository:IRepository<Manager>
   {
       private DataModelContainer _context;

       public ManagerRepository(DataModelContainer context)
       {
           _context = context;
       }
       public void Add(Manager item)
       {
           throw new NotImplementedException();
       }

       public void Remove(Manager item)
       {
           throw new NotImplementedException();
       }

       public int? GetId(Manager item)
       {
           throw new NotImplementedException();
       }

       public IEnumerable<Manager> GetAll()
       {
           throw new NotImplementedException();
       }

       public Manager GetById(int id)
       {
           throw new NotImplementedException();
       }

       public void SaveChanges()
       {
           throw new NotImplementedException();
       }

       public void Update(Manager item)
       {
           throw new NotImplementedException();
       }
    }
}
