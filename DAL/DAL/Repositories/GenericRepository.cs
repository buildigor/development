using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly DbModelContext _context;

        public GenericRepository(DbModelContext dbModelContext)
        {
            _context = dbModelContext;
        }
        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> GetList(Func<T, bool> func)
        {
            return _context.Set<T>().Where(func).ToList();
        }

        public T GetOne(Func<T, bool> func)
        {
            return _context.Set<T>().FirstOrDefault(func);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State=EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int itemId)
        {
            var id = _context.Set<T>().Find(itemId);
            if (id != null) _context.Set<T>().Remove(id);
            _context.SaveChanges();
        }
    }
}
