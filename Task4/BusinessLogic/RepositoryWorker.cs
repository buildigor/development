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
       private IUnitOfWork _unitOfWork;

       public RepositoryWorker()
       {
           _unitOfWork = new UnitOfWork();
       }

       public void AddSale(SaleDto saleDto)
       {
           var manager = new ManagerDto() {SecondName = saleDto.Manager};
           var client = new ClientDto() {FullName = saleDto.Client};
           var product = new ProductDto() {Name = saleDto.Product};
           //Mapper.Initialize(cfg=>cfg.CreateMap<,ManagerDto>());
           //var managerId = Mapper.Map<Manager,ManagerDto>()
       }
   }
}
