using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;

namespace DAL.Repository
{
   public class ManagerRepository:IRepository<Manager>
   {
       private readonly DataModelContainer _context;

       public ManagerRepository(DataModelContainer context)
       {
           _context = context;
       }

       public void Add(Manager item)
       {
           _context.Managers.Add(item);
       }

       public void Delete(int id)
       {
           Manager manager = _context.Managers.Find(id);
           if (manager!=null)
           {
               _context.Managers.Remove(manager);
           }
       }

       public IEnumerable<Manager> GetAll()
       {
           return _context.Managers.ToList();
       }

       public IEnumerable<Manager> Find(Func<Manager, bool> predicate)
       {
           return _context.Managers.Where(predicate).ToList();
       }

       public Manager GetById(int id)
       {
         return  _context.Managers.Find(id);
       }

       public void Update(Manager item)
       {
           _context.Entry(item).State=EntityState.Modified;
       }
    }
}
