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
    public class ProductRepository : IRepository<Product>
    {
        private readonly DataModelContainer _context;

        public ProductRepository(DataModelContainer context)
        {
            _context = context;
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product!=null)
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product item)
        {
            _context.Entry(item).State=EntityState.Modified;
        }
    }
}
