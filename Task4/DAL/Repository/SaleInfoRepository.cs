using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repository.Interfaces;
using Model;
using SaleInfo = DAL.Models.SaleInfo;


namespace DAL.Repository
{
  public  class SaleInfoRepository:IRepository<Models.SaleInfo>
  {
      private readonly DataModelContainer _context;

      public SaleInfoRepository(DataModelContainer context)
      {
          _context = context;
      }

      private Model.SaleInfo ObjectToEntity(Models.SaleInfo saleInfo)
      {
          return new Model.SaleInfo
          {
              ManagerId = saleInfo.ManagerId,
              ClientId = saleInfo.ClientId,
              ProductId = saleInfo.ProductId,
              Date = saleInfo.Date,
              Amount = saleInfo.Amount
          };
      }

      private Models.SaleInfo EntityToObject(Model.SaleInfo saleInfo)
      {
          return new SaleInfo
          {
              ManagerId = saleInfo.ManagerId,
              ClientId = saleInfo.ClientId,
              ProductId = saleInfo.ProductId,
              Date = saleInfo.Date,
              Amount = saleInfo.Amount
          };
      }

      public void Create(SaleInfo saleInfo)
      {
          Mapper.Initialize(cfg => cfg.CreateMap<Models.SaleInfo, Model.SaleInfo>());
          _context.SaleInfoes.Add(Mapper.Map<Models.SaleInfo, Model.SaleInfo>(saleInfo));
         // _context.SaleInfoes.Add(ObjectToEntity(saleInfo));
      }

      public int? GetId(SaleInfo saleInfo)
      {
          var tmp = _context.SaleInfoes.FirstOrDefault(s => (s.Id == saleInfo.Id));
          if (tmp == null)
          {
              return null;
          }
          return tmp.Id;
      }

      public IEnumerable<SaleInfo> GetAll()
      {
          return _context.SaleInfoes.Select(s => new DAL.Models.SaleInfo()
          {
              Id = s.Id,
              Date = s.Date,
              ManagerId = s.ManagerId,
              ClientId = s.ClientId,
              ProductId = s.ProductId,
              Amount = s.Amount
          });
      }

      public SaleInfo GetById(int id)
      {
          return EntityToObject(_context.SaleInfoes.FirstOrDefault(x => x.Id == id));
      }

      public void Update(SaleInfo saleInfo)
      {
          var sale = _context.SaleInfoes.FirstOrDefault(x => x.Id == saleInfo.Id);
          if (sale==null)return;
          sale.ManagerId = saleInfo.ManagerId;
          sale.ClientId = saleInfo.ClientId;
          sale.ProductId = saleInfo.ProductId;
          sale.Date = saleInfo.Date;
          sale.Amount = saleInfo.Amount;
      }
  }
}
