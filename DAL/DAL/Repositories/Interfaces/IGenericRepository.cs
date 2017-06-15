using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
   public interface IGenericRepository<T> where T:class
   {
       IList<T> GetAll();
       IList<T> GetList(Func<T, bool> func);
       T GetOne(Func<T, bool> func);
       void Add(T item);
       void Update(T item);
       void Delete(int itemId);
   }
}
