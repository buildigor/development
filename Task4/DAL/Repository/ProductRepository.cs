using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Product = DAL.Models.Product;

namespace DAL.Repository
{
    public class ProductRepository : IRepository<Models.Product>
    {
        private readonly DataModelContainer _context;

        public ProductRepository(DataModelContainer context)
        {
            _context = context;
        }

        private Model.Product ObjectToEntity(Models.Product product)
        {
            return new Model.Product
            {
                Name = product.Name
            };
        }

        private Models.Product EntityToObject(Model.Product product)
        {
            return new Product
            {
                Name = product.Name
            };
        }
        public void Create(Product product)
        {
            _context.Products.Add(ObjectToEntity(product));
        }

        public int? GetId(Product product)
        {
            var tmp = _context.Products.FirstOrDefault(p => (p.Name == product.Name));
            if (tmp == null)
            {
                return null;
            }
            return tmp.Id;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Select(x => new Product(){Id = x.Id,Name = x.Name});
        }

        public Product GetById(int id)
        {
            return EntityToObject(_context.Products.FirstOrDefault(x => x.Id == id));
        }

        public void Update(Product item)
        {
        }
    }
}
