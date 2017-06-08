using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using DAL;
using DAL.Models;
using DAL.Repository;
using DAL.Repository.Interfaces;

namespace BusinessLogic
{
   public class RepositoryWorker
   {
       private readonly IUnitOfWork _unitOfWork;

       public RepositoryWorker()
       {
           _unitOfWork = new UnitOfWork();
       }

       public void AddSale(SaleDto saleDto)
       {
           var manager = new DAL.Models.Manager() {SecondName = saleDto.Manager};
           var client = new DAL.Models.Client() { FullName = saleDto.Client };
           var product = new DAL.Models.Product() { Name = saleDto.Product };
           var managerId = _unitOfWork.Managers.GetId(manager);
           if (managerId==null)
           {
               _unitOfWork.Managers.Create(manager);
               _unitOfWork.Save();
               managerId = _unitOfWork.Managers.GetId(manager);
           }
           
           var clientId = _unitOfWork.Clients.GetId(client);
           if (clientId==null)
           {
              _unitOfWork.Clients.Create(client); 
              _unitOfWork.Save();
              clientId = _unitOfWork.Clients.GetId(client);
           }
           
           var productId = _unitOfWork.Products.GetId(product);
           if (productId==null)
           {
               _unitOfWork.Products.Create(product);
               _unitOfWork.Save();
               productId = _unitOfWork.Products.GetId(product);
           }
           var sale = new DAL.Models.SaleInfo()
           {

               ClientId = (int)clientId,
               ManagerId = (int)managerId,
               ProductId = (int)productId,
               Date = saleDto.Date,
               Amount = saleDto.Amount
           };
           _unitOfWork.SalesInfo.Create(sale);
           _unitOfWork.Save();

           //Mapper.Initialize(cfg=>cfg.CreateMap<,ManagerDto>());
           //var managerId = Mapper.Map<Manager,ManagerDto>()
       }
   }
}
