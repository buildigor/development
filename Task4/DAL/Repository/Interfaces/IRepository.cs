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
       void Create(T item);
       int? GetId(T item);
       IEnumerable<T> GetAll();
       T GetById(int id);
       void Update(T item);
   }
}
