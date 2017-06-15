using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
   public class ClientRepository:GenericRepository<Client>,IClientRepository
    {
       public ClientRepository(DbModelContext dbModelContext) : base(dbModelContext)
       {
       }
    }
}
