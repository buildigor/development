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
       IRepository<Client> Clients { get; }
       IRepository<Manager> Managers { get; }
       IRepository<Product> Products { get; }
       IRepository<SaleInfo> SalesInfo { get; }
       void Save();
    }
}
