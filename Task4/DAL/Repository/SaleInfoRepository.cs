using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using SaleInfo = DAL.Models.SaleInfo;

namespace DAL.Repository
{
  public  class SaleInfoRepository:IRepository<SaleInfo>
  {
      private DataModelContainer _context;

      public SaleInfoRepository(DataModelContainer context)
      {
          _context = context;
      }
      public void Add(SaleInfo item)
      {
          throw new NotImplementedException();
      }

      public void Remove(SaleInfo item)
      {
          throw new NotImplementedException();
      }

      public int? GetId(SaleInfo item)
      {
          throw new NotImplementedException();
      }

      public IEnumerable<SaleInfo> GetAll()
      {
          throw new NotImplementedException();
      }

      public SaleInfo GetById(int id)
      {
          throw new NotImplementedException();
      }

      public void SaveChanges()
      {
          throw new NotImplementedException();
      }

      public void Update(SaleInfo item)
      {
          throw new NotImplementedException();
      }
    }
}
