using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
   public interface IUnitOfWork
    {
       IGenericRepository<Product> ProductRepository { get; }
       IGenericRepository<Selling> SellingRepository { get; }
       IGenericRepository<Manager> ManagerRepository { get; }
       IGenericRepository<Client> ClientRepository { get; }
       //void Save();
    }
}
