using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
   public class UnitOfWork:IUnitOfWork
   {
       private readonly DbModelContext _context;
       private GenericRepository<Manager> _managerRepository;
       private GenericRepository<Client> _clientRepository;
       private GenericRepository<Product> _productRepository;
       private GenericRepository<Selling> _sellingRepository; 
       public UnitOfWork()
       {
           _context = new DbModelContext();
       }

       public IGenericRepository<Product> ProductRepository
       {
           get
           {
               return _productRepository ?? (_productRepository = new GenericRepository<Product>(_context));
           }
       }

       public IGenericRepository<Selling> SellingRepository
       {
           get
           {
               return _sellingRepository ?? (_sellingRepository = new GenericRepository<Selling>(_context));
           }
       }

       public IGenericRepository<Manager> ManagerRepository
       {
           get
           {
               return _managerRepository ?? (_managerRepository = new GenericRepository<Manager>(_context));
           }
       }

       public IGenericRepository<Client> ClientRepository
       {
           get
           {
               return _clientRepository ?? (_clientRepository = new GenericRepository<Client>(_context));
           }
       }

       //public void Save()
       //{
       //    _context.SaveChanges();
       //}
    }
}
