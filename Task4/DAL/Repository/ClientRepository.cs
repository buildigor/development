using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interfaces;
using Model;
using Client = DAL.Models.Client;

namespace DAL.Repository
{
  public  class ClientRepository:IRepository<Client>
  {
      private DataModelContainer _context;

      public ClientRepository(DataModelContainer context)
      {
          _context = context;
      }
      public void Add(Client item)
      {
          throw new NotImplementedException();
      }

      public void Remove(Client item)
      {
          throw new NotImplementedException();
      }

      public int? GetId(Client item)
      {
          throw new NotImplementedException();
      }

      public IEnumerable<Client> GetAll()
      {
          throw new NotImplementedException();
      }

      public Client GetById(int id)
      {
          throw new NotImplementedException();
      }

      public void SaveChanges()
      {
          throw new NotImplementedException();
      }

      public void Update(Client item)
      {
          throw new NotImplementedException();
      }
    }
}
