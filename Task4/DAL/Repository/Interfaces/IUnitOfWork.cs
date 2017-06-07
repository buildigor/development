using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Repository.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
       IRepository<Models.Client> Clients { get; }
       IRepository<Models.Manager> Managers { get; }
       IRepository<Models.Product> Products { get; }
       IRepository<Models.SaleInfo> SalesInfo { get; }
       void Save();
    }
}
