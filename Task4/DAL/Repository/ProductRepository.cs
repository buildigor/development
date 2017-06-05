using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Product = DAL.Models.Product;

namespace DAL.Repository
{
   public class ProductRepository:IRepository<Product>
   {
       private DataModelContainer _context;

       public ProductRepository(DataModelContainer context)
       {
           _context = context;
       }
       public void Add(Product item)
       {
           throw new NotImplementedException();
       }

       public void Remove(Product item)
       {
           throw new NotImplementedException();
       }

       public int? GetId(Product item)
       {
           throw new NotImplementedException();
       }

       public IEnumerable<Product> GetAll()
       {
           throw new NotImplementedException();
       }

       public Product GetById(int id)
       {
           throw new NotImplementedException();
       }

       public void SaveChanges()
       {
           throw new NotImplementedException();
       }

       public void Update(Product item)
       {
           throw new NotImplementedException();
       }
    }
}
