using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;

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
          _context.SaleInfoes.Add(item);
      }

      public void Delete(int id)
      {
          SaleInfo saleInfo = _context.SaleInfoes.Find(id);
          if (saleInfo!=null)
          {
              _context.SaleInfoes.Remove(saleInfo);
          }
      }

      public IEnumerable<SaleInfo> GetAll()
      {
          return _context.SaleInfoes;
      }

      public IEnumerable<SaleInfo> Find(Func<SaleInfo, bool> predicate)
      {
          return _context.SaleInfoes.Where(predicate).ToList();
      }

      public SaleInfo GetById(int id)
      {
          return _context.SaleInfoes.Find(id);
      }

      public void Update(SaleInfo item)
      {
          _context.Entry(item).State=EntityState.Modified;
      }
  }
}
