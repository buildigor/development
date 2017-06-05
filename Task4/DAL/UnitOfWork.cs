using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DAL.Repository.Interfaces;
using Model;
using Client = DAL.Models.Client;
using Manager = DAL.Models.Manager;
using Product = DAL.Models.Product;
using SaleInfo = DAL.Models.SaleInfo;

namespace DAL
{
  public class UnitOfWork
  {
      private DataModelContainer _context;
      private ClientRepository _clientRepository;
      private ManagerRepository _managerRepository;
      private ProductRepository _productRepository;
      private SaleInfoRepository _saleInfoRepository;
      public UnitOfWork()
      {
          _context = new DataModelContainer();
      }
      public IRepository<Client> Clients { get { return _clientRepository ??(_clientRepository= new ClientRepository(_context)); } }
      public IRepository<Manager> Managers { get { return _managerRepository ?? (_managerRepository = new ManagerRepository(_context)); } }
      public IRepository<Product> Products { get { return _productRepository ?? (_productRepository = new ProductRepository(_context)); } }
      public IRepository<SaleInfo> SalesInfo { get { return _saleInfoRepository ?? (_saleInfoRepository = new SaleInfoRepository(_context)); } } 
  }
}
