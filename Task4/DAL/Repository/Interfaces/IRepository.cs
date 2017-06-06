using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Repository.Interfaces
{
   public interface IRepository<T> where T:class 
   {
       void Add(T item);
       void Delete(int id);
       IEnumerable<T> GetAll();
       IEnumerable<T> Find(Func<T, Boolean> predicate);
       T GetById(int id);
       void Update(T item);
   }
}
