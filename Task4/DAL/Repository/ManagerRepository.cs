using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Manager = DAL.Models.Manager;

namespace DAL.Repository
{
   public class ManagerRepository:IRepository<Models.Manager>
   {
       private readonly DataModelContainer _context;

       public ManagerRepository(DataModelContainer context)
       {
           _context = context;
       }
       private Model.Manager ObjectToEntity(Models.Manager manager)
       {
           return new Model.Manager
           {
               SecondName = manager.SecondName
           };
       }

       private Models.Manager EntityToObject(Model.Manager manager)
       {
           return new Manager
           {
               SecondName = manager.SecondName
           };
       }

       public void Create(Manager manager)
       {
           _context.Managers.Add(ObjectToEntity(manager));
       }

       public int? GetId(Manager manager)
       {
           var tmp = _context.Managers.FirstOrDefault(m => (m.SecondName == manager.SecondName));
           if (tmp == null)
           {
               return null;
           }
           return tmp.Id;
       }

       public IEnumerable<Manager> GetAll()
       {
           return _context.Managers.Select(x => new Manager() {Id = x.Id, SecondName = x.SecondName});
       }

       public Manager GetById(int id)
       {
           return EntityToObject(_context.Managers.FirstOrDefault(x => x.Id == id));
       }

       public void Update(Manager manager)
       {
           var tmp = _context.Managers.FirstOrDefault(m => (m.Id == manager.Id));
           if (tmp != null) tmp.SecondName = manager.SecondName;
       }
   }
}
