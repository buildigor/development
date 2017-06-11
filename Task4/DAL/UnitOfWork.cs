using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DAL.Repository.Interfaces;
using Model;

namespace DAL
{
  public class UnitOfWork:IUnitOfWork
  {
      private DataModelContainer _context;
      private ClientRepository _clientRepository;
      private ManagerRepository _managerRepository;
      private ProductRepository _productRepository;
      private SaleInfoRepository _saleInfoRepository;
      private CsvWorkerInfoRepository _csvWorkerInfoRepository;
      public UnitOfWork()
      {
          _context = new DataModelContainer();
      }
      public IRepository<Models.Client> Clients { get { return _clientRepository ?? (_clientRepository = new ClientRepository(_context)); } }
      public IRepository<Models.Manager> Managers { get { return _managerRepository ?? (_managerRepository = new ManagerRepository(_context)); } }
      public IRepository<Models.Product> Products { get { return _productRepository ?? (_productRepository = new ProductRepository(_context)); } }
      public IRepository<Models.SaleInfo> SalesInfo { get { return _saleInfoRepository ?? (_saleInfoRepository = new SaleInfoRepository(_context)); } }
      public IRepository<Models.CsvWorkerInfo> CsvsWorkerInfo { get { return _csvWorkerInfoRepository ?? (_csvWorkerInfoRepository = new CsvWorkerInfoRepository(_context)); } }
      public void Save()
      {
          _context.SaveChanges();
      }

      public void Dispose()
      {
          if (_context == null) return;
          _context.Dispose();
          _context = null;
      }
  }
}
