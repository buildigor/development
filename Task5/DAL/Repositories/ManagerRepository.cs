using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
   public class ManagerRepository:GenericRepository<Manager>,IManagerRepository
    {
       public ManagerRepository(DbModelContext dbModelContext) : base(dbModelContext)
       {
       }
    }
}
