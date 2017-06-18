using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace BL
{
    public class Worker:IWorker
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISellingRepository _sellingRepository;

        public Worker()
        {
            _managerRepository = new ManagerRepository(new DbModelContext());
            _clientRepository = new ClientRepository(new DbModelContext());
            _productRepository = new ProductRepository(new DbModelContext());
            _sellingRepository = new SellingRepository(new DbModelContext());
        }

        public IList<ManagerModel> GetAllManagers()
        {
            var managers = _managerRepository.GetAll();
            return managers.Select(ToModelConverter.ToManagerModel).ToList();
        }

        public IList<SellingModel> GetAllSellings()
        {
            var sellings = _sellingRepository.GetAll();
            return sellings.Select(ToModelConverter.ToSellingModel).ToList();
        }

        public IList<SellingModel> GetAllOrdersForManager(int id)
        {
            var sellings = _sellingRepository.GetList(x => x.ManagerId == id);
            return sellings.Select(ToModelConverter.ToSellingModel).ToList();
        }

        public SellingModel GetOneSelling(int id)
        {
            var seling = _sellingRepository.GetOne(x => x.Id == id);
            return ToModelConverter.ToSellingModel(seling);
        }

        public void AddNew(SellingModel sellingModel)
        {
            Selling selling = new Selling();
            var manager = _managerRepository.GetOne(x => x.Name == sellingModel.ManagerName);
            if (manager==null)
            {
                _managerRepository.Add(new Manager(){Name = sellingModel.ManagerName});
                var newManager = _managerRepository.GetOne(x => x.Name == sellingModel.ManagerName);
                selling.ManagerId = newManager.Id;
            }
            else
            {
                selling.ManagerId = manager.Id;
            }
            var client = _clientRepository.GetOne(x => x.Name == sellingModel.ClientName);
            if (client==null)
            {
                _clientRepository.Add(new Client(){Name = sellingModel.ClientName});
                var newClient = _clientRepository.GetOne(x => x.Name == sellingModel.ClientName);
                selling.ClientId = newClient.Id;
            }
            else
            {
                selling.ClientId = client.Id;
            }
            var product = _productRepository.GetOne(x => x.Name == sellingModel.ProductName);
            if (product==null)
            {
                _productRepository.Add(new Product(){Name = sellingModel.ProductName});
                var newProduct = _productRepository.GetOne(x => x.Name == sellingModel.ProductName);
                selling.ProductId = newProduct.Id;
            }
            else
            {
                selling.ProductId = product.Id;
            }
            selling.Date = sellingModel.Date;
            selling.Cost = sellingModel.Cost;
            _sellingRepository.Add(selling);
        }

        public void Update(SellingModel sellingModel)
        {
            var sellingEdit = _sellingRepository.GetOne(x => x.Id == sellingModel.Id);
            _clientRepository.Update(new Client(){Id = sellingEdit.ClientId,Name = sellingModel.ClientName});
            _productRepository.Update(new Product(){Id = sellingEdit.ProductId,Name = sellingModel.ProductName});
            sellingEdit.Date = sellingModel.Date;
            sellingEdit.Cost = sellingModel.Cost;
            _sellingRepository.Update(sellingEdit);
        }

        public void Delete(SellingModel sellingModel)
        {
            var sellingDelete = _sellingRepository.GetOne(x => x.Id == sellingModel.Id);
            _sellingRepository.Delete(sellingDelete.Id);
        }
    }
}
