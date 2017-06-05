using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
   public interface IRepository<T> where T:class 
   {
       void Add(T item);
       void Remove(T item);
       int? GetId(T item);
       IEnumerable<T> GetAll();
       T GetById(int id);
       void SaveChanges();
       void Update(T item);
   }
}
