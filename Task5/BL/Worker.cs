using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.SpecificationForSearch;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace BL
{
    public class Worker:IWorker
    {
        private readonly UnitOfWork _unitOfWork;
        public Worker()
        {
            _unitOfWork= new UnitOfWork();
        }

        public IList<ManagerModel> GetAllManagers()
        {
            var managers = _unitOfWork.ManagerRepository.GetAll();
            return managers.Select(ToModelConverter.ToManagerModel).ToList();
        }

        public IList<SellingModel> GetAllSellings()
        {
            var sellings = _unitOfWork.SellingRepository.GetAll();
            return sellings.Select(ToModelConverter.ToSellingModel).ToList();
        }

        public IList<SellingModel> GetAllOrdersForManager(int id)
        {
            var sellings = _unitOfWork.SellingRepository.GetList(x => x.ManagerId == id);
            return sellings.Select(ToModelConverter.ToSellingModel).ToList();
        }

        public SellingModel GetOneSelling(int id)
        {
            var seling = _unitOfWork.SellingRepository.GetOne(x => x.Id == id);
            return ToModelConverter.ToSellingModel(seling);
        }

        public void AddNew(SellingModel sellingModel)
        {
            Selling selling = new Selling();
            var manager = _unitOfWork.ManagerRepository.GetOne(x => x.Name == sellingModel.ManagerName);
            if (manager==null)
            {
                _unitOfWork.ManagerRepository.Add(new Manager() { Name = sellingModel.ManagerName });
                var newManager = _unitOfWork.ManagerRepository.GetOne(x => x.Name == sellingModel.ManagerName);
                selling.ManagerId = newManager.Id;
            }
            else
            {
                selling.ManagerId = manager.Id;
            }
            var client = _unitOfWork.ClientRepository.GetOne(x => x.Name == sellingModel.ClientName);
            if (client==null)
            {
                _unitOfWork.ClientRepository.Add(new Client() { Name = sellingModel.ClientName });
                var newClient = _unitOfWork.ClientRepository.GetOne(x => x.Name == sellingModel.ClientName);
                selling.ClientId = newClient.Id;
            }
            else
            {
                selling.ClientId = client.Id;
            }
            var product = _unitOfWork.ProductRepository.GetOne(x => x.Name == sellingModel.ProductName);
            if (product==null)
            {
                _unitOfWork.ProductRepository.Add(new Product() { Name = sellingModel.ProductName });
                var newProduct = _unitOfWork.ProductRepository.GetOne(x => x.Name == sellingModel.ProductName);
                selling.ProductId = newProduct.Id;
            }
            else
            {
                selling.ProductId = product.Id;
            }
            selling.Date = sellingModel.Date;
            selling.Cost = sellingModel.Cost;
            _unitOfWork.SellingRepository.Add(selling);
        }

        public void Update(SellingModel sellingModel)
        {
            var sellingEdit = _unitOfWork.SellingRepository.GetOne(x => x.Id == sellingModel.Id);
            _unitOfWork.ClientRepository.Update(new Client() { Id = sellingEdit.ClientId, Name = sellingModel.ClientName });
            _unitOfWork.ProductRepository.Update(new Product() { Id = sellingEdit.ProductId, Name = sellingModel.ProductName });
            sellingEdit.Date = sellingModel.Date;
            sellingEdit.Cost = sellingModel.Cost;
            _unitOfWork.SellingRepository.Update(sellingEdit);
        }

        public void Delete(int id)
        {
            var sellingDelete = _unitOfWork.SellingRepository.GetOne(x => x.Id == id);
            _unitOfWork.SellingRepository.Delete(sellingDelete.Id);
        }

        public IEnumerable<SellingModel> Search(SearchSpecification searchSpecification)
        {
            return searchSpecification.SatisfiedBy(GetAllSellings());
        }
    }
}
